using System;

namespace AnonFileAPI
{
    public class AnonFile
    {
        private string response     = null;
        private bool status         = false;
        private string urlfull      = null;
        private string urlshort     = null;
        private uint size           = 0;
        private uint errorCode      = 0;
        private string errorMessage = null;
        private string errorType    = null;

        public static class AnonExceptions
        {
            public const int ERROR_FILE_NOT_PROVIDED = 10;
            public const int ERROR_FILE_EMPTY = 11;
            public const int ERROR_FILE_INVALID = 12;
            public const int ERROR_USER_MAX_FILES_PER_HOUR_REACHED = 20;
            public const int ERROR_USER_MAX_FILES_PER_DAY_REACHED = 21;
            public const int ERROR_USER_MAX_BYTES_PER_HOUR_REACHED = 22;
            public const int ERROR_USER_MAX_BYTES_PER_DAY_REACHED = 23;
            public const int ERROR_FILE_DISALLOWED_TYPE = 30;
            public const int ERROR_FILE_SIZE_EXCEEDED = 31;
            public const int ERROR_FILE_BANNED = 32;
            public const int STATUS_ERROR_SYSTEM_FAILURE = 40;
        }

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
        public AnonFile(string response, bool status, string errorMessage, uint errorCode, string errorType)
        {
            this.response = response;
            this.status = status;
            this.errorCode = errorCode;
            this.errorType = errorType;
            this.errorMessage = errorMessage;
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
        /// <returns> Error Message. </returns>
        public string GetErrorMessage()
        {
            return errorMessage;
        }

        /// <summary>
        ///     Return the errorcode code. Is 0 if none.
        /// </summary>
        /// <returns></returns>
        public uint GetErrorCode()
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
