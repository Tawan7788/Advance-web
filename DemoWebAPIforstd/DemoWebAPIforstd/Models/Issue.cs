using System.ComponentModel.DataAnnotations;

namespace DemoWebAPIforstd.Models
{
    public class Issue
    {
        public int Id { get;  set; }
        [Required]
        public string Title { get; set;}
        [Required]
        public string Description { get; set;}
       
        public Priority Priority { get; set;}
        public IssuType IssuType { get; set;}
        public DateTime Create { get; set;}
        public DateTime? Completed { get; set;}    


    }
    public enum Priority
    { 
        Lo,Medium,High
    }
    public enum IssuType
    { 
        Feature,Decumentation,Bug
    }
}
