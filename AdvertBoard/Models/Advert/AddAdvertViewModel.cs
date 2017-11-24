using System.Collections.Generic;
using System.Security.AccessControl;

namespace AdvertBoard.Models.Advert
{
    public class AddAdvertViewModel
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public int CategoryId { get; set; }        
    }
}