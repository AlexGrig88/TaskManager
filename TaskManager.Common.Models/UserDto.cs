
using TaskManager.Common.Models.Enums;

namespace TaskManager.Common.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }

        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public byte[]? Photo { get; set; }
        public UserStatus Status { get; set; }

        public UserDto() { }

        public UserDto(string fName, string lName, string email, string pass,
                    UserStatus status = UserStatus.User, string phone = null)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;
            Password = pass;
            Phone = phone;
            Status = status;
            RegistrationDate = DateTime.UtcNow;
        }
    }
}
