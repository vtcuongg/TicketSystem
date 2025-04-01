using TicketSystem.Data;
using TicketSystem.Models;
using TicketSystem.ViewModel;

namespace TicketSystem.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserVM>> GetAll();
        Task<UserVM?> GetById(int id);
        Task<IEnumerable<UserVM>> GetByDepartmentId(int id);
        Task Add(UserModel entity);
        Task Update(UserVM entity);
        Task Delete(int id);
        Task UpdateDepartment(int userID, int DepartmentId);
        Task UpdateRole(int userID, int RoleId);
    }
}
