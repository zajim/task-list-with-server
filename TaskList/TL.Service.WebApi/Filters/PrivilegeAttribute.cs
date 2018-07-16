using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using TL.Abstraction.Business;

namespace TL.Service.WebApi.Filters
{
    public class Privilege : Attribute, IActionFilter
    {
        private readonly IUserBusiness _userBusiness;
        private string _privilegeName;

        public Privilege(IUserBusiness userBusiness, string privilegeName)
        {
            _userBusiness = userBusiness;
            _privilegeName = privilegeName;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            var userIdHeader = context.HttpContext.Request.Headers["UserId"];

            if (userIdHeader.Count == 0)
            {
                context.Result = new JsonResult(new UnauthorizedAccessException());
                return;
            }

            string userid = userIdHeader.ToString().Trim();

            bool parseResult = Guid.TryParse(userid, out Guid userId);

            if (parseResult && userId != Guid.Empty)
            {
                var userLoginData = await _userBusiness.GetUserRolesAndPrivileges(userId).ConfigureAwait(false);

                if (userLoginData.Privileges == null || !userLoginData.Privileges.Any() || !userLoginData.Privileges.Contains(_privilegeName))
                {
                    context.Result = new JsonResult(new UnauthorizedAccessException());
                    return;
                }
            }
            else
            {
                context.Result = new JsonResult(new UnauthorizedAccessException());
                return;
            }
        }
    }
}
