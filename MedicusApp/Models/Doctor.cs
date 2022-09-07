using MongoDB.Entities;

namespace MedicusApp.Model
{
    public class Doctor : Entity
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        [InverseSide]
        public Many<Spec> Specs { get; set; }
        [OwnerSide]
        public Many<WorkingHours> WorkingHours { get; set; }

        public Doctor()
        {
            this.InitManyToMany(() => Specs, spec => spec.Doctors);
            this.InitOneToMany(() => WorkingHours);
        }
    }
}
