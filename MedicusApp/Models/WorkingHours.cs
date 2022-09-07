using MongoDB.Entities;

namespace MedicusApp.Model
{
    public class WorkingHours : Entity
    {
        public string? Monday { get; set; }
        public string? Tuesday { get; set; }
        public string? Wednesday { get; set; }
        public string? Thursday { get; set; }
        public string? Friday { get; set; }

        [InverseSide]
        public Doctor Doctor { get; set; }
        [InverseSide]
        public Spec Spec { get; set; }
    }
}
