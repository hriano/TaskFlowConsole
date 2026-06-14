using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Presentation.Views
{
    class TaskConsoleUI
    {
        public void ShowTask(UserTask task)
        {
            Console.WriteLine($"Id: {task.Id} - {task.Title} : {task.Status} ");
            
            Console.WriteLine($"------------ || ------------");
            
            
        }

        public void ShowListTasks(List<UserTask> listTasks)
        {

            foreach (var task in listTasks)
            {
                
                ShowTask(task);
            }
        }

        public string AskTitleTask()
        {
            string Title;
 
            while (true)
            {
                Console.WriteLine("Input Task:");
                Title = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(Title))
                {
                    return Title;
                    
                }

                ShowError("Title can not be null or empty, try again.");
            }

            
            
        }

        public int AskIdTask()
        {
            
            while(true)
            {
                
                Console.WriteLine("Input Task Id:");
                var Id = Console.ReadLine();

                if (int.TryParse(Id, out var selection))
                {
                    return selection;
                }
                
                ShowError("Id Invalid, Try again.");
           
            } 

           
        }

        public void ShowError(string message)
        {
            Console.WriteLine($"Error : {message}");

        }

        public void ShowMessage(string message)
        {
           
           Console.WriteLine(message);
           
            
        }
    }
}
