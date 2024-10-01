using TaskManager.Api.Models.Enums;

namespace TaskManager.Api.Models
{
    public class Project : CommonObject
    {
        public int Id { get; set; }
        public List<User> AllUsers { get; set; } = new List<User>();
        public List<Desk> AllDesks { get; set; } = new List<Desk> { };
        public ProjectStatus status { get; set; }

        public int ProjectAdminId { get; set; }
        public ProjectAdmin ProjectAdmin { get; set; }
    }
}
