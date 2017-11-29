using System;
using System.ComponentModel.DataAnnotations;

namespace AdvertBoard.Models.Advert
{
    public class GetDetailedAdvertViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public UserViewModel Owner { get; set; }
        public CategoryViewModel Category { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of creation")]
        public DateTime DateOfCreation { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of last modification")]
        public DateTime DateOfLastModification { get; set; }
    }
}