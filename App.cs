using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Services;
using TasksFlowConsole.UI;

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
                int option = _menuUI.ShowMenu();
                
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
                        FindTaskXIdFlow();
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
            _taskUI.ShowListTasks(_taskService.GetAllTasks());

        }
        private void ShowPendingTaskFlow()
        {
            _taskUI.ShowListTasks(_taskService.GetPendingTasks());
        }
        private void ShowCompletedTaskFlow()
        {
            _taskUI.ShowListTasks(_taskService.GetCompletedTasks());
        }
        private void UpdateStatusFlow()
        {
            int Id = _taskUI.AskIdTask();

            try
            {
                _taskService.MarkAsCompleted(Id);
                _taskUI.ShowMessage("Task Completed");
            }
            catch (Exception ex)
            {
                _taskUI.ShowError(ex.Message);
            }

            
        }

        private void DeleteTaskFlow()
        {
            
            try
            {
                _taskService.DeleteTask(_taskUI.AskIdTask());
                _taskUI.ShowMessage("Task Deleted");
            }
            catch (Exception ex)
            {
                _taskUI.ShowError(ex.Message);
            }
            

        }
        private void FindTaskXIdFlow()
        {
            try
            {
                var task = _taskService.FindTaskXId(_taskUI.AskIdTask());
                _taskUI.ShowTask(task);
            }
            catch(Exception ex)
            {
                _taskUI.ShowError(ex.Message);
            }
        }
        

    }
}
