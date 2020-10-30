using System;

namespace MyBrokenPage.Bll.Exceptions
{
    public class ExceptionResourceNotFound : Exception
    {
        public ExceptionResourceNotFound() : base() { }
        public ExceptionResourceNotFound(string message) : base(message) { }
    }
}
