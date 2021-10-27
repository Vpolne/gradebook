using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Vpolne Grade Book");
            book.AddGrade(85.5);
            book.AddGrade(90.2);
            book.AddGrade(99.6);
            book.ShowStatistics();
            //test push
        }
    }
}