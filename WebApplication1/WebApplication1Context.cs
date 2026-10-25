
using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

public class WebApplication1Context : DbContext
{
    public WebApplication1Context(
        DbContextOptions<WebApplication1Context> options)
        : base(options)
    {
    }

    public DbSet<Book> Book { get; set; } = default!;

    public DbSet<Publisher> Publisher { get; set; } = default!;

    public DbSet<Authors> Authors { get; set; } = default!;

    public DbSet<Category> Category { get; set; } = default!;

    public DbSet<BookCategory> BookCategory { get; set; } = default!;
}
