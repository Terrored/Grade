using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class GradeBooks
    {
        protected List<float> grades;
        public GradeBooks()
        {
            grades = new List<float>();

        }

        
        public string Name
        {
            get { return name; }


            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }

                if (name != value  && NameChanged!=null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = name;
                    args.NewName = value;

                    NameChanged(this, args);

                }

                name = value;

            }
        }

        private string name;
        public event NameChangedDelegate NameChanged;
        public GradeStatistics ComputeStatistics()
        {
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

       
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }


        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }

        }
    }
}
