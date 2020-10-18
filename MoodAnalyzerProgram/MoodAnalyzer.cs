using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyzer
    {
        public string message;
        public MoodAnalyzer()
        {

        }
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new CustomException(CustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty.");
                }
                if (this.message.Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null.");
            }
        }
    }
}


