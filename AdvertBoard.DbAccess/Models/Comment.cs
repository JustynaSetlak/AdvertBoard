using System;
using System.ComponentModel.DataAnnotations;

namespace AdvertBoard.DbAccess.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}