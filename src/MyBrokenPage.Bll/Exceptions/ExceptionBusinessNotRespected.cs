using System;

namespace MyBrokenPage.Bll.Exceptions
{
    public class ExceptionBusinessNotRespected : Exception
    {
        public ExceptionBusinessNotRespected() : base() { }
        public ExceptionBusinessNotRespected(string message) : base(message) { }
    }
}
