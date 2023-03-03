using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga;
using kniga.Core.Pages;
using kniga.Helpers.Enums;
using kniga.Heplers;

namespace kniga.Functions
{
    public static class CoreFunctions
    {
        public static string EnterStringValue(string inputMessage)
        {
            Console.Write(inputMessage);
            string value = Console.ReadLine();
            return value;
        }

        public static int EnterIntValue(string message)
        {
            Console.Write(message);
            int value = CoreFunctions.ParseToIntNumber(Console.ReadLine());
            return value;
        }

        public static char EnterCharValue(string inputMessage)
        {
            Console.Write(inputMessage);
            char value = Console.ReadKey().KeyChar;
            return value;
        }

        public static void OutputText(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

        public static double EnterDouble(string message)
        {
            double confirmedNumber;
            bool EnterNumber;

            do
            {
                string number = EnterStringValue(message);
                if (number == "0")
                {
                    EnterNumber = true;
                    confirmedNumber = 0;
                }
                else
                {
                    confirmedNumber = CoreFunctions.ParseToDoubleNumber(number);
                    EnterNumber = true;

                    if (confirmedNumber == 0)
                    {
                        EnterNumber = false;
                    }
                }
            }
            while (!EnterNumber);
            Console.Clear();

            return confirmedNumber;
        }

        public static int ParseToIntPositiveNumber(string input)
        {
            bool result = int.TryParse(input, out int number);
            if (result && number > 0)
            {
                return number;
            }
            else
            {
                ErrorMessagesWriter.ErrorMessage(ErrorType.DefaultError);//формат должен быть static чтобы функция ErrorMessage- работала
                return 0;
            }
        }

        public static int ParseToIntNumber(string input)
        {
            bool result = int.TryParse(input, out int number);
            if (result)
            {
                return number;
            }
            else
            {
                ErrorMessagesWriter.ErrorMessage(ErrorType.DefaultError);
                return 0;
            }
        }

        public static double ParseToDoubleNumber(string input)
        {
            bool result = double.TryParse(input, out double number);
            if (result)
            {
                return number;
            }
            else
            {
                ErrorMessagesWriter.ErrorMessage(ErrorType.DefaultError);
                return 0;
            }
        }
    }
}
