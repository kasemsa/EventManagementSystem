using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Repositories
{
    public interface IEventRepository:IBaseRepository<Event>
    {
        Task<Event> GetEventWithUsers(int eventId);
        Task<int> GetNumberOfTicket(int id);
    }
}
