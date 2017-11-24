using System;
using Microsoft.Build.Framework.XamlTypes;

namespace AdvertBoard.Dtos.AdvertDtos
{
    public class AddAdvertDto
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string OwnerId { get; set; }
        public UserDto Owner { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
    }
}