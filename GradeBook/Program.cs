using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
           // SpeechSynthesizer synth = new SpeechSynthesizer();
           // synth.Speak("No witam wszystkich!");

            GradeBooks book = new GradeBooks();

            book.AddGrade(78);
            book.AddGrade(68);
            book.AddGrade(92);
            
            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.AverageGrade);

            Console.ReadKey();
        }
    }
}
