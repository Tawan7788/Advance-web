using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebAPIforstd.Models
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
