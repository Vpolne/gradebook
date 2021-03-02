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
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            } 
            else
            {
                System.Console.WriteLine("Invalid value");
            }
            
        }
        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;                
            }
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
                result.Low = Math.Min(grade,result.Low);   
                result.High = Math.Max(grade,result.High);
            }

            result.Average/=grades.Count;
            
            switch(result.Average)
            {
                case var d when d>=90.0:
                    result.Letter = 'A';
                    break;

                case var d when d>=80.0:
                    result.Letter = 'B';
                    break;

                case var d when d>=70.0:
                    result.Letter = 'C';
                    break;

                case var d when d>=60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }
        public void ShowStatistics()
        {
            var result = GetStatistics();
            Console.WriteLine($"Average grade is {result.Average:N1}");
            Console.WriteLine($"The highest grade is {result.High:N1}");
            Console.WriteLine($"The lowest grade is {result.Low:N1}");
            Console.WriteLine($"The letter is {result.Letter}");
        }
        public List<double> GetGrades()
        {
            return this.grades;
        }
        private List<double> grades;
        public string Name;
    }
}