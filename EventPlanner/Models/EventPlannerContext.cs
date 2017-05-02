using Microsoft.EntityFrameworkCore;
 
namespace EventPlanner.Models
{
    public class EventPlannerContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public EventPlannerContext(DbContextOptions<EventPlannerContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Invite> invites { get; set; }
        public DbSet<Event> events { get; set; }        
    }
}