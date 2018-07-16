using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using TL.Abstraction.Business;

namespace TL.Service.WebApi.Filters
{
    public class Authorized : Attribute, IResourceFilter
    {
        private readonly IUserBusiness _userBusiness;

        public Authorized(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        public async void OnResourceExecuting(ResourceExecutingContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader.Count <= 0)
            {
                context.Result = new JsonResult(new UnauthorizedAccessException());
                return;
            }
            
            string token = authorizationHeader.ToString().Replace("Bearer", string.Empty).Trim();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new JsonResult(new UnauthorizedAccessException());
                return;
            }

            var userLoginData = await _userBusiness.GetUserLoginData(token).ConfigureAwait(false);

            if (userLoginData == null || userLoginData.TokenExpire < DateTime.Now)
            {
                context.Result = new JsonResult(new UnauthorizedAccessException());
                return;
            }
        }
    }
}
