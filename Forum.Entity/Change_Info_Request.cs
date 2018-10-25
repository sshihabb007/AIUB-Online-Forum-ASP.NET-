using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Entity
{
    public class Change_Info_Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int request_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }
        [Required]
        public FieldName field_name { get; set; }
        [Required]
        public string field_value { get; set; }
        [Required]
        public RequestStatus status { get; set; }
    }
}
