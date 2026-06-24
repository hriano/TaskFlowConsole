using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Services
{
    public interface ITaskService
    {
        public UserTask CreateTask(string title);

        public IReadOnlyList<UserTask> GetAllTasks();

        public IReadOnlyList<UserTask> GetPendingTasks();

        public IReadOnlyList<UserTask> GetCompletedTasks();

        public Result MarkAsCompleted(int id);

        public Result MarkAsPending(int id);


        public Result DeleteTask(int id);

        public Result<UserTask> GetTaskById(int id);
        
    }
}
