using System.ComponentModel.DataAnnotations;

namespace FinalApi.Authorized.Models.SP
{
    public class UserRegistration
    {
        public int typeID { get; set; }
        public string firstName { get; set; }
        public string? lastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Invalid email address")]

        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "The password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
        ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string password { get; set; }
        public string conPassword { get; set; }

        public DateTime? dob { get; set; }
        public int roleID { get; set; }
        public bool ysnActive { get; set; }
        public string? uniqID { get; set; } 
        public string? softwareID { get; set; }
        public string? tokenID { get; set; }
    }
}
