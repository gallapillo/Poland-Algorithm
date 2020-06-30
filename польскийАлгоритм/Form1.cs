using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace польский_Алгоритм
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            String func = FunctionTextBox.Text;

            List<string> arguments = new List<string>();
            string operand1 = "";
            string operand2 = "";
            string lastOperation = "";
            List<string> operations = new List<string> { "+", "-", "*", "/", "^" };

            int symbolNumber = 0;
            String sourceExpression = FunctionTextBox.Text.Replace(" ", "");

            while (symbolNumber < sourceExpression.Length)
            {
                int currentIndex = arguments.Count - 1;

                
                if (operations.Contains(sourceExpression[symbolNumber].ToString()))
                {
                    
                    arguments.Add(lastOperation.ToString());
                    while ( operations.Contains(arguments[currentIndex]) && operations.IndexOf(sourceExpression[symbolNumber].ToString()) > operations.IndexOf(arguments[currentIndex]))
                    {
                        arguments[currentIndex + 1] = arguments[currentIndex];
                        currentIndex--;
                    }

                    arguments[currentIndex + 1] = sourceExpression[symbolNumber].ToString();

                    lastOperation = sourceExpression[symbolNumber].ToString();
                    symbolNumber++;
                }
               
                else if (operand1 == "")
                {
                    while (symbolNumber < sourceExpression.Length && !operations.Contains(sourceExpression[symbolNumber].ToString()))
                    {
                        operand1 += sourceExpression[symbolNumber];
                        symbolNumber++;
                    }

                    arguments.Add(operand1);
                    operand2 = "";
                }
              
                else if (operand2 == "")
                {
                    while (symbolNumber < sourceExpression.Length &&
                        !operations.Contains(sourceExpression[symbolNumber].ToString()))
                    {
                        operand2 += sourceExpression[symbolNumber];
                        symbolNumber++;
                    }

                    int index = arguments.LastIndexOf(lastOperation.ToString());
                    arguments.Add(operand2);

                    currentIndex = arguments.Count - 1;
                    while (currentIndex > index)
                    {
                        arguments[currentIndex] = arguments[currentIndex - 1];
                        currentIndex--;
                    }

                    arguments[index] = operand2;
                    operand2 = "";
                }

                ResultTextBox.Text += String.Join(",", arguments.ToArray()) + Environment.NewLine;
            }

            DiffTextBox.Text = String.Join(",", arguments);

        
            while (arguments.Count > 1)
            {
                String firstOper = "";
                int firstOperIndex = arguments.Count;
                foreach (String str in operations)
                {
                    if (arguments.IndexOf(str) > 0 && arguments.IndexOf(str) < firstOperIndex)
                    {
                        firstOperIndex = arguments.IndexOf(str);
                        firstOper = str;
                    }
                }

                String f1 = "", f2 = "",  oper = "",  diff = "";


                f1 = arguments[firstOperIndex - 2];
                f2 = arguments[firstOperIndex - 1];
                oper = arguments[firstOperIndex];
                diff = Calc(f1, f2, oper);

                arguments.RemoveAt(firstOperIndex);
                arguments.RemoveAt(firstOperIndex - 1);
                arguments[firstOperIndex - 2] = diff;

                DiffTextBox.Text += Environment.NewLine + String.Join(",", arguments.ToArray());
            }
        }

        String Calc(String v1, String v2, String oper)
        {
            String value = "";
            if (oper == "+")
            {
                value = (Convert.ToInt32(v1) + Convert.ToInt32(v2)).ToString();
            }
            else if (oper == "-")
            {
                value = (Convert.ToInt32(v1) - Convert.ToInt32(v2)).ToString();
            }
            else if (oper == "*")
            {
                value = (Convert.ToInt32(v1) * Convert.ToInt32(v2)).ToString();
            }
            else if (oper == "/")
            {
                value = (Convert.ToInt32(v1) / Convert.ToInt32(v2)).ToString();
            }
            else if (oper == "^")
            {
                value = (Math.Pow(Convert.ToInt32(v1), Convert.ToInt32(v2))).ToString();
            }

            return value;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DiffTextBox.Clear();
            ResultTextBox.Clear();
        }
    }
}
