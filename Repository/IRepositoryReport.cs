using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Repository
{
    public interface IRepositoryReport
    {
        IReadOnlyList<UserTask> GetAllTask();

        IReadOnlyList<UserTask> GetTaskByStatus(Common.Enums.TaskStatus status);

        Result<UserTask> GetTaskById(int id);
    }
}
