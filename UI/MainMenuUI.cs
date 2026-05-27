using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFlowConsole.UI
{
    public class MainMenuUI
    {
 
        public int ShowMenu()
        {
            Console.WriteLine("1. Create Task");
            Console.WriteLine("2. Show Tasks");
            Console.WriteLine("3. Show Pending Tasks");
            Console.WriteLine("4. Show Completed Tasks");
            Console.WriteLine("5. Complete Tasks");
            Console.WriteLine("6. Delete Task");
            Console.WriteLine("7. Finding Task x ID");
            Console.WriteLine("8. Exit");

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
