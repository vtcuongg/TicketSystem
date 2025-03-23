
using TicketSystem.Data;
using TicketSystem.Models;

namespace TicketSystem.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserVM>> GetAll();
        Task<UserVM?> GetById(int id);
        Task Add(UserModel entity);
        Task Update(UserVM entity);
        Task Delete(int id);
    }
}
