using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;
using TasksFlowConsole.Repository;


namespace TasksFlowConsole.Services
{
    public class TaskServiceAdmin : ITaskServiceAdmin
    {
        //private readonly TaskValidator _validator = new TaskValidator();
        private readonly IRepositoryAdmin _repository ;

        public TaskServiceAdmin(IRepositoryAdmin repository)
        {
            _repository = repository;
        }

         public UserTask CreateTask (string title)
        {
            
            int id = _repository.GetMaxId() + 1;

            UserTask _userTask = UserTask.CreateTask(id, title);
            
            _repository.SaveTask(_userTask);

            return _userTask;
                        
        }
        
               
        public Result DeleteTask(int id)
        {
            return _repository.DeleteTask(id);
        }

        
    }
}
