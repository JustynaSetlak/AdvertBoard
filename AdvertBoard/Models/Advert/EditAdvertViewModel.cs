using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvertBoard.Models.Advert
{
    public class EditAdvertViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(1200)]
        public string Details { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public IList<CategoryViewModel> Categories { get; set; }
    }
}