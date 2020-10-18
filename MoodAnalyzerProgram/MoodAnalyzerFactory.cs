﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProgram
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyserObject(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "class not found.");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "constructor not found.");
            }
        }
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "constructor is not found.");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "no such class.");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserProblem.MoodAnalyser");
                object moodAnalyserObj = MoodAnalyzerFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyserObj, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "no such method.");
            }
        }
    }
}
    