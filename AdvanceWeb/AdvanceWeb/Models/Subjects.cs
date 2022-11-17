using System.ComponentModel.DataAnnotations;

namespace DemoWebAPIforstd.Models
{
    public class Subjects
    {
        [Key]
        public int suid { get; set; }
        [Required]
        public string? subname { get; set; }


    }
}
