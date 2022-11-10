using AdminPanel.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Clinic> Clinics { get; set; }
}