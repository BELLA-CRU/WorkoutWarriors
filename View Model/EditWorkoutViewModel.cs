using WorkoutWarriors.Data.Enum;
using WorkoutWarriors.Models;

namespace WorkoutWarriors.View_Model
{
    public class EditWorkoutViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public WorkoutType WorkoutType { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public int? EntryFee { get; set; }
        public string? Website { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }

    }
}
