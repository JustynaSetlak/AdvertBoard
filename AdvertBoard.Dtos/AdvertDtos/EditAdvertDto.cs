using System;

namespace AdvertBoard.Dtos.AdvertDtos
{
    public class EditAdvertDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string OwnerId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
    }
}