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
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        public void Given_I_Am_In_Happy_Mood_Should_Return_HAPPY()
        {
            //Arrange
            string message = "I am in happy mood.";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual("HAPPY", result);
        }
        //Removed TC2.1 Given_Null_Should_Return_HAPPY() because now null mood will throw custom exception
        [TestMethod]
        public void Given_Null_Mood_Should_Throw_MoodAnalysisException_Indicating_Null_Mood()
        {
            try
            {
                //Arrange
                string message = null;
                MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);
                //Act
                string result = moodAnalyser.AnalyseMood();
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("Mood should not be null.", e.Message);
            }
        }
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_Empty_Mood()
        {
            try
            {
                //Arrange
                string message = "";
                MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);
                //Act
                string result = moodAnalyser.AnalyseMood();
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("Mood should not be empty.", e.Message);
            }
        }
        //TC 4.1
        [TestMethod]
        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object()
        {
            //Arrange
            string className = "MoodAnalyzerProgram.MoodAnalyzer";
            string constructorName = "MoodAnalyzer";
            //Act
            MoodAnalyzer expected = new MoodAnalyzer();
            object resultObj = MoodAnalyzerFactory.CreateMoodAnalyserObject(className, constructorName);
            //Assert
            expected.Equals(resultObj);
        }
        //TC 4.2
        [TestMethod]
        public void Given_Improper_Class_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Class()
        {
            try
            {
                //Arrange
                string className = "WrongNamespace.MoodAnalyzer";
                string constructorName = "MoodAnalyzer";
                //Act
                object resultObj = MoodAnalyzerFactory.CreateMoodAnalyserObject(className, constructorName);
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("class not found.", e.Message);
            }
        }
        //TC4.3
        [TestMethod]
        public void Given_Improper_Constructor_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Constructor()
        {
            try
            {
                //Arrange
                string className = "MoodAnalyzerProgram.MoodAnalyzer";
                string constructorName = "WrongConstructorName";
                //Act
                object resultObj = MoodAnalyzerFactory.CreateMoodAnalyserObject(className, constructorName);
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("constructor not found.", e.Message);
            }
        }
        //TC5.1
        [TestMethod]
        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object_Using_Parametrized_Constructor()
        {
            //Arrange
            string className = "MoodAnalyzerProgram.MoodAnalyzer";
            string constructorName = "MoodAnalyzer";
            MoodAnalyzer expectedObj = new MoodAnalyzer("HAPPY");
            //Act
            object resultObj = MoodAnalyzerFactory.CreateMoodAnalyserUsingParameterizedConstructor(className, constructorName, "HAPPY");
            //Assert
            expectedObj.Equals(resultObj);
        }
        //TC5.2
        [TestMethod]
        public void Given_Improper_Class_Name_Should_Throw_MoodAnalysisException_For_Parameterized_Constructor()
        {
            try
            {
                //Arrange
                string className = "WrongNameSpace.MoodAnalyzer";
                string constructorName = "MoodAnalyzer";
                MoodAnalyzer expectedObj = new MoodAnalyzer("HAPPY");
                //Act
                object resultObj = MoodAnalyzerFactory.CreateMoodAnalyserUsingParameterizedConstructor(className, constructorName, "HAPPY");
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("class not found.", e.Message);
            }
        }
        //TC5.3
        [TestMethod]
        public void Given_Improper_Constructor_Name_Should_Throw_MoodAnalysisException_For_Parameterized_Constructor()
        {
            try
            {
                //Arrange
                string className = "MoodAnalyzerProgram.MoodAnalyzer";
                string constructorName = "WrongConstructorName";
                MoodAnalyzer expectedObj = new MoodAnalyzer("HAPPY");
                //Act
                object resultObj = MoodAnalyzerFactory.CreateMoodAnalyserUsingParameterizedConstructor(className, constructorName, "HAPPY");
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("constructor is not found.", e.Message);
            }
        }
        //TC6.1
        [TestMethod]
        public void Given_Happy_Message_Using_Reflection_When_Proper_Should_Return_Happy()
        {
            //Arrange
            string message = "HAPPY";
            string methodName = "AnalyseMood";
            //Act
            string actual = MoodAnalyzerFactory.InvokeAnalyseMood(message, methodName);
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }
        //TC6.2
        [TestMethod]
        public void Given_Improper_Method_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Method()
        {
            try
            {
                //Arrange
                string message = "HAPPY";
                string methodName = "WrongMethodName";
                //Act
                string actual = MoodAnalyzerFactory.InvokeAnalyseMood(message, methodName);
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("no such method.", e.Message);
            }
        }
        //TC7.1
        [TestMethod]
        public void Given_Happy_Message_With_Reflection_Should_Return_Happy()
        {
            //Arrange
            string message = "HAPPY";
            string fieldName = "message";
            //Act
            string actual = MoodAnalyzerFactory.SetField(message, fieldName);
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }
        //TC7.2
        [TestMethod]
        public void Given_Improper_Field_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Field()
        {
            try
            {
                //Arrange
                string message = "HAPPY";
                string fieldName = "wrongName";
                //Act
                string actual = MoodAnalyzerFactory.SetField(message, fieldName);
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("no such field found.", e.Message);
            }
        }
        //TC7.3
        [TestMethod]
        public void Given_Null_Message_Should_Throw_MoodAnalysisException_Indicating_Null_Message()
        {
            try
            {
                //Arrange
                string message = null;
                string fieldName = "message";
                //Act
                string actual = MoodAnalyzerFactory.SetField(message, fieldName);
            }
            catch (CustomException e)
            {
                //Assert
                Assert.AreEqual("message should not be null.", e.Message);
            }
        }
    }
}
