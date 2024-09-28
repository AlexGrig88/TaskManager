namespace TaskManager.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public byte[]? Photo { get; set; }
        public UserStatus Status { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Desk> Desks { get; set; } = new List<Desk>();
        public List<Problem> Problems { get; set; } = new List<Problem>();

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

    }
}
