using System.Collections.Generic;

namespace AdvertBoard.Models.Advert
{
    public class AdvertToAddViewModel
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}