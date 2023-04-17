using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutWarriors.Models
{
    public class AppUser : IdentityUser
    {
        public int? MaxDeadlift { get; set; }  

        public int? MaxBenchPress { get; set; }

        public string? Image { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public Address? Address { get; set; }

        public ICollection<Gym> Gyms { get; set; }

        public ICollection<Workout> Workouts { get; set; }
    }
}
