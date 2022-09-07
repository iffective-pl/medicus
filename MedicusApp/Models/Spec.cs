using MongoDB.Entities;

namespace MedicusApp.Model
{
    public class Spec : Entity
    {
        public string Name { get; set; }
        public string Href { get; set; }
        [OwnerSide]
        public Many<Doctor> Doctors { get; set; }
        [OwnerSide]
        public Many<WorkingHours> WorkHours { get; set; }

        public Spec()
        {
            this.InitManyToMany(() => Doctors, doctors => doctors.Specs);
        }
    }
}
