using System.Data.Common;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<ApplicationForm> ApplicationForms { get; set; }
    public DbSet<Test> Tests { get; set; }

}