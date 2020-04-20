using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_14
{
    class Program
    {
        delegate T Operation<T, K, O>(O val1, K val2);

        static T Plus<T>(T val1, T val2)
        {
            return (dynamic)val1 + (dynamic)val2;
        }

        static T Minus<T>(T val1, T val2)
        {
            return (dynamic)val1 - (dynamic)val2;
        }

        static T Multiplication<T>(T val1, T val2)
        {
            return (dynamic)val1 * (dynamic)val2;
        }

        static T Division<T>(T val1, T val2)
        {
            if((dynamic)val2 == 0)
                throw new DivideByZeroException();
            else
                return (dynamic)val1 / (dynamic)val2;
        }

        static void Main(string[] args)
        {
            List<string> operands = new List<string>(); 
            List<char> operators = new List<char>(); 
            Operation<double, double, double>[] operations = new Operation<double, double, double>[]{};
            Console.WriteLine("Calculator.\n\tUsing: Enter the first number, then Enter (+, -, /, *), after that Enter the second number, after pushing key Enter, you can repeat the operation, for Conclusioning the answers of operation Enter: Conclusion.");
            Console.WriteLine($"\n{new string('-', 35)}\n");
            string cmd = string.Empty;
            int arraySize = 0;
            while(cmd != "Conclusion")
            {
                cmd = Console.ReadLine();
                if(cmd != "Conclusion")
                {
                    Regex _regex = new Regex(@"^(?<oper1>\d+)(?<symb>.)(?<oper2>\d+)"); // Использование регулярных выражений для разделения строки введенной пользователем на числа и символ оператора
                    double A = 0.0; 
                    double B = 0.0; 
                    char operatorChr = '-'; 
                    foreach(Match _m in _regex.Matches(cmd))
                    {
                        A = double.Parse(_m.Groups["oper1"].ToString().Replace('.', ','));
                        B = double.Parse(_m.Groups["oper2"].ToString().Replace('.', ','));
                        operatorChr = Convert.ToChar(_m.Groups["symb"].ToString());
                        if(operatorChr == '+')
                        {
                            arraySize++;
                            Array.Resize(ref operations, arraySize);
                            operations[operations.Length - 1] = new Operation<double, double, double> (Plus);
                        }
                        else if(operatorChr == '-')
                        {
                            arraySize++;
                            Array.Resize(ref operations, arraySize);
                            operations[operations.Length - 1] = new Operation<double, double, double> (Minus);
                        }
                        else if(operatorChr == '/')
                        {
                            arraySize++;
                            Array.Resize(ref operations, arraySize);
                            operations[operations.Length - 1] = new Operation<double, double, double> (Division);
                        }
                        else if(operatorChr == '*')
                        {
                            arraySize++;
                            Array.Resize(ref operations, arraySize);
                            operations[operations.Length - 1] = new Operation<double, double, double> (Multiplication);
                        }
                    }
                    string operandsStr = string.Join('|', A ,B);
                    operands.Add(operandsStr);
                    operators.Add(operatorChr);
                }
            }
        }
    }
}


