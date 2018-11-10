using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class ExceptionMesseges
    {
        public static string FirstNameCapitalLetter => "Expected upper case letter! Argument: firstName";
        public static string FirstNameLength => "Expected length at least 4 symbols! Argument: firstName";
        public static string LastNameCapitalLetter => "Expected upper case letter! Argument: lastName";
        public static string LastNameLength => "Expected length at least 3 symbols! Argument: lastName ";
        public static string FacultyNumberRange => "Invalid faculty number!";
        public static string WeekSalaryAmount => "Expected value mismatch! Argument: weekSalary";
        public static string WorkHoursRange => "Expected value mismatch! Argument: workHoursPerDay";
    }
}
