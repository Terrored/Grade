using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class GradeBooks : GradeTracker
    {
        protected List<float> grades;

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        public GradeBooks()
        {
            grades = new List<float>();

        }

        
       
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

       
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }


        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }

        }
    }
}
