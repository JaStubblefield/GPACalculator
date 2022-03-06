/*Jason Stubblefield
 * Program 15, Due 5/1/18
 * Partner names: None
 * Description: This program takes the user's grades for each semester and calculates each semester's GPA and the cumulative GPA.
 *              Then, it prints the user's grades and lets the user request the GPA of each semester individually.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace JStubblefield_Prog15
{
    public class UseStudentGrades
    {
        public static void Main(string[] args)
        {
            StudentGrades stuGrades = new StudentGrades();
            stuGrades.InputSemesters();
            WriteLine();
            stuGrades.EnterGrades();
            WriteLine("\n{0}", stuGrades);
            SingleSemesterGpa(stuGrades);
            WriteLine();
            stuGrades.CumGpa();
            WriteLine(stuGrades);
            WriteLine("Total GPA is:  {0:F2}.\n", stuGrades.TotalGpa);
        }

        public static void SingleSemesterGpa(StudentGrades stuGrades)
        {
            string repeat = "yes";
            int choice = 0;
            while (repeat.ToUpper() == "YES")
            {
                Write("For what semester would you like a GPA?  ");
                int.TryParse(ReadLine(), out choice);
                while (choice < 1 || choice > stuGrades.Semesters)
                {
                    Write("You must enter an integer between 1 and 4. Try again:  ");
                    int.TryParse(ReadLine(), out choice);
                }
                WriteLine("The GPA for semester {0} is {1:F2}.", choice, stuGrades.SemesterGpa(choice - 1));
                Write("Would you like another semester GPA?  ");
                repeat = ReadLine();
            }
        }
    }
}
