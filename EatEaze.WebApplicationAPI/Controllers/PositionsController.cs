﻿using EatEaze.Data.Entities;
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
        private IPositionsService _positionsService;

        public PositionsController(IPositionsService positionsService)
        {
            _positionsService = positionsService;
        }


        /// <summary>
        /// Get list of all positions
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("positions")]
        public IActionResult GetPositionsList()
        {
            var positions = _positionsService.GetPositions();
            if (positions == null) return NotFound();
            return Ok(positions);
        }


        /// <summary>
        /// Get list of positions which names contain parameter
        /// </summary>
        /// <param name="positionName"></param>
        /// <returns></returns>
        [HttpGet, Route("positions/{positionName}")]
        public IActionResult GetPositionsByName(string positionName)
        {
            var positions = _positionsService.GetPositions();
            if (positions == null) return NotFound();
            return Ok(positions);
        }

        /// <summary>
        /// Get position by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("positions/{id}")]
        public IActionResult GetPositionById(Guid id)
        {
            var position = _positionsService.GetPositionById(id);
            if (position == null) return NotFound();
            return Ok(position);
        }

        /// <summary>
        /// Get list of positions by restaurant
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [HttpGet, Route("positions/{restaurantId}")]
        public IActionResult GetPositionsByRestaurant(Guid restaurantId) 
        {
            var positions = _positionsService.GetPositionsByRestaurant(restaurantId);
            if (positions == null) return NotFound();
            return Ok(positions);
        }

        /// <summary>
        /// Get list of positions by category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet, Route("positions/{categoryId}")]
        public IActionResult GetPositionsByCategory(Guid categoryId)
        {
            var positions = _positionsService.GetPositionsByCategory(categoryId);
            if (positions == null) return NotFound();
            return Ok(positions);
        }
    }
}