using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remz_Health.DAL.Data;
using Remz_Health.DTOs;
using Remz_Health.Models;

namespace Remz_Health.Services
{
    public class LoginService
    {
        private readonly RemzContext _context;

        public LoginService(RemzContext context)
        {
            _context = context;
        }
        
        public bool CheckUser(LoginDto logindto)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Email == logindto.Email);

            if (patient == null || patient.Password != logindto.Password)
            {
                return false;
            }

            var phone = _context.Phones.FirstOrDefault(ph => ph.Id == patient.PhoneId);

            ResponseLoginDTo response = new ResponseLoginDTo
            {
                Name = patient.Name,
                Email = patient.Email,
                Phone = phone?.PhoneNumber,
                FIN = patient.Fin
            };

            return   true;
        }

    }
}
