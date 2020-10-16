using System;

namespace MoodAnalyzerProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer Program");
            Console.WriteLine("Enter message: ");
            string message = Console.ReadLine();
            MoodAnalyzer checkmood = new MoodAnalyzer(message);
            string result = checkmood.AnalyseMood(message);
            Console.WriteLine(result + " MOOD");
        }
    }
}
