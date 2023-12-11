using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EatEaze.WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICitiesRepository _cityRepository;

        public CityController(ICitiesRepository citiesRepository)
        {
            _cityRepository = citiesRepository;
        }

        [HttpGet, Route("cities")]
        public async Task<IActionResult> GetCities()
        {
            var result = await _cityRepository.GetListOfItem();
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
