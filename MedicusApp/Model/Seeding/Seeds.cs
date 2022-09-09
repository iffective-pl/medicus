﻿using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace MedicusApp.Models.Seeding
{
    public class Seeds
    {
        public Seeds()
        {
            using (Stream reader = File.OpenRead("Data/doctors.json"))
                this.DoctorSeeds = JsonSerializer.Deserialize<List<DoctorSeed>>(reader) ?? new List<DoctorSeed>();
            using (Stream reader = File.OpenRead("Data/specs.json"))
                this.SpecSeeds = JsonSerializer.Deserialize<List<SpecSeeding>>(reader) ?? new List<SpecSeeding>();
            using (Stream reader = File.OpenRead("Data/doctorspec.json"))
                this.DoctorSpecSeeds = JsonSerializer.Deserialize<List<DoctorSpecSeed>>(reader) ?? new List<DoctorSpecSeed>();
            using(Stream reader = File.OpenRead("Data/workinghours.json"))
                this.WorkingHoursSeeds = JsonSerializer.Deserialize<List<WorkingHoursSeed>>(reader) ?? new List<WorkingHoursSeed>();
        }

        public List<DoctorSeed> DoctorSeeds { get; private set; }
        public List<SpecSeeding> SpecSeeds { get; private set; }
        public List<DoctorSpecSeed> DoctorSpecSeeds { get; private set; }
        public List<WorkingHoursSeed> WorkingHoursSeeds { get; private set; }
    }
}