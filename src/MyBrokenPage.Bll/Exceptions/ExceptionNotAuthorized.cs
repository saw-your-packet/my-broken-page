using System;

namespace MyBrokenPage.Bll.Exceptions
{
    class ExceptionNotAuthorized : Exception
    {
        public ExceptionNotAuthorized() : base() { }
        public ExceptionNotAuthorized(string message) : base(message) { }
    }
}
