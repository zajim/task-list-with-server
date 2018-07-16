using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TL.Abstraction.Business;
using TL.Model.Web;
using TL.Service.WebApi.Filters;

namespace TL.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [TypeFilter(typeof(Authorized))]
    public class TasksController : ControllerBase
    {
        private readonly ITaskBusiness _taskBusiness;

        public TasksController(ITaskBusiness taskBusiness)
        {
            _taskBusiness = taskBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(Privilege), Arguments = new object[] { "CanVisitTaskListPage" })]
        public async Task<IEnumerable<TaskViewModel>> Get([FromQuery]Guid? id = null)
        {
            return await _taskBusiness.GetTasksAsync(id).ConfigureAwait(false);
        }

        [HttpPut]
        [TypeFilter(typeof(Privilege), Arguments = new object[] { "CanChangeTaskStatus" })]
        public async Task<bool> Update([FromQuery]Guid id, TaskViewModel task)
        {
            task.Id = id;
            return await _taskBusiness.UpdateTaskAsync(task).ConfigureAwait(false);
        }

        [HttpDelete]
        [TypeFilter(typeof(Privilege), Arguments = new object[] { "CanDeleteTask" })]
        public async Task<bool> Delete([FromQuery]Guid id)
        {
            return await _taskBusiness.DeleteTaskAsync(id).ConfigureAwait(false);
        }

        [HttpPost]
        [TypeFilter(typeof(Privilege), Arguments = new object[] { "CanCreateTask" })]
        public async Task<bool> Create(TaskViewModel task)
        {
            return await _taskBusiness.CreateTaskAsync(task).ConfigureAwait(false);
        }
    }
}