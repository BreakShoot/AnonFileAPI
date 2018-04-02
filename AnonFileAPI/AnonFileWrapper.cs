using System;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace AnonFileAPI
{
    public class AnonFileWrapper : IDisposable
    {
        private readonly WebClient _client   = null;

        /// <summary>
        ///     Initializes new WebClient.          
        /// </summary>
        public AnonFileWrapper()
        {
            _client = new WebClient();
        }

        /// <summary>
        ///     Downloads the file to the specified path. 
        /// </summary>
        /// <param name="fileUrl"> The URL of the file wanted. </param>
        /// <param name="downloadLocation"> The specified path with file and extension </param>
        public void DownloadFile(string fileUrl, string downloadLocation)
        {
           _client.DownloadFile(GetDirectDownloadLinkFromLink(fileUrl), downloadLocation);
        }

        /// <summary>
        ///     Downloads the file to the specified path. 
        /// </summary>
        /// <param name="fileUrl"> The URL of the file wanted. </param>
        /// <param name="downloadLocation"> The specified path with file and extension </param>
        public void DownloadFileAsync(string fileUrl, string downloadLocation)
        {
            _client.DownloadFileAsync(new Uri(GetDirectDownloadLinkFromLink(fileUrl)), downloadLocation);
        }

        /// <summary>
        ///     Checks if file exists and uploads file. This along with parsing the output of the JSON response.
        /// </summary>
        /// <param name="fileLocation"> The specified path to the file to be uploaded. </param>
        public AnonFile UploadFile(string fileLocation)
        {
            if (!File.Exists(fileLocation))
                throw new AnonFileException($"Invalid file path at {fileLocation}");

            return ParseOutput(Encoding.Default.GetString(
                _client.UploadFile("https://anonfile.com/api/upload", fileLocation))
            );
        }

        /// <summary>
        /// Sorts through the link's HTML document to find the direct download link (which has a randomly string inserted inside of it).
        /// The ApartmentState was set to STA due to some funky errors with WebBrowser.
        /// </summary>
        /// <param name="link"></param>
        /// <param name="elementname"></param>
        /// <returns></returns>
        public string GetDirectDownloadLinkFromLink(string link, string elementname = "download-url")
        {
            string htmlDoc = _client.DownloadString(link);
            string directDownloadUrl = null;


            //this is only done to set the apartment state to STA and due to the webbrowser throwing errors if it isn't!
            Thread safeThread = new Thread(() =>
            {
                using (WebBrowser browser = new WebBrowser())
                {
                    browser.DocumentText = htmlDoc;
                    browser.ScriptErrorsSuppressed = true;
                    browser.Document.OpenNew(true);
                    browser.Document.Write(htmlDoc);
                    browser.Refresh();
                    directDownloadUrl = browser.Document.GetElementById(elementname).GetAttribute("href");
                }
            }){ ApartmentState = ApartmentState.STA };

            safeThread.Start();
            safeThread.Join();

            return directDownloadUrl ?? throw new AnonFileException("Failed to locate the direct download link! This could be because the website changed its element id for the download link, if so you can set the second paramater to the correct one!");
        }


        /// <summary>
        ///     Parses the JSON reply and returns AnonFiles with set properties. 
        /// </summary>
        /// <param name="input"></param>
        private AnonFile ParseOutput(string input)
        {
            using (var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(input),
                new System.Xml.XmlDictionaryReaderQuotas()))
            {
                var root = XElement.Load(jsonReader);
                bool status = Convert.ToBoolean(root.XPathSelectElement("//status")?.Value);

                if (!status)
                {
                    string errorMessage = root.XPathSelectElement("//error/message")?.Value;
                    string errorType = root.XPathSelectElement("//error/type")?.Value;
                    uint errorCode = Convert.ToUInt32(root.XPathSelectElement("//error/code")?.Value);
                    return new AnonFile(input, status, errorMessage, errorCode, errorType);
                }
                else
                {
                    string urlfull = root.XPathSelectElement("//url/full")?.Value;
                    string urlshort = root.XPathSelectElement("//url/short")?.Value;
                    uint size = Convert.ToUInt32(root.XPathSelectElement("//metadata/size/bytes")?.Value);
                    return new AnonFile(input, status, urlfull, urlshort, size);
                }
            }
        }

        /// <summary>
        ///     Dispose the webclient.
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
