﻿using MedicusApp.Models.Dto;
using MedicusApp.Models.Dto.Person;
using MedicusApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicusApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService service;

        public DoctorController(IDoctorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<int> GetDoctors()
        {
            return service.GetDoctors();
        }
        
        [HttpGet]
        public DoctorDto GetDoctor(int doctorId)
        {
            return service.GetDoctor(doctorId);
        }

        [HttpGet]
        public IEnumerable<SpecDto> GetAvailableSpecs(int doctorId)
        {
            return service.GetAvailableSpecs(doctorId);
        }

        [HttpPost]
        public bool UpdateDoctor(DoctorDto doctor)
        {
            return service.UpdateDoctor(doctor);
        }

        [HttpPost]
        public bool UpdateWorkingHours(WorkingHoursDto workingHours)
        {
            return service.UpdateWorkingHours(workingHours);
        }

        [HttpPut]
        public bool AddDoctor(DoctorDto doctor)
        {
            return service.AddDoctor(doctor);
        }

        [HttpPut]
        public bool AddSpec(int doctorId, int specId)
        {
            return service.AddSpec(doctorId, specId);
        }

        [HttpDelete]
        public bool DeleteDoctor(int doctorId)
        {
            return service.DeleteDoctor(doctorId);
        }

        [HttpDelete]
        public bool DeleteSpec(int doctorId, int specId)
        {
            return service.DeleteSpec(doctorId, specId);
        }
    }
}
