using System.ComponentModel.DataAnnotations;

namespace DemoWebAPIforstd.Models
{
    public class Subjectss
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string subid { get; set; }
        [Required]
        public string? subname { get; set; }


    }
}
