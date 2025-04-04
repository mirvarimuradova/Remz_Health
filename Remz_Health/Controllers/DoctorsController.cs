using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remz_Health.DAL.Data;
using Remz_Health.Models;

namespace Remz_Health.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly RemzContext _context;

        public DoctorsController(RemzContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {

            var doctors = await _context.Doctors
    .Select(d => new
    {
        d.Id,
        d.Name,
        d.Surname,
        d.Email,
        d.Fin,
        d.Experience,
        d.University,
        d.BirthDate,
        d.Gender,
        Hospital = new { d.Hospital.Id, d.Hospital.HospitalName },  // Yalnız lazımi hissələri çəkirik
        Speciality = new { d.Speciality.Id, d.Speciality.SpecialityName },
        Phone = d.Phone.PhoneNumber
    })
    .ToListAsync();

            return Ok(doctors);



            //return await _context.Doctors.ToListAsync();
        }
        [HttpGet("GetUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Email == email);
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Id == doctor.HospitalId).HospitalName;
            var phone = _context.Phones.FirstOrDefault(p => p.Id == doctor.PhoneId).PhoneNumber;

            if (doctor != null)
            {
                return Ok(new { userType = "doctor", doctor.Id, doctor.Email, doctor.Name, doctor.PasswordHash ,
                
                doctor.BirthDate, hospital, doctor.Surname, phone});
            }

            return NotFound("İstifadəçi tapılmadı.");
        }


        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
