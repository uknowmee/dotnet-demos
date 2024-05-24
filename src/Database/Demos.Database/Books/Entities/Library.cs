namespace Demos.Database.Books.Entities;

public class Library
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();
    
    [Obsolete("Only for EF", true)]
    public Library()
    {
    }
    
    public Library(string name) => Name = name;
}