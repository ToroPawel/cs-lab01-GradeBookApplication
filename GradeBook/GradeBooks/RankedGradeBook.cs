using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            int numberOfStudents = Students.Count;
            if (numberOfStudents < 5)
                throw new InvalidOperationException();

            int betterStudents = 0;
            foreach (Student student in Students)
            {
                if (student.AverageGrade > averageGrade)
                    betterStudents++;
            }

            double percentage = (100 * betterStudents) / numberOfStudents;


            if (percentage < 20)
                return 'A';
            else if (percentage < 40)
                return 'B';
            else if (percentage < 60)
                return 'C';
            else if (percentage < 80)
                return 'D';
            else
                return 'F';
        }
    }
}
