using Demos.Database.Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demos.Database.Books;

public class BooksCtx : DbContext
{
    public BooksCtx(DbContextOptions<BooksCtx> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Library> Libraries { get; set; } = null!;
}