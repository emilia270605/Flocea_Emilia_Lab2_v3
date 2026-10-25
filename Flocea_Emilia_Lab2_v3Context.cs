using Microsoft.EntityFrameworkCore;
using Flocea_Emilia_Lab2_v3.Models;

namespace Flocea_Emilia_Lab2_v3;

public class Flocea_Emilia_Lab2_v3Context : DbContext
{
    public Flocea_Emilia_Lab2_v3Context(DbContextOptions<Flocea_Emilia_Lab2_v3Context> options)
        : base(options)
    {
    }

    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Publisher> Publisher { get; set; } = default!;
    public DbSet<Author> Author { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<BookCategory> BookCategory { get; set; } = default!;
}