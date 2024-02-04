using Microsoft.EntityFrameworkCore;
using SpotifyMVC.Models;

namespace SpotifyMVC.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Song> Songs => Set<Song>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Singer> Singers => Set<Singer>();
    public DbSet<Album> Albums => Set<Album>();
}