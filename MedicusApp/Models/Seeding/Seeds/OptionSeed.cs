﻿namespace MedicusApp.Models.Seeding.Seeds
{
    public class OptionSeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public int Order { get; set; }

        public int LinkId { get; set; }
    }
}