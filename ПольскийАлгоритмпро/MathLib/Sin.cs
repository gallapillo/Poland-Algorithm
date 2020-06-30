using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Польский_Алгоритм_про.MathLib
{
    class Sin
    {
        public static bool IsIt(String func)
        {
            return (func == "sin");
        }

        public static String Diff(String func)
        {
            return "cos";
        }
    }
}
