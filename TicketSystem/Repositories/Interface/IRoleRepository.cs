using TicketSystem.ViewModel;

namespace TicketSystem.Repositories.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleVM>> GetAll();
        Task<RoleVM?> GetById(int id);
        Task Add(RoleVM entity);
        Task Update(RoleVM entity);
        Task Delete(int id);
    }
}
