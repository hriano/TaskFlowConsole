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
        public List<UserTask> GetAllTask ()
        {
            return ListTask;
        }
        public List<UserTask> GetTaskByStatus(Enums.TaskStatus status)
        {
            List<UserTask> TaskXState = new List<UserTask>();

            //VERIFICAR CON LINQ PARA VALIDAR QUE LA LISTA TENGA ELEMENTOS                        
            foreach (var task in ListTask)
                {
                // VALIDAR QUE LA LISTA SI TIENE ESE STATUS, CON LINQ VALIDO UNA SOLA VEZ PORQUE TENDRIA ELEMENTOS
                    if (task.Status == status)  
                        TaskXState.Add(task);
                }

            return TaskXState;
        }
        public int GetMaxId()
        {
            return ListTask.Count > 0 ? ListTask.Max(task => task.Id) : 0;
        }

        public Result UpdateTaskStatus(int id, Enums.TaskStatus status)
        {
            

            var task = ListTask.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return Result.Fail("Id does not Exist.");
                //throw new Exception("Id does not Exist.");

            switch (status)
            {
                case Enums.TaskStatus.Completed:
                    task.MarkAsCompleted();
                    break;
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
