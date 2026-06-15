using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;
using TasksFlowConsole.Presentation.Views;
using TasksFlowConsole.Services;

namespace TasksFlowConsole
{
    public class App
    {
        private readonly MainMenuUI _menuUI;
        private readonly TaskConsoleUI _taskUI;
        private readonly TaskService _taskService;

        public App()
        {
            _menuUI = new MainMenuUI();
            _taskUI = new TaskConsoleUI();
            _taskService = new TaskService();

        }

        public void Run()
        {
            bool running = true;

            while(running)
            {
                int option = _menuUI.ShowMainMenu();
                
                switch(option)
                {
                    case 1: 
                        CreateTaskFlow();
                        break;
                    case 2:
                        ShowAllTaskFlow();
                        break;
                    case 3:
                        ShowPendingTaskFlow();
                        break;
                    case 4:
                        ShowCompletedTaskFlow();
                        break;
                    case 5:
                        UpdateStatusFlow();
                        break;
                    case 6:
                        DeleteTaskFlow();
                        break;
                    case 7:
                        GetTaskByIdFlow();
                        break;
                    case 8:
                        running = false;
                        break;
                    
                    default:
                        _taskUI.ShowError("Invalid Option");
                        break;
                                               
                }

            }

        }

        private void CreateTaskFlow()
        {
            string Title = _taskUI.AskTitleTask();

            try
            {
                var Task = _taskService.CreateTask(Title);

                _taskUI.ShowTask(Task);
            }
            catch(Exception ex)
            {
                _taskUI.ShowError(ex.Message);
            }
            
        }
        private void ShowAllTaskFlow()
        {
            List<UserTask> Tasks = _taskService.GetAllTasks();

            if (!Tasks.Any())
            {
                _taskUI.ShowMessage("No tasks found");
                return;
            }

            _taskUI.ShowListTasks(Tasks);

        }
        private void ShowPendingTaskFlow()
        {
            List<UserTask> Tasks = _taskService.GetPendingTasks();

            if (!Tasks.Any())
            {
                _taskUI.ShowMessage($"No tasks found with status Pending");
                return;
            }

            _taskUI.ShowListTasks(Tasks);
        }
        private void ShowCompletedTaskFlow()
        {
            List<UserTask> Tasks = _taskService.GetCompletedTasks();

             if (!Tasks.Any())
            {
                _taskUI.ShowMessage($"No tasks found with status Completed");
                return;
            }

            _taskUI.ShowListTasks(Tasks);
        }
        private void UpdateStatusFlow()
        {
            int Id = _taskUI.AskTaskId();

            Result result = _taskService.MarkAsCompleted(Id);

            if (result.IsFailure)
            {
               _taskUI.ShowError(result.Error);
                return;
            }

            _taskUI.ShowMessage("Task Updated");
                     
        }

        private void DeleteTaskFlow()
        {

            int id = _taskUI.AskTaskId();

            Result result = _taskService.DeleteTask(id);

            if (result.IsFailure)
            {
                _taskUI.ShowError(result.Error);
            }

            _taskUI.ShowMessage("Task Deleted");

        }
        private void GetTaskByIdFlow()
        {
            
                int id = _taskUI.AskTaskId();

                Result<UserTask> result = _taskService.GetTaskById(id);

                if (result.IsFailure)
                {
                    _taskUI.ShowError(result.Error);
                    return;
                }

                _taskUI.ShowTask(result.Value);
                
            
        }
        

    }
}
