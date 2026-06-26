using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Repository
{
    public interface IRepositoryAdmin
    {
        void SaveTask(UserTask userTask);

  
        int GetMaxId();


        Result Update(UserTask task);


        Result DeleteTask(int id);


         Result<UserTask> GetTaskById(int id);
        
    }
}
