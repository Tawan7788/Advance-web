using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceWeb.Models
{
    public class Student
    {

        public int id { get; set; }
        public string stuid { get; set; }
        public string stuname { get; set; }
        public string stulastname { get; set; }
        public string stuaddress { get; set; }
        public string stuphone { get; set; }

        public string stuimg { get; set; }
        public double GPA { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
