using AutoMapper;
using TicketSystem.Data;
using TicketSystem.Models;

namespace TicketSystem.Helper
{
    public class ApplicationMapper :Profile

    {
        public ApplicationMapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<Department, DepartmentModel>().ReverseMap();
        }

    }
}
