using System;

namespace Лб3
{
    class Parser
    {
        private string input;
        private char[] arrInput;

        private decimal leftOperand;
        private decimal rightOperand;
        private char operat;

        private bool stop = false;

        private void Input()
        {
            input = Console.ReadLine();
            input = input
                .Replace(" ", "")
                .Replace(",", ".")
                .Replace("=", "");
            arrInput = input.ToCharArray();
        }
        private static decimal ParseDecimal(string s)
        {
            return decimal.Parse(
                s,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.InvariantCulture
            );
        }

        private bool OperatorFind()
        {
            if (arrInput.Length != 0)
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == '+' || arrInput[i] == '-' || arrInput[i] == '*' || arrInput[i] == '/')
                    {
                        operat = arrInput[i];
                        return true;
                    }
                }
            }

            return false;
        }

        private void ParseLeftOperand()
        {
            string firstOperand = "";
            OperatorFind();

            if (arrInput.Length != 0)
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == operat)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            firstOperand += arrInput[j];
                        }
                    }
                }

                if (OperatorFind() == false)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        firstOperand += arrInput[i];
                    }
                }
            }

            if (firstOperand != "")
            {
                try
                {
                    leftOperand = ParseDecimal(firstOperand);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Перше число введено не правильно");
                    stop = true;
                }
            }
        }

        private void ParseRightOperand()
        {
            string secondOperand = "";
            if (OperatorFind() == false)  // если знак операции еще не введен
            {
                Input();
                OperatorFind();
                bool o = false;
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == operat)
                    {
                        o = true;
                    }
                }
                if (OperatorFind() == true && o == true)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        if (arrInput[i] == operat)
                        {
                            for (int j = i + 1; j < arrInput.Length; j++)
                            {
                                secondOperand += arrInput[j];
                            }
                        }
                    }
                }

                if (secondOperand == "" && OperatorFind() == true)
                {
                    Input();
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        secondOperand += arrInput[i];
                    }
                }
            }
            else if (OperatorFind() == true)
            {
                bool o = false;
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == operat)
                    {
                        o = true;
                    }
                }

                if (o == true)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        if (arrInput[i] == operat)
                        {
                            for (int j = i + 1; j < arrInput.Length; j++)
                            {
                                secondOperand += arrInput[j];
                            }
                        }
                    }
                }

                if (secondOperand == "")
                {
                    Input();
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        secondOperand += arrInput[i];
                    }
                }
            }


            if (secondOperand != "")
            {
                try
                {
                    rightOperand = ParseDecimal(secondOperand);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Друге число введено не правильно");
                    stop = true;
                }
            }

        }

        public void Parse()
        {
            Input();
            ParseLeftOperand();
            ParseRightOperand();
        }

        public void GetResult()
        {
            decimal result;

            if (stop == false)
            {
                if (operat == '+')
                {
                    Calculator calculator = new Calculator();
                    result = calculator.Add(leftOperand, rightOperand);
                }
                else if (operat == '-')
                {
                    Calculator calculator = new Calculator();
                    result = calculator.Substract(leftOperand, rightOperand);
                }
                else if (operat == '*')
                {
                    Calculator calculator = new Calculator();
                    result = calculator.Multiply(leftOperand, rightOperand);
                }
                else
                {
                    Calculator calculator = new Calculator();
                    result = calculator.Division(leftOperand, rightOperand);
                }
                
                Console.WriteLine($"{leftOperand} {operat} {rightOperand} = {result}");
            }
        }

        public void Instruction()
        {
            Console.WriteLine("Інструкція: ");
            Console.WriteLine();
            Console.WriteLine("Введіть математичний приклад, який складається з двух чисел і знаком дії між цими числами.");
            Console.WriteLine("Приклад може бути введений частинами.");
            Console.WriteLine("Пробіли та знаки рівності ігноруються.");
            Console.WriteLine();
            Console.WriteLine("Можливі операції над числами: \nМноження (*), \nДілення (/), \nДодавання (+), \nВіднімання (-).");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
