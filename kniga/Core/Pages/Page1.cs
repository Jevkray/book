using kniga.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.Core.Pages
{
    public static class StartPage  
    {
        static string InputValue(string inputMessage)
        {
            Console.Write(inputMessage);
            string value = Console.ReadLine();
            return value;
        }
        public static void Run(User user)
        {
            //Страница привествия
            
            user.Name = InputValue("Введите ваше имя: ");
            Console.Clear();

            do // do .. while - выступает в качестве возвращения в начало , в случае ошибки
            {
                user.Age = Functions.CoreFunctions.ParseToIntPositiveNumber(InputValue("Введите возраст персонажа: "));
            }
            while (user.Age == 0);

            Console.Clear();

            user.Print();

            Console.ReadKey();
            Console.Clear();
            
        }
    }
}
