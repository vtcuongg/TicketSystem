using TicketSystem.ViewModel;

namespace TicketSystem.Repositories.Interface
{
    public interface ITicketFeedBackAssigneeRepository
    {
        Task Add(TicketFeedBackAssigneeVM entity);
        Task Delete(int feedbackId, int assignedTo);
    }
}
