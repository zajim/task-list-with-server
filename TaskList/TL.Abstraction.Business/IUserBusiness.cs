using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TL.Model.Business;
using TL.Model.Web;

namespace TL.Abstraction.Business
{
    public interface IUserBusiness
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<bool> AssignTaskToUser(UserTaskViewModel userTaskVM);
        Task<UserLoginViewModel> Login(LoginViewModel loginData);
        Task<UserLoginViewModel> GetUserLoginData(string token);
        Task<UserLoginViewModel> GetUserRolesAndPrivileges(Guid userId);
    }
}
