namespace AdvertBoard.DbAccess.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}