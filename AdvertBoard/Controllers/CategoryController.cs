using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvertBoard.BusinessLogic.Services.Interfaces;
using AdvertBoard.Dtos;
using AdvertBoard.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace AdvertBoard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public ActionResult GetCategories()
        {
            var categories = _categoryService.GetCategories();
            var model = _mapper.Map<List<CategoryDto>, List<CategoryViewModel>>(categories);
            return View(model);
        }

        public ActionResult GetAdvertsFromCategory(CategoryViewModel categoryViewModel)
        {
            var userId = User.Identity.GetUserId();
            var advertsInCategory = _categoryService.GetAdvertsFromCategory(categoryViewModel.Name, userId);
            var advertsDto = _mapper.Map<List<AdvertDto>, List<AdvertDto>>(advertsInCategory);
            return View(advertsDto);
        }
    }
}