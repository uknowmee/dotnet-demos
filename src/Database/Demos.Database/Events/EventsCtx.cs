using Demos.Database.Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demos.Database.Events;

public class EventsCtx : DbContext
{
    public EventsCtx(DbContextOptions<EventsCtx> options) : base(options)
    {
    }
    
    public DbSet<Event> Events { get; set; } = null!;
}