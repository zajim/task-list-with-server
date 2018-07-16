using AutoMapper;
using DM = TL.Model.Repository;
using TL.Model.Web;
using BM = TL.Model.Business;

namespace TL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DM.User, UserViewModel>();
            CreateMap<UserViewModel, DM.User>();

            CreateMap<DM.Task, TaskViewModel>();
            CreateMap<TaskViewModel, DM.Task>();

            CreateMap<DM.UserTask, UserTaskViewModel>();
            CreateMap<UserTaskViewModel, DM.UserTask>();

            CreateMap<DM.UserRole, UserRoleViewModel>();
            CreateMap<UserRoleViewModel, DM.UserRole>();

            CreateMap<DM.Role, RoleViewModel>();
            CreateMap<RoleViewModel, DM.Role>();

            CreateMap<BM.UserLogin, DM.UserLogin>();
            CreateMap<BM.UserLogin, UserLoginViewModel>();
            CreateMap<DM.UserLogin, UserLoginViewModel>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.Privileges, opt => opt.Ignore());
        }
    }
}
