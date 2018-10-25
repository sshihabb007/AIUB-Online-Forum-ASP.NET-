using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entity
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int comment_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }
        [Required]
        public int post_id { get; set; }
        [ForeignKey("post_id")]
        public Post post { get; set; }
        [Required]
        public string comment { get; set; }
        [Required]
        public CommentStatus status { get; set; }
    }
}
