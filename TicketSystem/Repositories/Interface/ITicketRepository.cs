using TicketSystem.ViewModel;

namespace TicketSystem.Repositories.Interface
{
    public interface ITicketRepository
    {
        Task<IEnumerable<TicketVM>> GetAll();
        Task<TicketVM?> GetById(int id);
        Task<IEnumerable<TicketVM>?> GetByUserId(int id);
        Task Add(TicketVM entity);
        Task Update(TicketVM entity);
        Task Delete(int id);
    }
}
