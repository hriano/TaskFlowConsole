using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Presentation.Views
{
    public interface ITaskView
    {
        string AskTitleTask();
        int AskTaskId();
        void ShowError(string message);
        void ShowMessage(string message);
        void ShowTask(UserTask userTask);

    }
}
