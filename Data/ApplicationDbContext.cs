using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WorkoutWarriors.Models;

namespace WorkoutWarriors.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Address> Addresses { get; set; }
     
    }
}
