using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AdvertBoard.DbAccess.Interfaces;
using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess.Implementation
{
    public class CommentRepository: ICommentRepository
    {
        private readonly AdvertBoardContext _context;

        public CommentRepository(AdvertBoardContext context)
        {
            _context = context;
        }

        public List<Comment> GetComments(int advertId)
        {
            return _context.Comments
                .Include(x => x.Owner)
                .Where(x => x.AdvertId == advertId)
                .OrderByDescending(x => x.DateOfCreation)
                .ToList();
        }

        public Comment AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }
    }
}