using Microsoft.EntityFrameworkCore;

public class Flocea_Emilia_Lab2_v3Context(DbContextOptions<Flocea_Emilia_Lab2_v3Context> options) : DbContext(options)
{
    public DbSet<Flocea_Emilia_Lab2_v3.Models.Book> Book { get; set; } = default!;
    public DbSet<Flocea_Emilia_Lab2_v3.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Flocea_Emilia_Lab2_v3.Models.Author> Author { get; set; } = default!;
}
