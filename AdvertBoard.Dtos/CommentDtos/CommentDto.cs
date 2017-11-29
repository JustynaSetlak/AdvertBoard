namespace AdvertBoard.Dtos.CommentDtos
{
    public class CommentDto
    {
        public string Content { get; set; }
        public GetCommentOwnerDto CommentOwnerDto { get; set; }
        public int AdvertId { get; set; }
    }
}