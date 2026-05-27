using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void SetTask(UserTask userTask)
        {
            if (!string.IsNullOrEmpty(userTask.Title))
                ListTask.Add(userTask);
            else
                throw new ArgumentException("Title Invalid");
        }
        public List<UserTask> GetAllTask ()
        {
            return ListTask;
        }
        public List<UserTask> GetTaskXStatus(Enums.TaskStatus status)
        {
            List<UserTask> TaskXState = new List<UserTask>();

            foreach (var task in ListTask)
                {
                    if (task.Status == status)  
                        TaskXState.Add(task);
                }

            return TaskXState;
        }
        public int GetMaxId()
        {
            return ListTask.Count > 0 ? ListTask.Max(task => task.Id) : 0;
        }

        public void UpdateTaskStatus(int id, Enums.TaskStatus status)
        {
            

            var task = ListTask.FirstOrDefault(t => t.Id == id);

            if (task == null)
                throw new Exception("Id does not Exist.");

            switch (status)
            {
                case Enums.TaskStatus.Completed:
                    task.MarkAsCompleted();
                    break;
            }

           
        }

        public void DeleteTask(int id)
        {
           
            var task = ListTask.FirstOrDefault(t => t.Id == id);

            if (task == null)
                throw new Exception("Task does not exist");

            ListTask.Remove(task);
            
        }

        public UserTask FindTaskXId(int id)
        {
            var task = ListTask.FirstOrDefault(t => t.Id == id);

            if (task == null)
                throw new Exception("Task does not exist");

            return task;
        }
        
        
    }
}
