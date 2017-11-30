using System;
using System.ComponentModel.DataAnnotations;

namespace AdvertBoard.Models.Advert
{
    public class GetUserAdvertViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryViewModel Category { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfCreation { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfLastModification { get; set; }
    }
}