using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DemoWebAPIforstd.Models
{
    public class Student
    {
        [Key]
        public int stuid { get; set; }
        [Required]
        public string stuname { get; set; }
        [Required]
        public string stulastname { get; set; }
        [Required]
        public string stuaddress { get; set; }
        public string stuphone { get; set; }
        [Required]
        public string stuimg { get; set; }
        [Required]
        public float GPA { get; set; }
        

    }
}
