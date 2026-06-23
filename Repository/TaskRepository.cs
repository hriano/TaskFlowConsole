using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Repository
{
    public class TaskRepository
    {
        private List<UserTask> ListTask;
        
        public TaskRepository()
        {
            ListTask = new List<UserTask>();
        }

        public void SaveTask(UserTask userTask)
        {
            ListTask.Add(userTask);
            
        }
        public IReadOnlyList<UserTask> GetAllTask ()
        {
            return ListTask.AsReadOnly();
        }
        public IReadOnlyList<UserTask> GetTaskByStatus(Common.Enums.TaskStatus status)
        {

            return ListTask.
                      Where(task => task.Status == status).
                      ToList().AsReadOnly();
            
        }
        public int GetMaxId()
        {
            return ListTask.Count > 0 ? ListTask.Max(task => task.Id) : 0;
        }

        public Result Update(UserTask task)
        {

            int index = ListTask.FindIndex(t => t.Id == task.Id);
            
            if (index >= 0)
            {
                ListTask[index] = task;
            }

            return Result.Ok();

           
        }

        public Result DeleteTask(int id)
        {
           
            var task = ListTask.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return Result.Fail("Task does not exist");
                
            ListTask.Remove(task);

            return Result.Ok();
            
        }

        public Result<UserTask> GetTaskById(int id)
        {
            var task = ListTask.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return Result<UserTask>.Fail("Task does not exist");
            

            return Result<UserTask>.Ok(task);
        }
        
        
    }
}
