namespace AdvertBoard.Dtos.CommentDtos
{
    public class CommentDto
    {
        public string Content { get; set; }
        public GetCommentOwnerDto Owner { get; set; }

        public string OwnerId { get; set; }
        public int AdvertId { get; set; }
    }
}