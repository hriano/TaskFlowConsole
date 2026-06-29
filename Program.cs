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
        //IRepositoryAdmin repository = new TaskRepository();
        //IRepositoryReport repositoryReport = new 
        TaskRepository repository = new TaskRepository();
        ITaskServiceAdmin taskServiceAdmin = new TaskServiceAdmin(repository);
        ITaskServiceReport taskServiceReport = new TaskServiceReport(repository);
        ITaskServiceUpdate taskServiceUpdate = new TaskServiceUpdate(repository);

        //var repository = new TaskRepository();
       // var taskService = new TaskService();
        var taskPresenter = new TaskPresenter(view, taskServiceAdmin,taskServiceReport, taskServiceUpdate);

        var app = new App(taskPresenter);
        app.Run();
                
    }
}