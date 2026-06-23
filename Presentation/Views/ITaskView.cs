using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Models;
using TasksFlowConsole.Presentation.Menus;

namespace TasksFlowConsole.Presentation.Views
{
    public interface ITaskView
    {
        string AskTitleTask();
        int AskTaskId();
        string AskMenuOption();
        void ShowMenu(List<MenuOption> options);
        void ShowError(string message);
        void ShowMessage(string message);
        void ShowTask(UserTask userTask);
        void ShowListTasks(IReadOnlyList<UserTask> tasks);

    }
}
