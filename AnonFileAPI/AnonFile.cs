namespace AnonFileAPI
{
    public class AnonFile
    {
        private string response     = null;
        private bool status         = false;
        private string urlfull      = null;
        private string urlshort     = null;
        private uint size           = 0;
        private string errorCode    = null;
        private string errorType    = null;

        /// <summary>
        ///     Used to return a successful AnonFile. Should NOT be initialized by user but instead AnonFileWrapper. 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="status"></param>
        /// <param name="urlfull"></param>
        /// <param name="urlshort"></param>
        /// <param name="size"></param>
        public AnonFile(string response, bool status, string urlfull, string urlshort, uint size)
        {
            this.response = response;
            this.status = status;
            this.urlfull = urlfull;
            this.urlshort = urlshort;
            this.size = size;
        }

        /// <summary>
        ///     Used to return an error-filled AnonFile. Should NOT be initialized by user but instead AnonFileWrapper.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="status"></param>
        /// <param name="errorCode"></param>
        /// <param name="errorType"></param>
        public AnonFile(string response, bool status, string errorCode, string errorType)
        {
            this.response = response;
            this.status = status;
            this.errorCode = errorCode;
            this.errorType = errorType;
        }

        /// <summary>
        ///     Return the full URL (basically URL + file name and extension).
        /// </summary>
        /// <returns> Full URL. </returns>
        public string GetFullURL()
        {
            return urlfull;
        }

        /// <summary>
        ///     Return the short URL.
        /// </summary>
        /// <returns> Short URL. </returns>
        public string GetShortURL()
        {
            return urlshort;
        }

        /// <summary>
        ///     Return the amount of bytes in the file. If file upload failed, will return 0.
        /// </summary>
        /// <returns> Amount of Bytes. </returns>
        public uint GetAmountOfBytes()
        {
            return size;
        }

        /// <summary>
        ///     Return the status of the upload.
        /// </summary>
        /// <returns> Status. </returns>
        public bool IsGoodResponse()
        {
            return status;
        }

        /// <summary>
        ///     Return the entire raw JSON.
        /// </summary>
        /// <returns> raw JSON. </returns>
        public string GetFullResponse()
        {
            return response;
        }

        /// <summary>
        ///     Return the error message. If there is no error, this will return null.
        /// </summary>
        /// <returns> Error Code. </returns>
        public string GetErrorMessage()
        {
            return errorCode;
        }

        /// <summary>
        ///     Return the error type. If there is no error, this will return null.
        /// </summary>
        /// <returns> Error Type. </returns>
        public string GetErrorType()
        {
            return errorType;
        }

        /// <summary>
        ///     Return the full raw JSON.
        /// </summary>
        /// <returns> Raw JSON. </returns>
        public override string ToString()
        {
            return response;
        }
    }
}
