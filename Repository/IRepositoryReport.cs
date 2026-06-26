using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Repository
{
    public interface IRepositoryReport
    {
        IReadOnlyList<UserTask> GetAllTask();

        IReadOnlyList<UserTask> GetTaskByStatus(Common.Enums.TaskStatus status);
    }
}
