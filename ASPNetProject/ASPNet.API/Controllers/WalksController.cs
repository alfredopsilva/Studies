using System.Net;
using ASPNet.API.CustomActionFilters;
using ASPNet.API.Models.Domain;
using ASPNet.API.Models.DTOs;
using ASPNet.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WalksController : ControllerBase
{
    private readonly IMapper _iMapper;
    private readonly IWalkRepository _walkRepository;

    public WalksController(IMapper iMapper, IWalkRepository walkRepository)
    {
        _iMapper = iMapper;
        _walkRepository = walkRepository;
    }

    // Create Walk 
    [HttpPost]
    //This is a different approach from RegionController. We have create a ValidateModelAttribute to check this.
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] addWalkRequestDTO addWalkRequestDto)
    {
            // Map DTO to Domain
            var walk = _iMapper.Map<Walk>(addWalkRequestDto);
            await _walkRepository.CreateAsync(walk);
            // Map Domain to DTO
            return Ok(_iMapper.Map<WalkDTO>(walk));
    }

    // Get Walk
    [HttpGet]
    public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
                                                    [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
                                                        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
            var walks = await _walkRepository.GetAllAsync(filterOn, filterQuery, sortBy,isAscending ?? true, pageNumber, pageSize);
            return Ok(_iMapper.Map<List<WalkDTO>>(walks));
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
    {
        var walk = await _walkRepository.GetByIdAsync(id);
        if (walk == null)
        {
            return NotFound();
        }

        return Ok(_iMapper.Map<WalkDTO>(walk));
    }

    [HttpPut]
    [Route("{id:guid}")]
    //This is a different approach from RegionController. We have create a ValidateModelAttribute to check this.
    [ValidateModel]
    public async Task<IActionResult> UpdateWakById([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalk)
    {
        var walk = _iMapper.Map<Walk>(updateWalk);
        walk = await _walkRepository.UpdateByIdAsync(id, walk);
        if (walk == null)
            return NotFound();

        return Ok(_iMapper.Map<WalkDTO>(walk));
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeletWalkById([FromRoute] Guid id)
    {
        var walk = await _walkRepository.DeleteByIdAsync(id);
        if (walk == null)
            return NotFound();
        return Ok(_iMapper.Map<WalkDTO>(walk));
    }
}