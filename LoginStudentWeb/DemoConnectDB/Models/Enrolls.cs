using System.ComponentModel.DataAnnotations;

namespace AdvanceWeb.Models
{
    public class Enrolls
    {
        [Key]
        public int enid { get; set; }
        [Required]
        public string studentid { get; set; }
        [Required]
        public string subjectid { get; set; }


    }

}
