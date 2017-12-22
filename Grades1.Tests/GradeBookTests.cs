using GradeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Grades1.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBooks book = new GradeBooks();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(90,result.HighestGrade);
        }
        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBooks book = new GradeBooks();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(10, result.LowestGrade);
        }

        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBooks book = new GradeBooks();

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(85.16, result.AverageGrade,0.01);
        }

    }
}
