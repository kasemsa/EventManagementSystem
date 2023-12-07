using EventManagementSystem.Application.Repositories;
using EventManagementSystem.Domain.Common;
using EventManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        public BaseRepository(DataContext context) 
        {
            _context = context;
        
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> GetById(int Id)
        {
            T? t = await _context.Set<T>().FindAsync(Id);
            return t;
        }

        public async Task UpdateAsync(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
