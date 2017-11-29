using System.Collections.Generic;
using System.Web.Mvc;
using AdvertBoard.BusinessLogic.Services.Interfaces;
using AdvertBoard.Dtos.CommentDtos;
using AdvertBoard.Models.Comment;
using AutoMapper;

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
            return View(commentsViewModel);
        }

        public ActionResult Add(CommentViewModel comment)
        {
            return PartialView("_Comment", new CommentViewModel{Content = "elo"});
        }
    }
}