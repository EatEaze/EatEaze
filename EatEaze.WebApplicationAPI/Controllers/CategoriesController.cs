using EatEazeServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EatEaze.WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        /// <summary>
        /// Get list of the categories
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("categories")]
        public async Task<IActionResult> GetCategories() 
        {
            var categories = await _categoriesService.GetCategories();
            if (categories == null) return NotFound();
            return Ok(categories);
        }
    }
}
