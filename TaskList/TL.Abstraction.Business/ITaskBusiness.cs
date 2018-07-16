using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TL.Model.Web;

namespace TL.Abstraction.Business
{
    public interface ITaskBusiness
    {
        Task<IEnumerable<TaskViewModel>> GetTasksAsync(Guid? id = null);
        Task<bool> CreateTaskAsync(TaskViewModel task);
        Task<bool> DeleteTaskAsync(Guid id);
        Task<bool> UpdateTaskAsync(TaskViewModel task);
        Task<IEnumerable<UserTaskViewModel>> GetUserTasksAsync(Guid id);
    }
}
