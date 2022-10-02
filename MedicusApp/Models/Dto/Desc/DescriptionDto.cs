﻿using MedicusApp.Models.Control;

namespace MedicusApp.Models.Dto.Desc
{
    public class DescriptionDto : Sort
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public IEnumerable<DescriptionTextDto>? DescriptionTexts { get; set; }

        public int? SpecId { get; set; }
        public int? StaticId { get; set; }
    }
}