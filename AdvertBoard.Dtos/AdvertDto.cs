using System;

namespace AdvertBoard.Dtos
{
    public class AdvertDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public UserDto Owner { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}