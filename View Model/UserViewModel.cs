namespace WorkoutWarriors.View_Model
{
    public class UserViewModel
    {
        public string Id { get; set; }  
        public string UserName { get; set; }
        public int? MaxDeadLift { get; set; }
        public int? MaxBenchPress { get; set; }

        public string? Image { get; set; }

    }
}
