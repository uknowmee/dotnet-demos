using Demos.Database.Books.Entities;

namespace Demos.Database.Books.Model;

public class UnknownAuthor : Author
{
    public UnknownAuthor() : base("Unknown") => Id = Guid.Empty;
}