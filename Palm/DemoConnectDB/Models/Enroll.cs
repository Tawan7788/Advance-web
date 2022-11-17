﻿using System.ComponentModel.DataAnnotations;

namespace AdvanceWeb.Models
{
    public class Enroll
    {
        [Key]
        public int enid { get; set; }
        [Required]
        public string stbid { get; set; }
        [Required]
        public string subid { get; set; }
        public string grade { get; set; }



    }

}
