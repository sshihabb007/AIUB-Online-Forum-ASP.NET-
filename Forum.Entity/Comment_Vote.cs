using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entity
{
    public class Comment_Vote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int vote_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }
        [Required]
        public int comment_id { get; set; }
        [ForeignKey("comment_id")]
        public Comment comment { get; set; }
        [Required]
        public VoteStatus vote_status { get; set; }
    }
}
