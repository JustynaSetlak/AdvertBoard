using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace AdvertBoard.Models.Advert
{
    public class AddAdvertViewModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(700)]
        public string Details { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

    }
}