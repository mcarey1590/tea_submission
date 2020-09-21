using System.Collections.Generic;
using student_api.ViewModels;

namespace student_api.Util
{
    public static class GpaCalculator
    {
        public static decimal Calculate (IEnumerable<StudentCourseGrade> grades)
        {
            int totalCredits = 0;
            decimal totalScore = 0;
            foreach(var grade in grades) {
                totalCredits += grade.Credits;
                totalScore += grade.Grade.Value * grade.Credits;
            }
            return decimal.Round(totalScore / totalCredits, 2);
        }
    }
}
