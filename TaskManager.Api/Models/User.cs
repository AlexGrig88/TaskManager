using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Common.Models;
using TaskManager.Common.Models.Enums;

namespace TaskManager.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(120)]
        public string Email { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }

        public string? Phone { get; set; }

        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public byte[]? Photo { get; set; }
        
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Desk> Desks { get; set; } = new List<Desk>();
        public List<Problem> Problems { get; set; } = new List<Problem>();

        public UserStatus Status { get; set; }

        public User() { }
        public User(string fName, string lName, string email, string pass,
                     UserStatus status = UserStatus.User, string phone = null, byte[] photo = null)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;
            Password = pass;
            Phone = phone;
            Status = status;
            Photo = photo;
            RegistrationDate = DateTime.UtcNow;
        }

        public User(UserDto userDto) : this(userDto.FirstName, userDto.LastName, userDto.Email,
                                            userDto.Password, userDto.Status, userDto.Phone, userDto.Photo)
        { }

        public UserDto ToDto()
        {
            return new UserDto() { 
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                Phone = this.Phone,
                Status = this.Status,
                Photo = this.Photo, 
                RegistrationDate = this.RegistrationDate
            };
        }

        public void FromUserDto(UserDto userDto)
        {
            this.FirstName = userDto.FirstName;
            this.LastName = userDto.LastName;
            this.Email = userDto.Email;
            this.Password = userDto.Password;
            this.Phone = userDto.Phone;
            this.Status = userDto.Status;
            this.Photo = userDto.Photo;
            this.RegistrationDate = userDto.RegistrationDate;
        }

    }
}
