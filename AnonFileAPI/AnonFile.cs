using System;

namespace AnonFileAPI
{
    public class AnonFile
    {
        public string Response { get; private set; }
        public bool Status { get; private set; }
        public string FullUrl { get; private set; }
        public string ShortUrl { get; private set; }
        public uint Size { get; private set; }
        public uint ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }
        public string ErrorType { get; private set; }

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
        /// <param name="shortUrl"></param>
        /// <param name="size"></param>
        public AnonFile(string response, bool status, string urlfull, string shortUrl, uint size)
        {
            this.Response = response;
            this.Status = status;
            this.FullUrl = urlfull;
            this.ShortUrl = shortUrl;
            this.Size = size;
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
            this.Response = response;
            this.Status = status;
            this.ErrorCode = errorCode;
            this.ErrorType = errorType;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        ///     Return the full URL (basically URL + file name and extension).
        /// </summary>
        /// <returns> Full URL. </returns>
        [Obsolete("Setters and Getters were seen as redudant, please consider using the properties!")]
        public string GetFullUrl()
        {
            return FullUrl;
        }

        /// <summary>
        ///     Return the short URL.
        /// </summary>
        /// <returns> Short URL. </returns>
        [Obsolete("Setters and Getters were seen as redudant, please consider using the properties!")]
        public string GetShortUrl()
        {
            return ShortUrl;
        }

        /// <summary>
        ///     Return the amount of bytes in the file. If file upload failed, will return 0.
        /// </summary>
        /// <returns> Amount of Bytes. </returns>
        [Obsolete("Setters and Getters were seen as redudant, please consider using the properties!")]
        public uint GetAmountOfBytes()
        {
            return Size;
        }

        /// <summary>
        ///     Return the status of the upload.
        /// </summary>
        /// <returns> Status. </returns>
        [Obsolete("Setters and Getters were seen as redudant, please consider using the properties!")]
        public bool IsGoodResponse()
        {
            return Status;
        }

        /// <summary>
        ///     Return the entire raw JSON.
        /// </summary>
        /// <returns> raw JSON. </returns>
        [Obsolete("Setters and Getters were seen as redudant, please consider using the properties!")]
        public string GetFullResponse()
        {
            return Response;
        }

        /// <summary>
        ///     Return the error message. If there is no error, this will return null.
        /// </summary>
        /// <returns> Error Message. </returns>
        [Obsolete("Setters and Getters were seen as redudant, please consider using the properties!")]
        public string GetErrorMessage()
        {
            return ErrorMessage;
        }

        /// <summary>
        ///     Return the errorcode code. Is 0 if none.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Setters and Getters were seen as redudant, please consider using the properties!")]
        public uint GetErrorCode()
        {
            return ErrorCode;
        }

        /// <summary>
        ///     Return the error type. If there is no error, this will return null.
        /// </summary>
        /// <returns> Error Type. </returns>
        [Obsolete("Setters and Getters were seen as redudant, please consider using the properties!")]
        public string GetErrorType()
        {
            return ErrorType;
        }

        /// <summary>
        ///     Return the full raw JSON.
        /// </summary>
        /// <returns> Raw JSON. </returns>
        public override string ToString()
        {
            return Response;
        }
    }
}
