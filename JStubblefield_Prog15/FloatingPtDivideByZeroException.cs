/*Jason Stubblefield
 * Program 15, Due 5/1/18
 * Partner names: None
 * Description: Used by the instance class to print an error message when zero classes are taken
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JStubblefield_Prog15
{
    public class FloatingPtDivideByZeroException : ApplicationException
    {
        public FloatingPtDivideByZeroException(string message) : base(message)
        {

        }
    }
}
