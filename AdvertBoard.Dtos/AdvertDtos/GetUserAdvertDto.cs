using System;

namespace AdvertBoard.Dtos.AdvertDtos
{
    public class GetUserAdvertDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
    }
}