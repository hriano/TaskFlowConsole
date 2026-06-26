using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Services
{
    public interface ITaskServiceAdmin
    {
        UserTask CreateTask(string title);

        Result DeleteTask(int id);

                
    }
}
