using Application.Data;
using Application.Models.Domain;
using Application.Models.DTOs;
using Application.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto req)
        {
            // Map Dto to Domain
            var category = new Category
            {
                Name = req.Name,
                Url = req.Url
            };

            //Save to database
            await categoryRepository.CreateCategoryAsync(category);

            // Map Domain to Dto
            var response = new CategoryDto
            {
                Name = category.Name,
                Url = category.Url
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await categoryRepository.GetAllCategoryAsync();

            // Response
            var response = new List<CategoryDto>();

            foreach (var category in categories)
            {
                response.Add(new CategoryDto
                {
                    Name = category.Name,
                    Url = category.Url
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryByID([FromRoute] Guid id)
        {
            var existingCategory = await categoryRepository.GetCategoryById(id);

            if(existingCategory is null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Name = existingCategory.Name,
                Url = existingCategory.Url
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, CategoryDto req)
        {
            var category = new Category
            {
                Id = id,
                Name = req.Name,
                Url = req.Url
            };

            category = await categoryRepository.UpdateCategoryAsync(category);

            if(category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Name = category.Name,
                Url = category.Url
            };

            return Ok(response);
        }
    }
}
