using Forum.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Users:IDisposable
    {
        public int Id { get; set; }
        public String user_name { set; get; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NewPassword { set; get; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public string Religion { get; set; }
        public string Address { get; set; }
        [Range(0,4,ErrorMessage ="CGPA Must Be in Valied Range")]
        public double CGPA { get; set; }
        public Department Department { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastLogout { get; set; }
        public DateTime LastPost { get; set; }
        public UserStatus Status { get; set; }
        public UserType UserType { get; set; }
        public string PhotoUrl { set; get; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}