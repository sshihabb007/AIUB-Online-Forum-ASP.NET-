using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entity
{
    public class Complain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int complain_id { get; set; }
        [Required]
        public int from_user { get; set; }
        [ForeignKey("from_user")]
        public User user1 { get; set; }
        [Required]
        public int to_user { get; set; }
        [ForeignKey("to_user")]
        public User user2 { get; set; }
        [Required]
        public string complain { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public ComplainStatus status { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public NotificationStatus notification { get; set; }
    }
}
