using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book (string name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            foreach (var grade in grades)
            {
                result.Average+=grade;
                result.High = Math.Max(grade,result.High);
                result.Low = Math.Min(grade,result.Low);   
            }
            result.Average/=grades.Count;
            return result;
        }
        public void ShowStatistics()
        {
            var result = GetStatistics();
            Console.WriteLine($"Average grade is {result.Average:N1}");
            Console.WriteLine($"The highest grade is {result.High:N1}");
            Console.WriteLine($"The lowest grade is {result.Low:N1}");
        }
        private List<double> grades;
        public string Name;
    }
}