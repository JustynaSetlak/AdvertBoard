using System.Collections.Generic;
using AdvertBoard.Dtos.CommentDtos;

namespace AdvertBoard.BusinessLogic.Services.Interfaces
{
    public interface ICommentService
    {
        List<CommentDto> GetComments(int advertId);
        CommentDto AddComment(CommentDto comment, string userId);
    }
}