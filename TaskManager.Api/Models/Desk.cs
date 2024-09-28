namespace TaskManager.Api.Models
{
    public class Desk : CommonObject
    {
        public int Id { get; set; }
        public bool IsPrivate { get; set; }
        public string Columns { get; set; }  // для хранения перечня столбцов в json
        public User Admin { get; set; }
    }
}
