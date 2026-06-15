using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFlowConsole.Presentation.Views
{
    public class SearchMenu
    {
        public int ShowSearchMenu()
        {
            Console.WriteLine("1. Show Tasks");
            Console.WriteLine("2. Show Pending Tasks");
            Console.WriteLine("3. Show Completed Tasks");
            Console.WriteLine("4. Finding Task x ID");
            Console.WriteLine("5. Exit");

            var input = Console.ReadLine();

            if(int.TryParse(input, out var selection))
            {
                return selection;
            }

            return -1;
        }
    }
}
