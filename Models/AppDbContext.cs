using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AppointmentsManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
              : base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }


    }
}
