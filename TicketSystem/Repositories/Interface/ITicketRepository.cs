﻿using TicketSystem.ViewModel;

namespace TicketSystem.Repositories.Interface
{
    public interface ITicketRepository
    {
        //Task<IEnumerable<TicketVM>> GetAll();
        Task<TicketVM?> GetById(string id);
        //Task<IEnumerable<TicketVM>?> GetByUserId(int id);
        Task<IEnumerable<TicketVM>?> GetByDepartmentId(int id);
        Task Add(TicketVM entity);
        Task Update(TicketVM entity);
        Task Delete(string id);
        Task UpdateStatus(string TicketId, string newStatus);
        Task UpdatePriority(string TicketId, string newPriority);
        Task UpdateIsFeedBack(string TicketId, Boolean newIsFeedBack);
        Task<IEnumerable<Ticket_SearchVM>> SearchTickets(string? TicketID,string? title, int? day, int? month, int? year,
    int? createdBy, int? departmentId, int? assignedTo);

    }
}
