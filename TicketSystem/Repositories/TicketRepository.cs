using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Repositories.Interface;
using TicketSystem.ViewModel;

namespace TicketSystem.Repositories
{
    public class TicketRepository : ITicketRepository
    {

        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public TicketRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(TicketVM entity)
        {
            var ticket = _mapper.Map<Ticket>(entity);
            await _context.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task<IEnumerable<TicketVM>> GetAll()
        //{
        //    var tickets = await _context.Tickets.ToListAsync();
        //    return _mapper.Map<IEnumerable<TicketVM>>(tickets);
        //}

        public async Task<TicketVM?> GetById(string id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            return ticket != null ? _mapper.Map<TicketVM>(ticket) : null;
        }

        //public async Task<IEnumerable<TicketVM>?> GetByUserId(int UserId)
        //{
        //    var tickets = await _context.Tickets
        //                        .Where(t => t.CreatedBy == UserId)
        //                        .ToListAsync();
        //    return tickets != null ? _mapper.Map<List<TicketVM>>(tickets) : null;
        //}

        public async Task Update(TicketVM entity)
        {
            var existingTicket = await _context.Tickets.FindAsync(entity.TicketID);
            if (existingTicket != null)
            {
                _mapper.Map(entity, existingTicket);
                _context.Tickets.Update(existingTicket);
                await _context.SaveChangesAsync();

            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy User với ID = {entity.TicketID}");
            }
        }
        public async Task UpdateStatus(string ticketId, string newStatus)
        {
            var existingTicket = await _context.Tickets.FindAsync(ticketId);
            if (existingTicket != null)
            {
                existingTicket.Status = newStatus;
                existingTicket.UpdatedAt = DateTime.UtcNow; // Cập nhật thời gian sửa đổi

                _context.Tickets.Update(existingTicket);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy Ticket với ID = {ticketId}");
            }
        }
        public async Task UpdatePriority(string ticketId, string newPriority)
        {
            var existingTicket = await _context.Tickets.FindAsync(ticketId);
            if (existingTicket != null)
            {
                existingTicket.Priority = newPriority;
                existingTicket.UpdatedAt = DateTime.UtcNow; // Cập nhật thời gian sửa đổi

                _context.Tickets.Update(existingTicket);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy Ticket với ID = {ticketId}");
            }
        }
        public async Task UpdateIsFeedBack(string ticketId, Boolean newIsFeedBack)
        {
            var existingTicket = await _context.Tickets.FindAsync(ticketId);
            if (existingTicket != null)
            {
                existingTicket.IsFeedBack = newIsFeedBack;
                existingTicket.UpdatedAt = DateTime.UtcNow; // Cập nhật thời gian sửa đổi

                _context.Tickets.Update(existingTicket);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy Ticket với ID = {ticketId}");
            }
        }

        public async Task<IEnumerable<Ticket_SearchVM>> SearchTickets(
        string? ticketId,string? title, int? day, int? month, int? year,
        int? createdBy, int? departmentId, int? assignedTo)
        {
            var result = await _context.SearchTicketResults
       .FromSqlRaw("EXEC sp_SearchTickets @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
         ticketId ?? (object)DBNull.Value,
           title ?? (object)DBNull.Value,
           day ?? (object)DBNull.Value,
           month ?? (object)DBNull.Value,
           year ?? (object)DBNull.Value,
           createdBy ?? (object)DBNull.Value,
           departmentId ?? (object)DBNull.Value,
           assignedTo ?? (object)DBNull.Value)
       .ToListAsync();

            var tickets = result
                .GroupBy(t => new
                {
                    t.TicketID,
                    t.Title,
                    t.Description,
                    t.Priority,
                    t.Status,
                    t.CreatedBy,
                    t.CreatedByName,
                    t.CreatedByAvatar,
                    t.DepartmentID,
                    t.CategoryID,
                    t.CategoryName,
                    t.CreatedAt,
                    t.UpdatedAt,
                    t.DueDate,
                    t.IsFeedBack
                })
                .Select(group => new Ticket_SearchVM
                {
                    TicketID = group.Key.TicketID,
                    Title = group.Key.Title,
                    Description = group.Key.Description,
                    Priority = group.Key.Priority,
                    Status = group.Key.Status,
                    CreatedBy = group.Key.CreatedBy,
                    CreatedByName = group.Key.CreatedByName,
                    CreatedByAvatar = group.Key.CreatedByAvatar,
                    DepartmentID = group.Key.DepartmentID,
                    CategoryID = group.Key.CategoryID,
                    CategoryName = group.Key.CategoryName,
                    CreatedAt = group.Key.CreatedAt,
                    UpdatedAt = group.Key.UpdatedAt,
                    DueDate = group.Key.DueDate,
                    IsFeedBack = group.Key.IsFeedBack,
                    AssignedUsers = group
                        .Where(g => g.AssignmentID != null)
                        .Select(g => new AssignmentVM
                        {
                            AssignmentID = g.AssignmentID,
                            AssignedTo = g.AssignedTo,
                            FullName = g.FullName,
                            Avatar = g.Avatar
                        }).ToList()
                }).ToList();
            return tickets;

        }
        public async Task<IEnumerable<TicketVM>?> GetByDepartmentId(int departmentId)
        {
            var tickets = await _context.Tickets
                                .Where(t => t.DepartmentID == departmentId)
                                .ToListAsync();
            return tickets != null ? _mapper.Map<List<TicketVM>>(tickets) : null;
        }

      
    }
}
