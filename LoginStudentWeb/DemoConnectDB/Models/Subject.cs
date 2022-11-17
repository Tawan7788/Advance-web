using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceWeb.Models
{
    public class Subjects
    {
        public int id { get; set; }
        public string subid { get; set; }
        public string subname { get; set; }
    }
}
