using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kniga.Functions
{
    public static class MainFormFunctions
    {
        public static int PageChoosing(bool ModeChoice)
        {

            int PageChoiceSwitch = 0;
            if (ModeChoice)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Быстрый переход");
                Console.Write("Введите номер страницы на которую желаете перейти:");
                PageChoiceSwitch = CoreFunctions.ParseToIntNumber(Console.ReadLine());
            }

            if (!ModeChoice)
            {
                PageChoiceSwitch = 1;
                Console.Clear();
            }

            return PageChoiceSwitch;
        }

        public static bool ModeChoosing()
        {
            char ReadModeChoice;
            do
            {
                Console.WriteLine("Нажмите F если хотите использовать быстрый режим, S - если медленный");
                ReadModeChoice = Console.ReadKey().KeyChar;

                if (ReadModeChoice == 'f' | ReadModeChoice == 'F')
                {
                    return true;
                }

                if (ReadModeChoice == 's' | ReadModeChoice == 'S')
                {
                    return false;
                }

                Console.Clear();

            }
            while (ReadModeChoice != 'f' | ReadModeChoice != 'F' | ReadModeChoice != 's' | ReadModeChoice != 'S');

            throw new Exception("Something going wrong");

        }
    }
}
