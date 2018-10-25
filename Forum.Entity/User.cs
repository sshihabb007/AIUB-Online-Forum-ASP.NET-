using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int user_id { get; set; }
        [Required]
        public UserType user_type { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string full_name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        public double cgpa { get; set; }
        [Required]
        public Department department { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public BloodGroup blood_group { get; set; }
        [Required]
        public string religion { get; set; }
        public string address { get; set; }
        public string photo { get; set; }
        public UserStatus status { get; set; }
        public DateTime last_login { get; set; }
        public DateTime last_logout { get; set; }
        public DateTime last_posted { get; set; }
    }
}
