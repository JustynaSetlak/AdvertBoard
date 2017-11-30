using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AdvertBoard.BusinessLogic.Services.Interfaces;
using AdvertBoard.Dtos.CommentDtos;
using AdvertBoard.Models.Comment;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace AdvertBoard.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public ActionResult GetAll(int id)
        {
            var commentsDto = _commentService.GetComments(id);
            var commentsViewModel = _mapper.Map<List<CommentDto>, List<CommentViewModel>>(commentsDto);
            ViewBag.advertId = id;
            return View(commentsViewModel);
        }

        public ActionResult Add(CommentViewModel comment)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userId = User.Identity.GetUserId();
            var commentToAdd = _mapper.Map<CommentViewModel, CommentDto>(comment);
            var commentDto = _commentService.AddComment(commentToAdd, userId);
            var commmentViewModel = _mapper.Map<CommentDto, CommentViewModel>(commentDto);
            return PartialView("_Comment", commmentViewModel);
        }
    }
}