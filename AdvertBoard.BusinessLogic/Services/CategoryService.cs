using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using AdvertBoard.BusinessLogic.Services.Interfaces;
using AdvertBoard.DbAccess.Interfaces;
using AdvertBoard.DbAccess.Models;
using AdvertBoard.Dtos;
using AutoMapper;

namespace AdvertBoard.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDto> GetCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            var categoriesDto = _mapper.Map<List<Category>, List<CategoryDto>>(categories);

            return categoriesDto;
        }

        public List<AdvertDto> GetAdvertsFromCategory(string categoryName, string userId)
        {
            var advertsFormCategory = _categoryRepository.GetAllAdvertsFromCategory(categoryName, userId);
            var advertsFromCategoryDto = _mapper.Map<List<Advert>, List<AdvertDto>>(advertsFormCategory);

            return advertsFromCategoryDto;
        }
    }
}