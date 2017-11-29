using System.Collections.Generic;
using AdvertBoard.BusinessLogic.Services.Interfaces;
using AdvertBoard.DbAccess.Interfaces;
using AdvertBoard.DbAccess.Models;
using AdvertBoard.Dtos.CommentDtos;
using AutoMapper;

namespace AdvertBoard.BusinessLogic.Services
{
    public class CommentService: ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public List<CommentDto> GetComments(int advertId)
        {
            var comments = _commentRepository.GetComments(advertId);
            var commentsDto = _mapper.Map<List<Comment>,List<CommentDto>>(comments);
            return commentsDto;
        }

        public CommentDto AddComment(CommentDto comment)
        {
            var commentToAdd = _mapper.Map<CommentDto, Comment>(comment);
            var commentAdded = _commentRepository.AddComment(commentToAdd);
            var addedCommentDto = _mapper.Map<Comment, CommentDto>(commentAdded);
            return addedCommentDto;
        }
    }
}