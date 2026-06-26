using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Services
{
    public interface ITaskServiceReport
    {
        
        IReadOnlyList<UserTask> GetAllTasks();

        IReadOnlyList<UserTask> GetPendingTasks();

        IReadOnlyList<UserTask> GetCompletedTasks();
              
        
    }
}
