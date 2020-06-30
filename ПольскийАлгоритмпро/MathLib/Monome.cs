using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Польский_Алгоритм_про.MathLib
{
    class Monome
    {
        public static bool IsIt(String func)
        {
            if (func.Length > 2 && func.Substring(0, 2) == "x^")
            {
                try
                {
                    Convert.ToDouble(func.Substring(2));
                    return true;
                }
                catch (Exception) { }
            }

            return false;
        }

        public static String Diff(String func)
        {
            Double power = Convert.ToDouble(func.Substring(2));
            return power.ToString() + "*x^" + (power - 1).ToString();
        }
    }
}
