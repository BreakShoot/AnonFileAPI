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
        private WebClient client         = null;
        private string DirectDownloadURL = null;
        
        /// <summary>
        ///     Initializes new WebClient.
        /// </summary>
        public AnonFileWrapper()
        {
            client = new WebClient();
        }

        /// <summary>
        ///     Downloads the file to the specified path. 
        /// </summary>
        /// <param name="fileURL"> The URL of the file wanted. </param>
        /// <param name="downloadLocation"> The specified path with file and extension </param>
        public void DownloadFile(string fileURL, string downloadLocation)
        {
           client.DownloadFile(getDirectDownloadLinkFromLink(fileURL), downloadLocation);
        }

        /// <summary>
        ///     Checks if file exists and uploads file. This along with parsing the output of the JSON response.
        /// </summary>
        /// <param name="fileLocation"> The specified path to the file to be uploaded. </param>
        public AnonFile UploadFile(string fileLocation)
        {
            if (!File.Exists(fileLocation))
                throw new Exception("Anon File Uploader ERROR: File does not exist!");
            
            byte[] uploadValue = client.UploadFile(@"https://anonfile.com/api/upload", fileLocation);
            return parseOutput(Encoding.Default.GetString(uploadValue));
        }

        /// <summary>
        ///     Sorts through the HTML document to find the direct download link (which has a randomly string inserted inside of it). NOT safe threading.
        /// </summary>
        /// <param name="htmlDocument"></param>
        /// <returns></returns>
        private void unsafeGetDirectDownloadLinkFromLink(string htmlDocument)
        {
            using (WebBrowser browser = new WebBrowser())
            {
                browser.DocumentText = htmlDocument;
                browser.ScriptErrorsSuppressed = true;
                browser.Document.OpenNew(true);
                browser.Document.Write(htmlDocument);
                browser.Refresh();
                DirectDownloadURL = browser.Document.GetElementById("download-url").GetAttribute("href");
            }
        }

        /// <summary>
        ///     Sorts through the link's HTML document to find the direct download link (which has a randomly string inserted inside of it).
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public string getDirectDownloadLinkFromLink(string link)
        {
            string HTMLDoc = client.DownloadString(link);
            Thread threadSafe = new Thread(() => unsafeGetDirectDownloadLinkFromLink(HTMLDoc));
            threadSafe.SetApartmentState(ApartmentState.STA);
            threadSafe.Start();
            threadSafe.Join();
            return DirectDownloadURL;
        }


        /// <summary>
        ///     This is the only private method. It parses the JSON reply and returns AnonFiles with set properties. 
        /// </summary>
        /// <param name="input"></param>
        private AnonFile parseOutput(string input)
        {
            var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(input), new System.Xml.XmlDictionaryReaderQuotas());
            var root = XElement.Load(jsonReader);
            bool status = Convert.ToBoolean(root.XPathSelectElement("//status").Value);
            if (!status)
            {
                string errorCode = root.XPathSelectElement("//error/message").Value;
                string errorType = root.XPathSelectElement("//error/type").Value;
                return new AnonFile(input, status, errorCode, errorType);
            }
            else
            {
                string urlfull = root.XPathSelectElement("//url/full").Value;
                string urlshort = root.XPathSelectElement("//url/short").Value;
                uint size = Convert.ToUInt32(root.XPathSelectElement("//metadata/size/bytes").Value);
                return new AnonFile(input, status, urlfull, urlshort, size);
            }
        }

        /// <summary>
        ///     Dispose the webclient.
        /// </summary>
        public void Dispose()
        {
            client.Dispose();
        }
    }
}
