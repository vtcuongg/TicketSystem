using AutoMapper;
using TicketSystem.Data;
using TicketSystem.Models;
using TicketSystem.ViewModel;

namespace TicketSystem.Helper
{
    public class ApplicationMapper :Profile

    {
        public ApplicationMapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Role, RoleVM>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Ticket, TicketVM>().ReverseMap();
            CreateMap<TicketFeedBack, TicketFeedBackVM>().ReverseMap();
            CreateMap<TicketFeedbackAssignee,TicketFeedBackAssigneeVM >().ReverseMap();
            CreateMap<TicketAssignment, TicketAssignmentVM>().ReverseMap();

        }

    }
}
