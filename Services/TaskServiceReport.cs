using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;
using TasksFlowConsole.Repository;


namespace TasksFlowConsole.Services
{
    public class TaskServiceReport : ITaskServiceReport
    {
        //private readonly TaskValidator _validator = new TaskValidator();
        private readonly IRepositoryReport _repository ;

        public TaskServiceReport(IRepositoryReport repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<UserTask> GetAllTasks()
        {
           return _repository.GetAllTask();
        }
        public IReadOnlyList<UserTask> GetPendingTasks()
        {
            return _repository.GetTaskByStatus(Common.Enums.TaskStatus.Pending);
        }
        public IReadOnlyList<UserTask> GetCompletedTasks()
        {
            return _repository.GetTaskByStatus(Common.Enums.TaskStatus.Completed);
        }

        public Result<UserTask> GetTaskById(int id)
        {
            return _repository.GetTaskById(id);
        }

        
    }
}
