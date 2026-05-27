using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Enums;

namespace TasksFlowConsole.Models
{
   public class UserTask
    {
        //private bool _isCompleted = false;
        //public bool IsCompleted => _isCompleted;
        //private string _title;
        public string Title { get; set; }
        public int Id { get; set; }
        public Enums.TaskStatus Status { get;  set; }



        public void MarkAsCompleted()
        {
            //_isCompleted = true;
            Status = Enums.TaskStatus.Completed;

        }
        
    }
}
