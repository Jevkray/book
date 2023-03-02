using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kniga.Functions;
using kniga.Core.Pages;
namespace kniga.Core

{
    class MainForm
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            {

                User user = new User();
                user.ModeChoice = CoreFunctions.ModeChoosing();

                switch (CoreFunctions.PageChoosing(user.ModeChoice))
                {
                    case 1:
                        {
                            StartPage.Run(user);
                            Console.ReadKey();
                            Console.Clear();
                            if (user.ModeChoice) { break; }
                        }
                        goto case 2;

                    case 2:
                        {
                            ComparingNumbers.Run();
                            Console.ReadKey();
                            Console.Clear();
                            if (user.ModeChoice) { break; }
                        }
                        goto case 3;

                    case 3:
                        {
                            Exponentation.Run();
                            Console.ReadKey();
                            Console.Clear();
                            if (user.ModeChoice) { break; }
                        }
                        goto case 4;

                    case 4:
                        {
                            PaintingRectangles.Run();
                            Console.ReadKey();
                            Console.Clear();
                            if (user.ModeChoice) { break; }
                        }
                        goto case 5;

                    case 5:
                        {
                            TicTacToe.Run();
                            Console.ReadKey();
                            Console.Clear();
                            if (user.ModeChoice) { break; }
                        }
                        break;

                    default :
                        {
                            //Тупо тестовый
                        }
                        break;
                }
            }
        }
    }
}
