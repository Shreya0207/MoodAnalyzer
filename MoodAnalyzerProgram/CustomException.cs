using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProgram
{
    public class CustomException : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            NO_SUCH_CLASS,
            NO_SUCH_METHOD,
            NO_SUCH_FIELD
        }
        private readonly ExceptionType type;
        public CustomException(ExceptionType type, String message) : base(message)
        {
            this.type = type;
        }
    }
}
   
