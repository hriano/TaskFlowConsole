using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;
using TasksFlowConsole.Presentation.Menus;
using TasksFlowConsole.Presentation.Views;
using TasksFlowConsole.Services;


namespace TasksFlowConsole.Presentation.Presenters
{
    public class TaskPresenter
    {
        private readonly ITaskView _view;
        private readonly ITaskServiceAdmin _taskServiceAdmin;
        private readonly ITaskServiceReport _taskServiceReport;
        private readonly ITaskServiceUpdate _taskServiceUpdate;

        public TaskPresenter (ITaskView view, ITaskServiceAdmin taskService, ITaskServiceReport taskServiceReport, ITaskServiceUpdate taskServiceUpdate)
        {
            _view = view;
            _taskServiceAdmin = taskService;
            _taskServiceReport = taskServiceReport;
            _taskServiceUpdate = taskServiceUpdate;
        }

        public void ShowTaskMainMenu()
        {
            bool running = true;
            
            while (running)
            {
                var menu = new MenuBuilder()
                    .AddOption("Create Task", CreateTaskFlow)
                    .AddOption("Complete Task", CompleteTaskFlow)
                    .AddOption("Change to Pending", PendingTaskFlow)
                    .AddOption("Delete Task", DeleteTaskFlow)
                    .AddOption("Show all tasks", ShowAllTaskFlow)
                    .AddOption("Search Menu", ShowSearchMenu)
                    .AddExitOption("Exit")
                    .Build();

                _view.ShowMenu(menu);

                string input = _view.AskMenuOption();

                if(!int.TryParse(input, out int optionNumber))
                {
                    _view.ShowError("Invalid Option.");
                    continue;

                }

                var selectedOption = menu.FirstOrDefault(o => o.Option == optionNumber);

                if(selectedOption == null)
                {
                    _view.ShowError("Option does not Exist.");
                    continue;
                }

                if (selectedOption.ExitMenu)
                {
                    running = false;
                    continue;
                }


                selectedOption.Execute();
            }
        }

        public void ShowSearchMenu()
        {
            bool running = true;

            while (running)
            {
                var menu = new MenuBuilder()
                            .AddOption("Show all tasks.", ShowAllTaskFlow)
                            .AddOption("Show Pending tasks.", ShowPendingTaskFlow)
                            .AddOption("Show Completed tasks.", ShowCompletedTaskFlow)
                            .AddOption("Search Task by ID.", GetTaskByIdFlow)
                            .AddExitOption("Exit")
                            .Build();

                _view.ShowMenu(menu);

                string input = _view.AskMenuOption();

                if (!int.TryParse(input, out int optionNumber))
                {
                    _view.ShowError("Invalid Option.");
                    continue;

                }

                var selectedOption = menu.FirstOrDefault(o => o.Option == optionNumber);

                if (selectedOption == null)
                {
                    _view.ShowError("Option does not exist.");
                    continue;
                }

                if (selectedOption.ExitMenu)
                {
                    running = false;
                    continue;
                }

                selectedOption.Execute();

            }

        }
        private void CreateTaskFlow()
        {
            string Title = _view.AskTitleTask();

            try
            {
                var Task = _taskServiceAdmin.CreateTask(Title);

                _view.ShowTask(Task);
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }

        }
        private void ShowAllTaskFlow()
        {
            IReadOnlyList<UserTask> Tasks = _taskServiceReport.GetAllTasks();

            if (!Tasks.Any())
            {
                _view.ShowMessage("No tasks found");
                return;
            }

            _view.ShowListTasks(Tasks);

        }
        private void ShowPendingTaskFlow()
        {
            IReadOnlyList<UserTask> Tasks = _taskServiceReport.GetPendingTasks();

            if (!Tasks.Any())
            {
                _view.ShowMessage($"No tasks found with status Pending");
                return;
            }

            _view.ShowListTasks(Tasks);
        }
        private void ShowCompletedTaskFlow()
        {
            IReadOnlyList<UserTask> Tasks = _taskServiceReport.GetCompletedTasks();

            if (!Tasks.Any())
            {
                _view.ShowMessage($"No tasks found with status Completed");
                return;
            }

            _view.ShowListTasks(Tasks);
        }
        private void CompleteTaskFlow()
        {
            int id = _view.AskTaskId();

            Result result = _taskServiceUpdate.MarkAsCompleted(id);

            if (result.IsFailure)
            {
                _view.ShowError(result.Error);
                return;
            }

            _view.ShowMessage("Task Updated");

        }

        private void PendingTaskFlow()
        {
            int id = _view.AskTaskId();

            Result result = _taskServiceUpdate.MarkAsPending(id);

            if (result.IsFailure)
            {
                _view.ShowError(result.Error);
                return;
            }

            _view.ShowMessage("Task Updated");

        }

        private void DeleteTaskFlow()
        {

            int id = _view.AskTaskId();

            Result result = _taskServiceAdmin.DeleteTask(id);

            if (result.IsFailure)
            {
                _view.ShowError(result.Error);
            }

            _view.ShowMessage("Task Deleted");

        }
        private void GetTaskByIdFlow()
        {

            int id = _view.AskTaskId();

            Result<UserTask> result = _taskServiceReport.GetTaskById(id);

            if (result.IsFailure)
            {
                _view.ShowError(result.Error);
                return;
            }

            _view.ShowTask(result.Value);


        }
    }
}
