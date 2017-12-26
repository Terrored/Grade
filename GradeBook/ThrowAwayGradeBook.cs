using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class ThrowAwayGradeBook : GradeBooks
    {
        public GradeStatistics ComputeStatistics()
        {
            
            float lowest = float.MaxValue;

            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);

            }
            grades.Remove(lowest);

            return base.ComputeStatistics();


        }
    }
}
