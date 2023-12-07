using EventManagementSystem.Application.Repositories;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task BookedTickt(int EventId, int UserId)
        {
            var @event = await _context.Events.FindAsync(EventId);

            var user =await _context.Users.FindAsync(UserId);
            if (@event != null && user != null)
            {
                @event.users.Add(user);
                @event.NumberOfTicket--;

                await _context.SaveChangesAsync();
            }
           

        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserWithBookedEvent(int id)
        {
            var user = await _context.Users.Include(u=>u.events).FirstOrDefaultAsync(u=>u.UserId==id);

            return user;
           
            
        }

        public async Task<bool> LoginUser(string email,string password)
        {
            var user =await GetUserByEmail(email);
            if (user == null)
            {
                return false;
            }
            else {
                if (user.Password == password)
                {
                    return Authorization.ReferenceEquals(user.Password, password);
                }
                else {
                    return false;
                }
            }


            
        }
    }
}
