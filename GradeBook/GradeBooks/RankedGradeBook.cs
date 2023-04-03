using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var gradeList = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            return averageGrade >= gradeList[(int)Math.Ceiling(Students.Count * 0.2) - 1] ? 'A'
                 : averageGrade >= gradeList[(int)Math.Ceiling(Students.Count * 0.4) - 1] ? 'B'
                 : averageGrade >= gradeList[(int)Math.Ceiling(Students.Count * 0.6) - 1] ? 'C'
                 : averageGrade >= gradeList[(int)Math.Ceiling(Students.Count * 0.8) - 1] ? 'D'
                 : 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else if (Students.Count >= 5)
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else if (Students.Count >= 5)
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
