using EventManagementSystem.Application.Repositories;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Persistence.Repositories
{
    public class EventRepository :BaseRepository<Event>, IEventRepository
    {
        public EventRepository(DataContext context) : base(context)
        {
        }

        public async Task<Event> GetEventWithUsers(int eventId)
        {
            //var allEvents =await _context.Events.Include(u=>u.users).ToListAsync();
            var @event = await _context.Events.Include(e => e.users).FirstOrDefaultAsync(e => e.EventId == eventId);
            return @event;
        }

    

        public async Task<int> GetNumberOfTicket(int id)
        {
            var @event =await _context.Set<Event>().FindAsync(id);
            
            return @event.NumberOfTicket;
        }

    
    }
}
