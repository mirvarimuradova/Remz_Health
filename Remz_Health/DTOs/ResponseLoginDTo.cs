namespace Remz_Health.DTOs
{
    public class ResponseLoginDTo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly Birthdate { get; set; }
        public string FIN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public IFormFile ImagePath { get; set; }
        public string Gender { get; set; }

       
    }
}
