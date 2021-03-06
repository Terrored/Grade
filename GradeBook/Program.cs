﻿using System;
using System.Collections.Generic;
using System.IO;
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
            IGradeTracker book = CreateGradeBook();
            GetBookName(book);
            AddGrades(book);

            SaveGrades(book);

            WriteResults(book);


            // SpeechSynthesizer synth = new SpeechSynthesizer();
            // synth.Speak("No witam wszystkich!");
        }

        private static IGradeTracker CreateGradeBook()
        {
           

            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult("Description", stats.Description);
            Console.ReadKey();
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);

            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(78);
            book.AddGrade(68);
            book.AddGrade(92);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                //Console.WriteLine("Enter a name");
                //book.Name = Console.ReadLine();
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong!");

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wronggg");

            }
        }

        static void OnNameChanged(object sender , NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + ": " + result);
        }
        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }
    }
}
