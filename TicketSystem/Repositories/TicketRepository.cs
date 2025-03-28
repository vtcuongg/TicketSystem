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

        public async Task Delete(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TicketVM>> GetAll()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return _mapper.Map<IEnumerable<TicketVM>>(tickets);
        }

        public async Task<TicketVM?> GetById(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            return ticket != null ? _mapper.Map<TicketVM>(ticket) : null;
        }

        public async Task<IEnumerable<TicketVM>?> GetByUserId(int UserId)
        {
            var tickets = await _context.Tickets
                                .Where(t => t.CreatedBy == UserId)
                                .ToListAsync();
            return tickets != null ? _mapper.Map<List<TicketVM>>(tickets) : null;
        }

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
    }
}
