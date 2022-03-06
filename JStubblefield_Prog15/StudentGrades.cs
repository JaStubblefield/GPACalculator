/*Jason Stubblefield
 * Program 15, Due 5/1/18
 * Partner names: None
 * Description: This instance class does most of the work for the driver class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace JStubblefield_Prog15
{
    public class StudentGrades
    {
        private char[][] grades;
        private double totalGpa;
        private int totalClasses;
        private int semesters;

        public int Semesters
        {
            get
            {
                return semesters;
            }
            set
            {
                semesters = value;
            }
        }

        public double TotalGpa
        {
            get
            {
                return totalGpa;
            }
            set
            {
                totalGpa = value;
            }
        }

        public StudentGrades()
        {
            totalClasses = 0;
            SetSemesters(4);
            grades = new char[semesters][];
        }

        public void SetSemesters(int semest)
        {
            if (semest < 1)
            {
                WriteLine("Error. Default to zero.");
                semesters = 0;
            }
            else
            {
                semesters = semest;
            }
        }

        public void InputSemesters()
        {
            int numClasses = 0;
            for (int r = 0; r < grades.Length; r++)
            {
                while (true)
                {
                    Write("How many courses were taken semester {0}:  ", r + 1);
                    try
                    {
                        numClasses = int.Parse(ReadLine());
                        CreateSemesters(r, numClasses);
                        break;
                    }
                    catch (Exception e)
                    {
                        WriteLine("Problem with input.");
                        Error.WriteLine(e.Message);
                        WriteLine("Try again.");
                    }
                }
            }
        }

        public void CreateSemesters(int sem, int numClasses)
        {
            grades[sem] = new char[numClasses];
            totalClasses += numClasses;
        }

        public void EnterGrades()
        {
            for (int r = 0; r < grades.Length; r++)
            {
                for (int c = 0; c < grades[r].Length; c++)
                {
                    while (true)
                    {
                        Write("Enter the letter grade for class {0} of semester {1}:  ", c + 1, r + 1);
                        try
                        {
                            grades[r][c] = char.Parse(ReadLine());
                            CheckLetterGrade(grades[r][c]);
                            break;
                        }
                        catch (FormatException e)
                        {
                            WriteLine("That is not a character. Try again.");
                            Error.WriteLine(e.Message);
                        }
                        catch (IncorrectLetterGradeException e)
                        {
                            WriteLine("That is not an acceptable letter grade. Try again.");
                            Error.WriteLine(e.Message);
                        }
                    }
                }
            }
        }

        public void CheckLetterGrade(char G)
        {
            if (G != 'A' &&
                G != 'B' &&
                G != 'C' &&
                G != 'D' &&
                G != 'F')
            {
                IncorrectLetterGradeException badLetter = new
                    IncorrectLetterGradeException("Not an acceptable letter grade of A-D or F");
                throw badLetter;
            }
        }

        public double SemesterGpa(int semest)
        {
            double sum = 0;
            foreach (char grade in grades[semest])
            {
                switch (grade)
                {
                    case 'A':
                        sum += 4;
                        break;
                    case 'B':
                        sum += 3;
                        break;
                    case 'C':
                        sum += 2;
                        break;
                    case 'D':
                        sum += 1;
                        break;
                    default:
                        break;
                }
            }

            try
            {
                return CalcGpa(sum, grades[semest].Length);
            }
            catch (FloatingPtDivideByZeroException e)
            {
                Error.WriteLine(e.Message);
                WriteLine("Student must take a class before semester GPA can be calculated.");
                return 0;
            }
        }

        public void CumGpa()
        {
            double sum = 0;
            for (int r = 0; r < grades.Length; r++)
            {
                for (int c = 0; c < grades[r].Length; c++)
                {
                    switch (grades[r][c])
                    {
                        case 'A':
                            sum += 4;
                            break;
                        case 'B':
                            sum += 3;
                            break;
                        case 'C':
                            sum += 2;
                            break;
                        case 'D':
                            sum += 1;
                            break;
                        default:
                            break;
                    }
                }
            }

            try
            {
                totalGpa = CalcGpa(sum, totalClasses);
            }
            catch (FloatingPtDivideByZeroException e)
            {
                totalGpa = 0;
                Error.WriteLine(e.Message);
                WriteLine("Student must take a class before cumulative GPA can be calculated.");
            }
        }

        public double CalcGpa(double total, int classes)
        {
            if (classes < 1)
            {
                FloatingPtDivideByZeroException badNum = new
                    FloatingPtDivideByZeroException("Exception Type: Dividing by zero");
                throw badNum;
            }
            return total / classes;
        }

        public override string ToString()
        {
            string result = "Student's grades are:\n";
            for (int r = 0; r < grades.Length; r++)
            {
                result += string.Format("Semester {0}:  ", r + 1);
                for (int c = 0; c < grades[r].Length; c++)
                {
                    result += string.Format("{0} ", grades[r][c]);
                }
                result += "\n";
            }
            return result;
        }
    }
}
