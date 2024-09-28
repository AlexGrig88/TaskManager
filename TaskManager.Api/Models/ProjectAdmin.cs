namespace TaskManager.Api.Models
{
    public class ProjectAdmin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();


        public ProjectAdmin() { }

        public ProjectAdmin(User user) 
        { 
            Id = user.Id;
            User = user;
        }
    
    }
}
