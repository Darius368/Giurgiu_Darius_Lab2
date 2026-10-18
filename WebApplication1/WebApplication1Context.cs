using Microsoft.EntityFrameworkCore;
using Nume_Pren_Lab2.Models;

public class WebApplication1Context(DbContextOptions<WebApplication1Context> options) : DbContext(options)
{
    public DbSet<Nume_Pren_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Publisher> Publisher { get; set; } = default!;

    public DbSet<Authors> Authors { get; set; } = default!;

}
