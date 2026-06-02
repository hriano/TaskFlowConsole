using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            //if (!_validator.ValidateTitle(title))
            //{
            //    throw new ArgumentException("Title Invalid");
            //}

            int id = _repository.GetMaxId() + 1;

            UserTask _userTask = new UserTask { Id = id, Title = title, Status = Enums.TaskStatus.Pending};
            
            _repository.SetTask(_userTask);

            return _userTask;
                        
        }
        public List<UserTask> GetAllTasks()
        {
           return _repository.GetAllTask();
        }
        public List<UserTask> GetPendingTasks()
        {
            return _repository.GetTaskByStatus(Enums.TaskStatus.Pending);
        }
        public List<UserTask> GetCompletedTasks()
        {
            return _repository.GetTaskByStatus(Enums.TaskStatus.Completed);
        }

        public void MarkAsCompleted(int id)
        {
            _repository.UpdateTaskStatus(id,Enums.TaskStatus.Completed);
        }

        public void DeleteTask(int id)
        {
            _repository.DeleteTask(id);
        }

        public UserTask GetTaskById (int id)
        {
            return _repository.GetTaskById(id);
        }
    }
}
