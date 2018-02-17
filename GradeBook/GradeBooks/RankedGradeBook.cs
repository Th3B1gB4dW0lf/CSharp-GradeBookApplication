using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            //How many students it takes to drop a letter grade
            var dropLetterGrade = Students.Count * 0.2;
            
            //How many students have a lower grade than the actual student
            var betterThan = 0;
            foreach (var item in Students)
            {
                if(averageGrade > item.AverageGrade)
                {
                    betterThan++;
                }
            }

            //Where is our student
            var letterGradeNumber = betterThan / dropLetterGrade;

            switch(letterGradeNumber)
            {
                case 0:
                    return 'F';
                case 1:
                    return 'D';
                case 2:
                    return 'C';
                case 3:
                    return 'B';
                case 4:
                    return 'A';
                default:
                    return 'F';
            }

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
