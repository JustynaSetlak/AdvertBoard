﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertBoard.DbAccess.Models
{
    public class Advert
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Details { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public User Owner { get; set; }
    }
}