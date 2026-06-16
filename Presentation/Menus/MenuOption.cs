using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFlowConsole.Presentation.Menus
{
    public class MenuOption
    {
        public int Option { get; }
        public string Description { get; }
        public Action Execute { get; }
        public bool ExitMenu { get; }

        public MenuOption(int option, string description, Action? execute, bool exitMenu = false)
        {
            Option = option;
            Description = description;
            Execute = execute;
            ExitMenu = exitMenu;
        }
    }
}
