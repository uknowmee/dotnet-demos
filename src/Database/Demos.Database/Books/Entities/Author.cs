namespace Demos.Database.Books.Entities;

public class Author
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();
    
    [Obsolete("Only for EF", true)]
    public Author()
    {
    }
    
    public Author(string name) => Name = name;
}