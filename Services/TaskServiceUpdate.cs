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
    public class TaskServiceUpdate : ITaskServiceUpdate
    {
        //private readonly TaskValidator _validator = new TaskValidator();
        private readonly IRepositoryAdmin _repository ;

        public TaskServiceUpdate(IRepositoryAdmin repository)
        {
            _repository = repository;
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

    }
}
