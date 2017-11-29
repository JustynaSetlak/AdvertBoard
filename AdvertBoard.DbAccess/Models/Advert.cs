using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertBoard.DbAccess.Models
{
    public class Advert
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(700)]
        public string Details { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
