using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Api.Models
{
    public class Desk : CommonObject
    {
        public int Id { get; set; }
        public bool IsPrivate { get; set; }
        public string Columns { get; set; }  // для хранения перечня столбцов в json

        public User Admin { get; set; }
        public int AdminId { get; set; }


        public Project Project { get; set; }
        public int ProjectId { get; set; }
       
        public List<Problem> Problems { get; set; } = new List<Problem>();
    }


}
