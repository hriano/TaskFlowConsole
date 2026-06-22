using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;
using TasksFlowConsole.Presentation.Menus;
using TasksFlowConsole.Presentation.Presenters;
using TasksFlowConsole.Presentation.Views;
using TasksFlowConsole.Services;

namespace TasksFlowConsole
{
    public class App
    {
        private readonly TaskPresenter _taskPresenter;

        public App(TaskPresenter taskPresenter)
        {
            _taskPresenter = taskPresenter;

        }

        public void Run()
        {
            _taskPresenter.ShowTaskMainMenu();

        }

    }        
}
