using WorkoutWarriors.Data.Enum;
using WorkoutWarriors.Models;

namespace WorkoutWarriors.View_Model
{
    public class EditGymViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }   
        public string Description { get; set; }
        public string Image { get; set; }
        public GymType gymType { get; set; }

        public int? AddressId { get; set; }

        public Address Address { get; set; }
    }
}
