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
            var addAdvertViewModel = new AddAdvertViewModel()
            {
                Categories = GetCategories()
            };
            return View(addAdvertViewModel);
        }

        [HttpPost]
        public ActionResult AddAdvert(AddAdvertViewModel advertToAdd)
        {
            if (!ModelState.IsValid)
            {
                advertToAdd.Categories = GetCategories();
                return View(advertToAdd);
            }
            var userId = User.Identity.GetUserId();
            var advertToAddDto = _mapper.Map<AddAdvertViewModel, AddAdvertDto>(advertToAdd);
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

        public ActionResult EditAdvert(int id)
        {
            var advertToEdit = _advertService.GetAdvertToEdit(id);

            if (advertToEdit == null || !advertToEdit.OwnerId.Equals(User.Identity.GetUserId()))
            {
                return RedirectToAction("GetUserAdverts", "Advert");
            }
            var editAdvertViewModel = _mapper.Map<EditAdvertDto, EditAdvertViewModel>(advertToEdit);
            editAdvertViewModel.Categories = GetCategories();
            return View(editAdvertViewModel);
        }

        [HttpPost]
        public ActionResult EditAdvert(EditAdvertViewModel advertToEdit)
        {
            if (!ModelState.IsValid)
            {
                advertToEdit.Categories = GetCategories();
                return View(advertToEdit);
            }
            var advertToEditDto = _mapper.Map<EditAdvertViewModel, EditAdvertDto>(advertToEdit);
            _advertService.EditAdvert(advertToEditDto);
            return RedirectToAction("GetUserAdverts", "Advert");
        }

        [HttpPost]
        public ActionResult DeleteAdvert(int id)
        {

            return RedirectToAction("GetUserAdverts", "Advert");
        }

        public ActionResult ShowDetails(int id)
        {
            var advert = _advertService.GetAdvertDetails(id);
            if (advert == null)
            {
                return RedirectToAction("GetUserAdverts", "Advert");
            }
            var advertViewModel = _mapper.Map<GetDetailedAdvertDto, GetDetailedAdvertViewModel>(advert);
            return View(advertViewModel);
        }

        private List<CategoryViewModel> GetCategories()
        {
            var allCategories = _categoryService.GetCategories();
            var categoriesViewModel = _mapper.Map<List<CategoryDto>, List<CategoryViewModel>>(allCategories);
            return categoriesViewModel;
        }
    }
}