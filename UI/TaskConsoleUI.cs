using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.UI
{
    class TaskConsoleUI
    {
        public void ShowTask(UserTask task)
        {
            Console.WriteLine($"Id: {task.Id}");
            //try
            //{
                Console.WriteLine($"Title: {task.Title}");
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine($"Error:{ex.Message}");
            //    ShowError(ex.Message);
            //}
            
            //string taskStatus = task.IsCompleted ? "COMPLETED" : "PENDING";
            Console.WriteLine($"Status: {task.Status}");
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
            bool NoNull; ;

            do
            {
                NoNull = false;

                Console.WriteLine("Input Task:");
                Title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Title))
                {
                    NoNull = true;
                    ShowError("Title can not be null or empty, try again.");
                }
                    

            } while (NoNull);

            return Title; 
            
        }

        public int AskIdTask()
        {
            
            bool NoNull;
            

            do
            {
                NoNull = false;

                Console.WriteLine("Input Task Id:");
                var Id = Console.ReadLine();

                if (int.TryParse(Id, out var selection))
                {
                    return selection;
                }
                else
                {
                    NoNull = true;
                    ShowError("Id Invalid, Try again.");
                }

            } while (NoNull);

            return -1;
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
