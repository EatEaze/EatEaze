using AutoMapper;
using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEaze.Responce;
using EatEazeServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Buffers;

namespace EatEaze.WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IPositionsService _positionsService;
        private ICitiesRepository _cityRepository;

        public PositionsController(IMapper mapper, IPositionsService positionsService, ICitiesRepository citiesRepository)
        {
            _mapper = mapper;
            _positionsService = positionsService;
            _cityRepository = citiesRepository;
        }


        /// <summary>
        /// Get list of all positions
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("positions")]
        public async Task<IActionResult> GetPositionsList()
        {
            var positions = await _positionsService.GetPositions();
            if (positions == null) return NotFound();

            //_mapper.Map<List<FoodCardResponce>>(positions);

            return Ok(_mapper.Map<List<FoodCardResponce>>(positions));
        }

        [HttpGet, Route("positions/city/{cityName}")]
        public async Task<IActionResult> GetPositionsFromRestarauntsInCity(string cityName)
        {
            try
            {
                var city = await _cityRepository.GetCityByName(cityName);
                var positions = await _positionsService.GetPositionsFromRestarauntsInCity(city);
                if (positions == null) return NotFound();
                return Ok(_mapper.Map<List<FoodCardResponce>>(positions));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Get list of positions which names contain parameter
        /// </summary>
        /// <param name="positionName"></param>
        /// <returns></returns>
        [HttpGet, Route("positions/name/{positionName}")]
        public async Task<IActionResult> GetPositionsByName(string positionName)
        {
            var positions = await _positionsService.GetPositions(positionName);
            if (positions == null) return NotFound();
            return Ok(_mapper.Map<List<FoodCardResponce>>(positions));
        }

        /// <summary>
        /// Get position by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("positions/{id}")]
        public async Task<IActionResult> GetPositionById(Guid id)
        {
            var position = await _positionsService.GetPositionById(id);
            if (position == null) return NotFound();
            return Ok(_mapper.Map<FoodCardResponce>(position));
        }

        /// <summary>
        /// Get list of positions by restaurant
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [HttpGet, Route("positions/restaraunts/{restaurantId}")]
        public async Task<IActionResult> GetPositionsByRestaurant(Guid restaurantId) 
        {
            var positions = await _positionsService.GetPositionsByRestaurant(restaurantId);
            if (positions == null) return NotFound();
            return Ok(_mapper.Map<List<FoodCardResponce>>(positions));
        }

        /// <summary>
        /// Get list of positions by category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet, Route("positions/categories/{categoryId}")]
        public async Task<IActionResult> GetPositionsByCategory(Guid categoryId)
        {
            var positions = await _positionsService.GetPositionsByCategory(categoryId);
            if (positions == null) return NotFound();
            return Ok(_mapper.Map<List<FoodCardResponce>>(positions));
        }

        /// <summary>
        /// Post new position to database
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost, Route("positions/addPosition")]
        public async Task<ActionResult<Position>> PostPosition(Position position)
        {
            await _positionsService.AddPosition(position);
            return CreatedAtAction(nameof(PostPosition), position);
        }
    }
}
