using System;

namespace AdvertBoard.Models.Advert
{
    public class GetDetailedAdvertViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public UserViewModel Owner { get; set; }
        public CategoryViewModel Category { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
    }
}