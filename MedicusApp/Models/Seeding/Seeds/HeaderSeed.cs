﻿namespace MedicusApp.Models.Seeding.Seeds
{
    public class HeaderSeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public bool IsIndex { get; set; }
        public bool IsDropdown { get; set; }
        public bool IsPredefined { get; set; }
        public int Order { get; set; }
    }
}
