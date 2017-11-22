using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Microsoft.Win32;

namespace AdvertBoard.DbAccess.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public int Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfCreating { get; set; }
        public User Author { get; set; }
    }
}