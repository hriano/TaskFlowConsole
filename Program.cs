// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using TasksFlowConsole;
using TasksFlowConsole.Presentation.Presenters;
using TasksFlowConsole.Presentation.Views;
using TasksFlowConsole.Repository;
using TasksFlowConsole.Services;
using TaskItem = TasksFlowConsole.Models.UserTask;

internal class Program
{
    private static void Main(string[] args)
    {
        ITaskView view = new TaskConsoleView();
        IRepository repository = new TaskRepository();
        ITaskService taskService = new TaskService(repository);

        //var repository = new TaskRepository();
       // var taskService = new TaskService();
        var taskPresenter = new TaskPresenter(view, taskService);

        var app = new App(taskPresenter);
        app.Run();
                
    }
}