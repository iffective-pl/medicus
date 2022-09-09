﻿using MedicusApp.Models.Dto;

namespace MedicusApp.Repositories
{
    public interface ISpecRepository
    {
        public IEnumerable<SpecDto> GetSpecs();
    }
}
