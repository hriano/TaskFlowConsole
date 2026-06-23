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
    public class TaskService
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

        public Result MarkAsCompleted(int id)
        {
            var taskResult = _repository.GetTaskById(id);

            if (taskResult.IsFailure)
                return Result.Fail(taskResult.Error);

            UserTask task = taskResult.Value;

            var result = task.MarkAsCompleted();

            if (result.IsFailure)
            {
                return result;
            }
            
            _repository.Update(task);

            return Result.Ok();
        }

        public Result MarkAsPending(int id)
        {
            var taskResult = _repository.GetTaskById(id);

            if (taskResult.IsFailure)
            {
                return Result.Fail(taskResult.Error);
            }

            UserTask task = taskResult.Value;

            var result = task.MarkAsPending();

            if (result.IsFailure)
            {
                return result;
            }

            _repository.Update(task);

            return Result.Ok();

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
