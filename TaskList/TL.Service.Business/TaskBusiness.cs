using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TL.Abstraction.Business;
using TL.Abstraction.Repository;
using TL.Model.Web;
using DM = TL.Model.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TL.Service.Business
{
    public class TaskBusiness : BaseBusiness, ITaskBusiness
    {
        private readonly ICrudRepository<DM.Task> _taskRepository;
        private readonly ICrudRepository<DM.UserTask> _userTaskRepository;

        public TaskBusiness(
            IMapper mapper,
            ICrudRepository<DM.Task> taskRepository,
            ICrudRepository<DM.UserTask> userTaskRepository)
            : base(mapper)
        {
            _taskRepository = taskRepository;
            _userTaskRepository = userTaskRepository;
        }

        public async Task<bool> CreateTaskAsync(TaskViewModel task)
        {
            DM.Task taskDM = Mapper.Map<DM.Task>(task);
            return await _taskRepository.AddAsync(taskDM).ConfigureAwait(false) > 0;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            var task = await _taskRepository.GetList().SingleOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            return await _taskRepository.RemoveAsync(task).ConfigureAwait(false) > 0;
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasksAsync(Guid? userId = null)
        {
            IQueryable<DM.Task> tasksDM = _taskRepository.GetList().AsNoTracking();

            if (userId != null)
            {
                IQueryable<DM.UserTask> userTasks = _taskRepository.GetList().SelectMany(x => x.UserTasks).Where(x => x.UserId == userId).AsNoTracking();
                tasksDM = userTasks.Select(x => x.Task);
            }
            
            return Mapper.Map<IEnumerable<TaskViewModel>>(await tasksDM.ToListAsync());
        }

        public async Task<bool> UpdateTaskAsync(TaskViewModel task)
        {
            DM.Task taskDM = Mapper.Map<DM.Task>(task);
            return await _taskRepository.UpdateAsync(taskDM).ConfigureAwait(false) > 0;
        }

        public async Task<IEnumerable<UserTaskViewModel>> GetUserTasksAsync(Guid id)
        {
            IEnumerable<DM.UserTask> userTasksDM = await _userTaskRepository.GetList()
                .Include(x => x.Task)
                .Include(x => x.User)
                .Where(x => x.UserId == id)
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<IEnumerable<UserTaskViewModel>>(userTasksDM);
        }
    }
}
