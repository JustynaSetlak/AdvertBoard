using System.ComponentModel.DataAnnotations;

namespace AdvertBoard.Models.Comment
{
    public class CommentViewModel
    {
        [Required]
        [Display(Name = "Comment")]
        [StringLength(200)]
        public string Content { get; set; }
        public int AdvertId { get; set; }
        public UserViewModel Owner { get; set; }
    }
}