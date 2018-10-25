using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entity
{
    public class Reply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int reply_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }
        [Required]
        public int comment_id { get; set; }
        [ForeignKey("comment_id")]
        public Comment comment { get; set; }
        [Required]
        public string reply { get; set; }
    }
}
