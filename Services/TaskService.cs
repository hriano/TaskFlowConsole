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
    public class TaskService : ITaskServiceAdmin, ITaskServiceUpdate, ITaskServiceReport
    {
        //private readonly TaskValidator _validator = new TaskValidator();
        private readonly IRepositoryAdmin _repositoryAdmin;
        private readonly IRepositoryReport _repositoryReport;

        public TaskService(IRepositoryAdmin repositoryAdmin, IRepositoryReport repositoryReport)
        {
            _repositoryAdmin = repositoryAdmin;
            _repositoryReport = repositoryReport;
        }

        public UserTask CreateTask(string title)
        {

            int id = _repositoryAdmin.GetMaxId() + 1;

            UserTask _userTask = UserTask.CreateTask(id, title);

            _repositoryAdmin.SaveTask(_userTask);

            return _userTask;

        }


        public Result DeleteTask(int id)
        {
            return _repositoryAdmin.DeleteTask(id);
        }

        public IReadOnlyList<UserTask> GetAllTasks()
        {
            return _repositoryReport.GetAllTask();
        }
        public IReadOnlyList<UserTask> GetPendingTasks()
        {
            return _repositoryReport.GetTaskByStatus(Common.Enums.TaskStatus.Pending);
        }
        public IReadOnlyList<UserTask> GetCompletedTasks()
        {
            return _repositoryReport.GetTaskByStatus(Common.Enums.TaskStatus.Completed);
        }

        public Result<UserTask> GetTaskById(int id)
        {
            return _repositoryReport.GetTaskById(id);

        }

        public Result MarkAsCompleted(int id)
        {
            var taskResult = _repositoryReport.GetTaskById(id);

            if (taskResult.IsFailure)
                return Result.Fail(taskResult.Error);

            UserTask task = taskResult.Value;

            var result = task.MarkAsCompleted();

            if (result.IsFailure)
            {
                return result;
            }

            _repositoryAdmin.Update(task);

            return Result.Ok();
        }

        public Result MarkAsPending(int id)
        {
            var taskResult = _repositoryReport.GetTaskById(id);

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

            _repositoryAdmin.Update(task);

            return Result.Ok();

        }

    }
}