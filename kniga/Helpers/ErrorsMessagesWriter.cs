using kniga.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.Heplers
{
    public class ErrorMessagesWriter
    {

        public static void ErrorMessage(ErrorType errorType)
        {
            switch (errorType)
            {
                case ErrorType.DefaultError:
                    Console.WriteLine("Ошибка ввода, повторите попытку");
                    break;
                case ErrorType.TypeError:
                    Console.WriteLine("Ошибка типа вводимого значения, повторите попытку");
                    break;
                case ErrorType.ParseError:
                    Console.WriteLine("Ошибка преобразования вводимого значения, повторите попытку");
                    break;
                case ErrorType.NumberError:
                    Console.WriteLine("Введенное число не соответствует условию, повторите попытку");
                    break;
            }
        }
    }
}