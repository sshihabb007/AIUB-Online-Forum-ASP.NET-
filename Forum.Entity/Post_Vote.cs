using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entity
{
    public class Post_Vote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int vote_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }
        [Required]
        public int post_id { get; set; }
        [ForeignKey("post_id")]
        public Post post { get; set; }
        [Required]
        public VoteStatus vote_status { get; set; }
    }
}
