using System;

namespace AnonFileAPI
{
    class AnonFileException : Exception
    {
        public AnonFileException() { }
        public AnonFileException(string errormessage) : base(errormessage) { }
    }
}
