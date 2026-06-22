using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFlowConsole.Presentation.Menus
{
    public class MainMenu
    {
 
        public int ShowMainMenu()
        {
            Console.WriteLine("1. Create Task");
            Console.WriteLine("2. Complete Tasks");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Exit");

            var input = Console.ReadLine();
            if (int.TryParse(input, out var selection))
            {
                return selection;
            }

           // Console.WriteLine("Invalid selection.");
            return -1;
        }
    }
}
