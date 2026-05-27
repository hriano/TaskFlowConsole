// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using TasksFlowConsole;
using TasksFlowConsole.Services;
using TasksFlowConsole.UI;
using TaskItem = TasksFlowConsole.Models.UserTask;

internal class Program
{
    private static void Main(string[] args)
    {

        var app = new App();
        app.Run();

        

        
    }
}