namespace TaskManager.Api.Models
{
    public class Desk : CommonObject
    {
        public int Id { get; set; }
        public bool IsPrivate { get; set; }
        public string Columns { get; set; }  // для хранения перечня столбцов в json
        public List<Problem> Problems { get; set; } = new List<Problem>();

        public int AdminId { get; set; }
        public User Admin { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
       
    }
}
