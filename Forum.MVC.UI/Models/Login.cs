using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Username must not empty")]
        [EmailAddress]
        public String Username { set; get; }
        [Required(ErrorMessage = "Password must not empty")]
        public String Passrowd { set; get; }
    }
}