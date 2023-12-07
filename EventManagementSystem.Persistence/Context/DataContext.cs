using EventManagementSystem.Domain.Common;
using EventManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        { 
        }

       public DbSet<User> Users { get; set; }
       public DbSet<Event> Events { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Email = "saudikasem@gmail.com",
                Name = "Kasem Saudi",
                Password = "123456789",
                Roll = "Admin",

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 2,
                Email = "Creator@gmail.com",
                Name = "Jack R",
                Password = "123456789",
                Roll = "Creator",

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 3,
                Email = "khalid@gmail.com",
                Name = "khalid",
                Password = "123456789",
                Roll = "user",
                events= new List<Event>
                {

                    
                }

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 4,
                Email = "IvanR@gmail.com",
                Name = "Ivan R",
                Password = "123456789",
                Roll = "user",
                events = new List<Event>
                {

                }

            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventDate = DateTime.Now,
                EventId = 1,
                EventName = "Party",
                EventLocation = "London",
                EventTime = DateTime.Now,
                NumberOfTicket = 15,
                users = new List<User>
                {
                   


                }



            });
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateUpdated = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DateDeleted = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
