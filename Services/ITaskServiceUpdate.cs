using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFlowConsole.Common;
using TasksFlowConsole.Models;

namespace TasksFlowConsole.Services
{
    public interface ITaskServiceUpdate
    {
        
        Result MarkAsCompleted(int id);

        Result MarkAsPending(int id);
                
        
    }
}
