using System.Collections.Generic;
using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess.Interfaces
{
    public interface ICommentRepository
    {
        List<Comment> GetComments(int advertId);
        Comment AddComment(Comment comment);
    }
}