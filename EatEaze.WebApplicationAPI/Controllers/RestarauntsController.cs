using EatEazeServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EatEaze.WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestarauntsController : ControllerBase
    {
        private IRestarauntsService _restarauntsService;

        public RestarauntsController(IRestarauntsService restarauntsService)
        {
            _restarauntsService = restarauntsService;
        }

        /// <summary>
        /// Get list of restaraunts
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("restaraunts")]
        public async Task<IActionResult> GetRestaraunts() 
        {
            var result = await _restarauntsService.GetRestaraunts();
            if (result == null) return NotFound();
            return Ok(result);  
        }

        [HttpGet, Route("restaraunts/category/{categoryId}")]
        public async Task<IActionResult> GetRestarauntsByCategory(Guid categoryId)
        {
            var result = await _restarauntsService.GetRestarauntsByCategory(categoryId);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
