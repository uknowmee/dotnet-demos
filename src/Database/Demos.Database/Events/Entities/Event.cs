namespace Demos.Database.Events.Entities;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.MinValue.ToUniversalTime();
    
    [Obsolete("Only for EF", true)]
    public Event()
    {
    }
    
    public Event(string name, DateTime date)
    {
        if (date.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("Date must be in UTC", nameof(date));
        }
        
        Name = name;
        Date = date;
    }
}