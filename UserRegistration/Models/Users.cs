using System.ComponentModel.DataAnnotations;


namespace UserRegistration.Models
{
    public class Users 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
