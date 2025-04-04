using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remz_Health.DAL.Data;
using Remz_Health.DTOs;
using Remz_Health.Models;
using Remz_Health.Services;

namespace Remz_Health.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly RemzContext _context;
        private readonly PatientServices _patientServices;


        public PatientsController(RemzContext context, PatientServices patientServices)
        {
            _context = context;
            _patientServices = patientServices;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {

            return await _context.Patients.ToListAsync();
        }
        [HttpGet("GetUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email daxil edilməyib.");
            }

            // Aşağıdakı addımda email-i normalize edirik
            var normalizedEmail = email.Trim().ToLower();

            var patient = _context.Patients.FirstOrDefault(p => p.Email.Trim().ToLower() == normalizedEmail);
            var phone = _context.Phones.FirstOrDefault(p => p.Id == patient.PhoneId).PhoneNumber;
            if (patient != null)
            {
                return Ok(new { userType = "patient", patient.Id, patient.Email, patient.Name, patient.Password,
                    phone,
                    patient.Surname,
                    patient.Fin
                });
            }
            return NotFound("İstifadəçi tapılmadı.");
        }


        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Patient> PostPatient([FromForm] PatientCreateDTO patientdto)
        {


            bool servisstatus = _patientServices.AddPatient(patientdto);


            if (!servisstatus) { 
            
            return BadRequest();
            }
           
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto loginDto)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Email == loginDto.Email);

            if (patient == null || patient.Password != loginDto.Password)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            var response = new
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Phone =  patient.Phone.PhoneNumber,
                Role = "Patient"
            };

            return Ok(response);
        }


        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
