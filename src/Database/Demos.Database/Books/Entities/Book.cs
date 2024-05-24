using Demos.Database.Books.Model;

namespace Demos.Database.Books.Entities;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    
    public Guid AuthorId { get; set; } = Guid.Empty;
    public Author Author { get; set; } = new UnknownAuthor();
    
    public Guid LibraryId { get; set; } = Guid.Empty;
    public Library Library { get; set; } = new UnknownLibrary();
    
    [Obsolete("Only for EF", true)]
    public Book()
    {
    }
    
    public Book(string title, Author author, Library library)
    {
        Title = title;
        Author = author;
        Library = library;
    }
}