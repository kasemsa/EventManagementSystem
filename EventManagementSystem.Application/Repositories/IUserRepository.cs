using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Repositories
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<bool> LoginUser(string email,string password);

        Task BookedTickt(int EventId,int UserId);
        Task<User> GetUserWithBookedEvent(int id);
       

    }
}
