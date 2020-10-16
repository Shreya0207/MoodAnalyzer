using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProgram;

namespace UnitTestMood
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_I_Am_In_Sad_Mood_Should_Return_SAD()
        {
            //Arrange
            string message = "I am in sad mood.";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);
            //Act
            string result = moodAnalyser.AnalyseMood(message);
            //Assert
            Assert.AreEqual("SAD", result);
        }
    }
}
