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
                            Page1.Run(user);
                            if (user.ModeChoice) { break; }
                        }
                        goto case 2;

                    case 2:
                        {
                            Page2.Run();
                            if (user.ModeChoice) { break; }
                        }
                        goto case 3;

                    case 3:
                        {
                            Page3.Run();
                            if (user.ModeChoice) { break; }
                        }
                        goto case 4;

                    case 4:
                        {
                            Page4.Run();
                            if (user.ModeChoice) { break; }
                        }
                        goto case 5;

                    case 5:
                        {
                            Page5.Run();    
                            if (user.ModeChoice) { break; }
                        }
                        break;

                    case 0:
                        {
                            //Тупо тестовый
                        }
                        break;
                }
            }
        }
    }
}
