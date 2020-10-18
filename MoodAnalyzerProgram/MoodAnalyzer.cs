using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyzer
    {
        private string message;

        public MoodAnalyzer()
        {
        }

        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyseMood(string mesaage)
        {
            try
            {
                if (this.message.Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch
            {
                //Returning Happy when case of Null exception
                return "HAPPY";
            }

        }
        public string AnalyseMoodLive()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new CustomException(CustomException.ExceptionType.EMPTY_MESSAGE, "mood should not be empty");
                }
                if (this.message.Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_MESSAGE, "mood should not be null");
            }
        }
    }
}


