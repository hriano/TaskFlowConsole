using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;

namespace TasksFlowConsole.Models
{
   public class UserTask
    {
        
        public string Title { get; }
        public int Id { get; }
        public Common.Enums.TaskStatus Status { get; private set; }

        private UserTask(int id, string title)
        {
            Id = id;
            Title = title;
            Status = Common.Enums.TaskStatus.Pending;
        }

        public static UserTask CreateTask(int id, string title)
        {
            if (id <= 0)
              throw new ArgumentException("Invalid Id");
            
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Invalid title");

            return new UserTask(id, title);
        }



        public Result MarkAsCompleted()
        {
            //_isCompleted = true;
            if (Status == Common.Enums.TaskStatus.Completed)
            {
                return Result.Fail("Task is already completed");
            }

            Status = Common.Enums.TaskStatus.Completed;

            return Result.Ok();

        }
        
    }
}
