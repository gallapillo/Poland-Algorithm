using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Польский_Алгоритм_про.MathLib
{
    class Constant
    {
        public static bool IsIt(String func)
        {
            try
            {
                Convert.ToDouble(func);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static String Diff(String func)
        {
            return "0";
        }
    }
}
