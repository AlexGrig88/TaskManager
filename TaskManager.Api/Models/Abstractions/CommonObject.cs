using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Models
{
    public class CommonObject
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[]? Image { get; set;}

        public CommonObject() => CreationDate = DateTime.UtcNow;
    }
}
