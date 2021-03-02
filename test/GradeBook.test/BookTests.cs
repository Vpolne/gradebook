using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();
            //assert
            Assert.Equal(85.6,result.Average,1);
            Assert.Equal(90.5,result.High,1);
            Assert.Equal(77.3,result.Low,1);
            Assert.Equal('B',result.Letter);
        }
        [Fact]
        public void GradesAreInCorrectRange()
        {
            var book = new Book("Test book");
            book.AddGrade(105);
            book.AddGrade(50);
            book.AddGrade(-5);
            List<double> grades = book.GetGrades();
            Assert.DoesNotContain(105,grades);
            Assert.DoesNotContain(-5,grades);
            Assert.Contains(50,grades);
        }
        
    }
}
