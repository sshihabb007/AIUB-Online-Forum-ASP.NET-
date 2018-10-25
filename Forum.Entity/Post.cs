using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entity
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int post_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string body { get; set; }
        [Required]
        public string tags { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public PostStatus status { get; set; }
        [Required]
        public PostActivity activity { get; set; }
    }
}
