using System;
using System.ComponentModel.DataAnnotations;
using AdvertBoard.Dtos;

namespace AdvertBoard.Models.Advert
{
    public class GetUserAdvertViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryViewModel Category { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfLastModification { get; set; }
    }
}