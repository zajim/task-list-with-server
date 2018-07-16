using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TL.Abstraction.Business;
using TL.Model.Web;
using TL.Service.WebApi.Filters;

namespace TL.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [TypeFilter(typeof(Authorized))]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // GET api/users
        [HttpGet]
        [TypeFilter(typeof(Privilege), Arguments = new object[] { "CanVisitAdminPage" })]
        public async Task<IEnumerable<UserViewModel>> Get()
        {
            return await _userBusiness.GetUsersAsync().ConfigureAwait(false);
        }

        [HttpPost("AssignTask")]
        [TypeFilter(typeof(Privilege), Arguments = new object[] { "CanAssignTask" })]
        public async Task<bool> AssignTask(UserTaskViewModel userTask)
        {
            return await _userBusiness.AssignTaskToUser(userTask).ConfigureAwait(false);
        }
    }
}