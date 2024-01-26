﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RainfallApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string stationId, [FromQuery][Range(1, 100)] int count = 10)
        {
        }
    }
}