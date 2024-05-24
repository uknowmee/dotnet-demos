using Demos.Database.Books.Entities;

namespace Demos.Database.Books.Model;

public class UnknownLibrary : Library
{
    public UnknownLibrary() : base("Unknown") => Id = Guid.Empty;
}