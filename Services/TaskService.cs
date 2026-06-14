using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;
using TasksFlowConsole.Repository;
using TasksFlowConsole.Validators;

namespace TasksFlowConsole.Services
{
    class TaskService
    {
        //private readonly TaskValidator _validator = new TaskValidator();
        private TaskRepository _repository = new TaskRepository();

        public UserTask CreateTask (string title)
        {
            
            int id = _repository.GetMaxId() + 1;

            UserTask _userTask = UserTask.CreateTask(id, title);
            
            _repository.SaveTask(_userTask);

            return _userTask;
                        
        }
        public List<UserTask> GetAllTasks()
        {
           return _repository.GetAllTask();
        }
        public List<UserTask> GetPendingTasks()
        {
            return _repository.GetTaskByStatus(Common.Enums.TaskStatus.Pending);
        }
        public List<UserTask> GetCompletedTasks()
        {
            return _repository.GetTaskByStatus(Common.Enums.TaskStatus.Completed);
        }

        public Result MarkAsCompleted(int id)
        {
           return _repository.UpdateTaskStatus(id,Common.Enums.TaskStatus.Completed);
        }

        public Result DeleteTask(int id)
        {
            return _repository.DeleteTask(id);
        }

        public Result<UserTask> GetTaskById (int id)
        {
            return _repository.GetTaskById(id);
        }
    }
}
