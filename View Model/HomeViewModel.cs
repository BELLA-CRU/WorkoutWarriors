using WorkoutWarriors.Models;

namespace WorkoutWarriors.View_Model
{
    public class HomeViewModel
    {
        public IEnumerable<Gym> Gyms { get; set; }

        public string City { get; set; }
        public string State { get; set; }



    }
}
