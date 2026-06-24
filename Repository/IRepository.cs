using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Repository
{
    public interface IRepository
    {
        public void SaveTask(UserTask userTask);

        public IReadOnlyList<UserTask> GetAllTask();

        public IReadOnlyList<UserTask> GetTaskByStatus(Common.Enums.TaskStatus status);
        public int GetMaxId();


        public Result Update(UserTask task);


        public Result DeleteTask(int id);


        public Result<UserTask> GetTaskById(int id);
        
    }
}
