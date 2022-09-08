﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicusApp.Models
{
    public class WorkingHours
    {
        [Key]
        public int Id { get; set; }
        public string? Monday { get; set; }
        public string? Tuesday { get; set; }
        public string? Wednesday { get; set; }
        public string? Thursday { get; set; }
        public string? Friday { get; set; }

        public Doctor Doctor { get; set; }
        public Spec Specialization { get; set; }
    }
}
