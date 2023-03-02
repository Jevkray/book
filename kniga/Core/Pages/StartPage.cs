﻿using kniga.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.Core.Pages
{
    public static class StartPage
    {
        public static string EnterStringValue(string inputMessage)
        {
            Console.Write(inputMessage);
            string value = Console.ReadLine();
            return value;
        }
        public static void Run(User user)
        {
            user.Name = EnterStringValue("Введите ваше имя: ");
            Console.Clear();

            do
            {
                user.Age = Functions.CoreFunctions.ParseToIntPositiveNumber(EnterStringValue("Введите возраст персонажа: "));
            }
            while (user.Age == 0);

            Console.Clear();

            user.Print();

            
        }
    }
}
