using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFlowConsole.Validators
{
    class TaskValidator
    {
        public bool ValidateTitle(string title)
        {

            return !string.IsNullOrWhiteSpace(title);
        }
    }
}
