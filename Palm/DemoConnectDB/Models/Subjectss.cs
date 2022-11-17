using System.ComponentModel.DataAnnotations;

namespace AdvanceWeb.Models
{
    public class Subjects
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string subid { get; set; }
        [Required]
        public string? subname { get; set; }



    }
}
