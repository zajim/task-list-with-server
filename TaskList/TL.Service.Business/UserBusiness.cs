using System.Collections.Generic;
using System.Threading.Tasks;
using TL.Abstraction.Business;
using DM = TL.Model.Repository;
using TL.Model.Web;
using TL.Abstraction.Repository;
using Microsoft.EntityFrameworkCore;
using BM = TL.Model.Business;
using AutoMapper;
using System.Linq;
using System;

namespace TL.Service.Business
{
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
        private readonly ICrudRepository<DM.User> _userRepository;
        private readonly ICrudRepository<DM.UserTask> _userTaskRepository;
        private readonly ICrudRepository<DM.UserLogin> _userLoginRepository;
        private readonly ICrudRepository<DM.RolePrivilege> _rolePrivilegeRepository;

        public UserBusiness(
            IMapper mapper,
            ICrudRepository<DM.User> userRepository,
            ICrudRepository<DM.UserTask> userTaskRepository,
            ICrudRepository<DM.UserLogin> userLoginRepository,
            ICrudRepository<DM.RolePrivilege> rolePrivilegeRepository)
            : base(mapper)
        {
            _userRepository = userRepository;
            _userTaskRepository = userTaskRepository;
            _userLoginRepository = userLoginRepository;
            _rolePrivilegeRepository = rolePrivilegeRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            IEnumerable<DM.User> usersDM = await _userRepository.GetList().ToListAsync().ConfigureAwait(false);

            return Mapper.Map<IEnumerable<UserViewModel>>(usersDM);
        }

        public async Task<bool> AssignTaskToUser(UserTaskViewModel userTaskVM)
        {
            DM.UserTask userTask = Mapper.Map<DM.UserTask>(userTaskVM);
            var count = (await _userTaskRepository.GetList().Where(x => x.UserId == userTaskVM.UserId && x.TaskId == userTaskVM.TaskId).ToListAsync())?.Count();

            if (count > 0)
            {
                return false;
            }

            return await _userTaskRepository.AddAsync(userTask).ConfigureAwait(false) > 0;
        }

        public async Task<UserLoginViewModel> Login(LoginViewModel loginData)
        {
            DM.User user = await _userRepository.GetList().Where(x => x.UserName == loginData.Username && x.Password == loginData.Password).AsNoTracking().FirstOrDefaultAsync();
            
            BM.UserLogin userLogin = new BM.UserLogin();
            userLogin.Token = null;

            if (user != null)
            {
                IEnumerable<DM.UserRole> userRoles = await _userRepository.GetList().Where(x => x.Id == user.Id).SelectMany(x => x.UserRoles).Include(x => x.Role).AsNoTracking().ToListAsync();

                userLogin.ClientId = loginData.ClientId;
                userLogin.UserId = user.Id;
                userLogin.Token = Guid.NewGuid().ToString();
                userLogin.TokenExpire = DateTime.Now.AddDays(30);

                if (userRoles?.Any() ?? false)
                {
                    userLogin.Roles = new HashSet<string>();
                    foreach (var userRole in userRoles)
                    {
                        userLogin.Roles.Add(userRole.Role.Name);
                        IEnumerable<DM.RolePrivilege> rolePrivileges = await _rolePrivilegeRepository.GetList().Where(x => x.RoleId == userRole.RoleId).Include(x => x.Privilege).AsNoTracking().ToListAsync().ConfigureAwait(false);
                        if (rolePrivileges?.Any() ?? false)
                        {
                            userLogin.Privileges = new HashSet<string>();
                            foreach (var rolePrivilege in rolePrivileges)
                            {
                                userLogin.Privileges.Add(rolePrivilege.Privilege.Name);
                            }
                        }
                    }
                }

                var userLoginDb = await _userLoginRepository.GetList().AsNoTracking().FirstOrDefaultAsync(x => x.ClientId == loginData.ClientId && x.UserId == userLogin.UserId).ConfigureAwait(false);

                if (userLoginDb != null)
                {
                    userLoginDb.Token = userLogin.Token;
                    userLoginDb.TokenExpire = userLogin.TokenExpire;
                    await _userLoginRepository.UpdateAsync(userLoginDb).ConfigureAwait(false);
                }
                else
                {
                    await _userLoginRepository.AddAsync(Mapper.Map<DM.UserLogin>(userLogin)).ConfigureAwait(false);
                }
            }

            return Mapper.Map<UserLoginViewModel>(userLogin);
        }

        public async Task<UserLoginViewModel> GetUserRolesAndPrivileges(Guid userId)
        {
            IEnumerable<DM.UserRole> userRoles = await _userRepository.GetList().Where(x => x.Id == userId).SelectMany(x => x.UserRoles).Include(x => x.Role).AsNoTracking().ToListAsync();

            BM.UserLogin userLogin = new BM.UserLogin();

            if (userRoles?.Any() ?? false)
            {
                userLogin.Roles = new HashSet<string>();
                foreach (var userRole in userRoles)
                {
                    userLogin.Roles.Add(userRole.Role.Name);
                    IEnumerable<DM.RolePrivilege> rolePrivileges = await _rolePrivilegeRepository.GetList().Where(x => x.RoleId == userRole.RoleId).Include(x => x.Privilege).AsNoTracking().ToListAsync().ConfigureAwait(false);
                    if (rolePrivileges?.Any() ?? false)
                    {
                        userLogin.Privileges = new HashSet<string>();
                        foreach (var rolePrivilege in rolePrivileges)
                        {
                            userLogin.Privileges.Add(rolePrivilege.Privilege.Name);
                        }
                    }
                }
            }

            return Mapper.Map<UserLoginViewModel>(userLogin);
        }

        public async Task<UserLoginViewModel> GetUserLoginData(string token)
        {
            DM.UserLogin userLoginData = await _userLoginRepository.GetList().AsNoTracking().FirstOrDefaultAsync(x => x.Token == token);
            UserLoginViewModel userLoginDataVM = new UserLoginViewModel();
            userLoginDataVM.Id = userLoginData.Id;
            userLoginDataVM.ClientId = userLoginData.ClientId;
            userLoginDataVM.Token = userLoginData.Token;
            userLoginDataVM.TokenExpire = userLoginData.TokenExpire;
            userLoginDataVM.UserId = userLoginData.UserId;

            return userLoginDataVM;
        }
    }
}
