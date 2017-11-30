using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvertBoard.Models.Advert
{
    public class GetAdvertViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfCreation { get; set; }
    }
}