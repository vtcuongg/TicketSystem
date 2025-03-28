using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Repositories.Interface;
using TicketSystem.ViewModel;

namespace TicketSystem.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(RoleVM entity)
        {
            var role = _mapper.Map<Role>(entity);
            await _context.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RoleVM>> GetAll()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<RoleVM>>(roles);
        }

        public async Task<RoleVM?> GetById(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role != null ? _mapper.Map<RoleVM>(role) : null;
        }

        public async Task Update(RoleVM entity)
        {
            var existingRole = await _context.Users.FindAsync(entity.RoleID);
            if (existingRole != null)
            {
                _mapper.Map(entity, existingRole);
                _context.Users.Update(existingRole);
                await _context.SaveChangesAsync();

            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy User với ID = {entity.RoleID}");
            }
        }
    }

}
