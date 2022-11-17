using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebAPIforstd.Models
{
    public class Students
    {

        [Key]
        public int id { get; set; }
        [Required]
        public string stuid { get; set; }
        [Required]
        public string stuname { get; set; }
        [Required]
        public string stulastname { get; set; }
        [Required]
        public string stuaddress { get; set; }
        public string? stuphone { get; set; }
        [Required]
        public string stuimg { get; set; }
        [Required]
        public string GPA { get; set; }

    }
}
