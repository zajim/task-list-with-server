using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TL.DbProvider.EF;
using TL.Model.Repository;

namespace TL.Service.WebApi.Model
{
    public class SeedData
    {
        public static async System.Threading.Tasks.Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TLDbContext>();

            Role adminRole = new Role { Id = Guid.NewGuid(), Name = "admin" };
            Role supportRole = new Role { Id = Guid.NewGuid(), Name = "support" };

            if (!context.Roles.Any(x => x.Name == adminRole.Name))
            {
                context.Roles.Add(adminRole);
            }

            if (!context.Roles.Any(x => x.Name == supportRole.Name))
            {
                context.Roles.Add(supportRole);
            }
            
            await context.SaveChangesAsync();

            Privilege CanDeleteTask = new Privilege { Id = Guid.NewGuid(), Name = "CanDeleteTask" };
            Privilege CanAssignTask = new Privilege { Id = Guid.NewGuid(), Name = "CanAssignTask" };
            Privilege CanVisitAdminPage = new Privilege { Id = Guid.NewGuid(), Name = "CanVisitAdminPage" };
            Privilege CanCreateTask = new Privilege { Id = Guid.NewGuid(), Name = "CanCreateTask" };
            Privilege CanChangeTaskStatus = new Privilege { Id = Guid.NewGuid(), Name = "CanChangeTaskStatus" };
            Privilege CanVisitTaskListPage = new Privilege { Id = Guid.NewGuid(), Name = "CanVisitTaskListPage" };

            if (!context.Privileges.Any(x => x.Name == CanDeleteTask.Name))
            {
                context.Privileges.Add(CanDeleteTask);
            }

            if (!context.Privileges.Any(x => x.Name == CanAssignTask.Name))
            {
                context.Privileges.Add(CanAssignTask);
            }

            if (!context.Privileges.Any(x => x.Name == CanVisitAdminPage.Name))
            {
                context.Privileges.Add(CanVisitAdminPage);
            }

            if (!context.Privileges.Any(x => x.Name == CanCreateTask.Name))
            {
                context.Privileges.Add(CanCreateTask);
            }

            if (!context.Privileges.Any(x => x.Name == CanChangeTaskStatus.Name))
            {
                context.Privileges.Add(CanChangeTaskStatus);
            }

            if (!context.Privileges.Any(x => x.Name == CanVisitTaskListPage.Name))
            {
                context.Privileges.Add(CanVisitTaskListPage);
            }

            await context.SaveChangesAsync();

            if (!context.RolePrivileges.Any(x => x.Role.Name == adminRole.Name && x.Privilege.Name == CanDeleteTask.Name) &&
                !context.RolePrivileges.Any(x => x.RoleId == adminRole.Id && x.PrivilegeId == CanDeleteTask.Id))
            {
                RolePrivilege rolePrivilege = new RolePrivilege { RoleId = adminRole.Id, PrivilegeId = CanDeleteTask.Id };
                context.RolePrivileges.Add(rolePrivilege);
            }

            if (!context.RolePrivileges.Any(x => x.Role.Name == adminRole.Name && x.Privilege.Name == CanAssignTask.Name) && 
                !context.RolePrivileges.Any(x => x.RoleId == adminRole.Id && x.PrivilegeId == CanAssignTask.Id))
            {
                RolePrivilege rolePrivilege = new RolePrivilege { RoleId = adminRole.Id, PrivilegeId = CanAssignTask.Id };
                context.RolePrivileges.Add(rolePrivilege);
            }

            if (!context.RolePrivileges.Any(x => x.Role.Name == adminRole.Name && x.Privilege.Name == CanVisitAdminPage.Name) && 
                !context.RolePrivileges.Any(x => x.RoleId == adminRole.Id && x.PrivilegeId == CanVisitAdminPage.Id))
            {
                RolePrivilege rolePrivilege = new RolePrivilege { RoleId = adminRole.Id, PrivilegeId = CanVisitAdminPage.Id };
                context.RolePrivileges.Add(rolePrivilege);
            }

            if (!context.RolePrivileges.Any(x => x.Role.Name == adminRole.Name && x.Privilege.Name == CanCreateTask.Name) && 
                !context.RolePrivileges.Any(x => x.RoleId == adminRole.Id && x.PrivilegeId == CanCreateTask.Id))
            {
                RolePrivilege rolePrivilege = new RolePrivilege { RoleId = adminRole.Id, PrivilegeId = CanCreateTask.Id };
                context.RolePrivileges.Add(rolePrivilege);
            }

            if (!context.RolePrivileges.Any(x => x.Role.Name == adminRole.Name && x.Privilege.Name == CanChangeTaskStatus.Name) && 
                !context.RolePrivileges.Any(x => x.RoleId == adminRole.Id && x.PrivilegeId == CanChangeTaskStatus.Id))
            {
                RolePrivilege rolePrivilege = new RolePrivilege { RoleId = adminRole.Id, PrivilegeId = CanChangeTaskStatus.Id };
                context.RolePrivileges.Add(rolePrivilege);
            }

            if (!context.RolePrivileges.Any(x => x.Role.Name == adminRole.Name && x.Privilege.Name == CanVisitTaskListPage.Name) && 
                !context.RolePrivileges.Any(x => x.RoleId == adminRole.Id && x.PrivilegeId == CanVisitTaskListPage.Id))
            {
                RolePrivilege rolePrivilege = new RolePrivilege { RoleId = adminRole.Id, PrivilegeId = CanVisitTaskListPage.Id };
                context.RolePrivileges.Add(rolePrivilege);
            }

            if (!context.RolePrivileges.Any(x => x.Role.Name == supportRole.Name && x.Privilege.Name == CanVisitTaskListPage.Name) && 
                !context.RolePrivileges.Any(x => x.RoleId == supportRole.Id && x.PrivilegeId == CanVisitTaskListPage.Id))
            {
                RolePrivilege rolePrivilege = new RolePrivilege { RoleId = supportRole.Id, PrivilegeId = CanVisitTaskListPage.Id };
                context.RolePrivileges.Add(rolePrivilege);
            }

            if (!context.RolePrivileges.Any(x => x.Role.Name == supportRole.Name && x.Privilege.Name == CanChangeTaskStatus.Name) && 
                !context.RolePrivileges.Any(x => x.RoleId == supportRole.Id && x.PrivilegeId == CanChangeTaskStatus.Id))
            {
                RolePrivilege rolePrivilege = new RolePrivilege { RoleId = supportRole.Id, PrivilegeId = CanChangeTaskStatus.Id };
                context.RolePrivileges.Add(rolePrivilege);
            }

            await context.SaveChangesAsync();

            var zajimUser = new User
            {
                UserName = "zajim",
                Password = "zajim"
            };

            var anelaUser = new User
            {
                UserName = "anela",
                Password = "anela"
            };

            if (!context.Users.Any(u => u.UserName == zajimUser.UserName))
            {
                context.Users.Add(zajimUser);
            }

            if (!context.Users.Any(u => u.UserName == anelaUser.UserName))
            {
                context.Users.Add(anelaUser);
            }

            if (!context.UserRoles.Any(x => x.Role.Name == adminRole.Name && x.User.UserName == zajimUser.UserName) &&
                !context.UserRoles.Any(x => x.RoleId == adminRole.Id && x.UserId == zajimUser.Id))
            {
                UserRole userRole = new UserRole { RoleId = adminRole.Id, UserId = zajimUser.Id };
                context.UserRoles.Add(userRole);
            }

            if (!context.UserRoles.Any(x => x.Role.Name == supportRole.Name && x.User.UserName == anelaUser.UserName) && 
                !context.UserRoles.Any(x => x.RoleId == supportRole.Id && x.UserId == anelaUser.Id))
            {
                UserRole userRole = new UserRole { RoleId = supportRole.Id, UserId = anelaUser.Id };
                context.UserRoles.Add(userRole);
            }

            await context.SaveChangesAsync();
        }
    }
}
