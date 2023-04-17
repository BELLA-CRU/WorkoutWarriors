namespace WorkoutWarriors.View_Model
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int? MaxDeadLift { get; set; }
        public int? MaxBenchPress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Image { get; set; }
    }
}
