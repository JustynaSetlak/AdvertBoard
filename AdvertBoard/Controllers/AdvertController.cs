using System.Collections.Generic;
using System.Web.Mvc;
using AdvertBoard.BusinessLogic.Services.Interfaces;
using AdvertBoard.DbAccess.Models;
using AdvertBoard.Dtos;
using AdvertBoard.Models.Advert;
using AutoMapper;
using Microsoft.AspNet.Identity;
using AdvertBoard.Dtos.AdvertDtos;
using AdvertBoard.Models;

namespace AdvertBoard.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public AdvertController(IAdvertService advertService, IMapper mapper, ICategoryService categoryService)
        {
            _advertService = advertService;
            _categoryService = categoryService;
            _mapper = mapper;
        }


        public ActionResult AddAdvert()
        {
            var allCategories = _categoryService.GetCategories();
            var categoriesViewModel = _mapper.Map<List<CategoryDto>, List<CategoryViewModel>>(allCategories);
            var addAdvertViewModel = new AdvertToAddViewModel()
            {
                Categories = categoriesViewModel
            };
            return View(addAdvertViewModel);
        }

        [HttpPost]
        public ActionResult AddAdvert(AdvertToAddViewModel advertToAdd)
        {
            var userId = User.Identity.GetUserId();
            var advertToAddDto = _mapper.Map<AdvertToAddViewModel, AddAdvertDto>(advertToAdd);
            var addedAdvert = _advertService.AddAdvert(advertToAddDto, userId);
            if (addedAdvert == null)
            {
                return View(advertToAdd);
            }
            return RedirectToAction("GetUserAdverts", "Advert");
        }

        public ActionResult GetUserAdverts()
        {
            var userId = User.Identity.GetUserId();
            var userAdvertsDto = _advertService.GetAdvertsFromUser(userId);
            var userAdvertViewModelDtos = _mapper.Map<List<GetUserAdvertDto>, List<GetUserAdvertViewModel>>(userAdvertsDto);
            return View(userAdvertViewModelDtos);
        }
    }
}