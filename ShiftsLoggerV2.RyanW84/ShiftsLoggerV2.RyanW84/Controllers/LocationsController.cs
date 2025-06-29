﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerV2.RyanW84.Dtos;
using ShiftsLoggerV2.RyanW84.Models;
using ShiftsLoggerV2.RyanW84.Models.FilterOptions;
using ShiftsLoggerV2.RyanW84.Services;

namespace ShiftsLoggerV2.RyanW84.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService locationService;

    public LocationsController(ILocationService locationService)
    {
        this.locationService = locationService;
    }

    // GET: api/Location
    [HttpGet(Name = "Get All Locations")]
    public async Task<ActionResult<ApiResponseDto<List<Location>>>> GetAllLocations(
        LocationFilterOptions? locationOptions
    )
    {
        try
        {
            locationOptions ??= new LocationFilterOptions(); // Provide a default value
            return Ok(await locationService.GetAllLocations(locationOptions));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Get All Locations failed, see Exception {ex}");
            throw;
        }
    }

    // GET: api/Location/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponseDto<Location?>>> GetLocationById(int id)
    {
        try
        {
            var result = await locationService.GetLocationById(id);
            if (result == null || result.Data == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Get by ID failed, see Exception {ex}");
            throw;
        }
    }

    // POST: api/Location
    [HttpPost]
    public async Task<ActionResult<ApiResponseDto<Location>>> CreateLocation(
        LocationApiRequestDto location
    )
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return new ObjectResult(await locationService.CreateLocation(location))
                {
                    StatusCode = 201,
                };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Create location failed, see Exception {ex}");
            throw;
        }
    }

    // PUT: api/Location/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponseDto<Location?>>> UpdateLocation(
        int id,
        LocationApiRequestDto updatedLocation
    )
    {
        try
        {
            var result = await locationService.UpdateLocation(id, updatedLocation);
            if (result == null || result.Data == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Update location failed, see Exception {ex}");
            throw;
        }
    }

    // DELETE: api/Location/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteLocation(int id)
    {
        try
        {
            var result = await locationService.DeleteLocation(id);
            if (result.ResponseCode == HttpStatusCode.NotFound || result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Delete location failed, see Exception {ex}");
            throw;
        }
    }
}
