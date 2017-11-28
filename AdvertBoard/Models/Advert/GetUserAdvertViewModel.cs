﻿using System;
using AdvertBoard.Dtos;

namespace AdvertBoard.Models.Advert
{
    public class GetUserAdvertViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryViewModel Category { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
    }
}