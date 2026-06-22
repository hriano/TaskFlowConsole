using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFlowConsole.Presentation.Menus
{
    public class MenuBuilder
    {
        private readonly List<MenuOption> Options = new();

        public MenuBuilder AddOption(string description, Action execute)
        {
            int optionNumber = Options.Count + 1;

            Options.Add(new MenuOption(optionNumber, description, execute));
            
            return this;
            
        }

        public MenuBuilder AddExitOption(string description)
        {
            int optionNumber = Options.Count + 1;
            
            Options.Add(new MenuOption(optionNumber, description,null, true));

            return this;
        }

        public List<MenuOption> Build()
        {
            if (!Options.Any())
                throw new InvalidOperationException("Menu requires at least one option.");

            return Options;
        }
    }
}
