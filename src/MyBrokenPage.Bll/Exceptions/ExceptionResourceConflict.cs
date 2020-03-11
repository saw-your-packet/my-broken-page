using System;

namespace MyBrokenPage.Bll.Exceptions
{
    public class ExceptionResourceConflict : Exception
    {
        public ExceptionResourceConflict() : base() { }
        public ExceptionResourceConflict(string message) : base(message) { }
    }
}
