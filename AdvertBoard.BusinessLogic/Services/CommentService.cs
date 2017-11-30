using System;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<CommentDto> GetComments(int advertId)
        {
            var comments = _commentRepository.GetComments(advertId);
            var commentsDto = _mapper.Map<List<Comment>,List<CommentDto>>(comments);
            return commentsDto;
        }

        public CommentDto AddComment(CommentDto comment, string userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }
            var commentToAdd = _mapper.Map<CommentDto, Comment>(comment);
            commentToAdd.Owner = user;
            commentToAdd.OwnerId = userId;
            commentToAdd.DateOfCreation = DateTime.UtcNow;
            var commentAdded = _commentRepository.AddComment(commentToAdd);
            var addedCommentDto = _mapper.Map<Comment, CommentDto>(commentAdded);
            return addedCommentDto;
        }
    }
}