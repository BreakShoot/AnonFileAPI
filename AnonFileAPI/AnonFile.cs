using System;

namespace AnonFileAPI
{
    public class AnonFile
    {
        private readonly string _response     = null;
        private readonly bool _status         = false;
        private readonly string _urlfull      = null;
        private readonly string _urlshort     = null;
        private readonly uint _size           = 0;
        private readonly uint _errorCode      = 0;
        private readonly string _errorMessage = null;
        private readonly string _errorType    = null;

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
            this._response = response;
            this._status = status;
            this._urlfull = urlfull;
            this._urlshort = urlshort;
            this._size = size;
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
            this._response = response;
            this._status = status;
            this._errorCode = errorCode;
            this._errorType = errorType;
            this._errorMessage = errorMessage;
        }

        /// <summary>
        ///     Return the full URL (basically URL + file name and extension).
        /// </summary>
        /// <returns> Full URL. </returns>
        public string GetFullUrl()
        {
            return _urlfull;
        }

        /// <summary>
        ///     Return the short URL.
        /// </summary>
        /// <returns> Short URL. </returns>
        public string GetShortUrl()
        {
            return _urlshort;
        }

        /// <summary>
        ///     Return the amount of bytes in the file. If file upload failed, will return 0.
        /// </summary>
        /// <returns> Amount of Bytes. </returns>
        public uint GetAmountOfBytes()
        {
            return _size;
        }

        /// <summary>
        ///     Return the status of the upload.
        /// </summary>
        /// <returns> Status. </returns>
        public bool IsGoodResponse()
        {
            return _status;
        }

        /// <summary>
        ///     Return the entire raw JSON.
        /// </summary>
        /// <returns> raw JSON. </returns>
        public string GetFullResponse()
        {
            return _response;
        }

        /// <summary>
        ///     Return the error message. If there is no error, this will return null.
        /// </summary>
        /// <returns> Error Message. </returns>
        public string GetErrorMessage()
        {
            return _errorMessage;
        }

        /// <summary>
        ///     Return the errorcode code. Is 0 if none.
        /// </summary>
        /// <returns></returns>
        public uint GetErrorCode()
        {
            return _errorCode;
        }

        /// <summary>
        ///     Return the error type. If there is no error, this will return null.
        /// </summary>
        /// <returns> Error Type. </returns>
        public string GetErrorType()
        {
            return _errorType;
        }

        /// <summary>
        ///     Return the full raw JSON.
        /// </summary>
        /// <returns> Raw JSON. </returns>
        public override string ToString()
        {
            return _response;
        }
    }
}
