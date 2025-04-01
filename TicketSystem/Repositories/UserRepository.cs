using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TicketSystem.Data;
using TicketSystem.Models;
using TicketSystem.Repositories.Interface;
using TicketSystem.ViewModel;

namespace TicketSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(UserModel entity)
        {
            var user = _mapper.Map<User>(entity);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserVM>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserVM>>(users);
        }

        public async Task<IEnumerable<UserVM>> GetByDepartmentId(int id)
        {
            var users = await _context.Users.Where(t => t.DepartmentID == id).ToListAsync();
            return _mapper.Map<IEnumerable<UserVM>>(users);
        }

        public async Task<UserVM?> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user != null ? _mapper.Map<UserVM>(user) : null;
        }

        public async Task Update(UserVM entity)
        {
            var existingUser = await _context.Users.FindAsync(entity.UserID);
            if (existingUser != null)
            {
                _mapper.Map(entity, existingUser);
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();

            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy User với ID = {entity.UserID}");
            }
        }

        public async Task UpdateDepartment(int userID, int DepartmentId)
        {
            var existingUser = await _context.Users.FindAsync(userID);
            if (existingUser != null)
            {
                existingUser.DepartmentID = DepartmentId;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy User với ID = {userID}");
            }

        }

        public async Task UpdateRole(int userID, int RoleId)
        {
            var existingUser = await _context.Users.FindAsync(userID);
            if (existingUser != null)
            {
                existingUser.RoleID = RoleId;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Không tìm thấy User với ID = {userID}");
            }
        }
    }
}
