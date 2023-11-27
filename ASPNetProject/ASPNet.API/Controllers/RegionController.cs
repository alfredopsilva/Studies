using System.Text.Json;
using ASPNet.API.Data;
using Microsoft.AspNetCore.Mvc;
using ASPNet.API.Models.Domain;
using ASPNet.API.Models.DTOs;
using ASPNet.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ASPNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private readonly APSNetDbContext _dbContext;
    private readonly IRegionRepository _regionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<RegionsController> _logger;

    public RegionsController(APSNetDbContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
    {
        this._dbContext = dbContext;
        _regionRepository = regionRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    //GET ALL REGIONS
    [HttpGet]
    // [Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            
            // Get Data from Database 
            var regionDomains = await _regionRepository.GetAllAsync();
            _logger.LogInformation($"Finished GetAllRegions: {JsonSerializer.Serialize(regionDomains)}");
            return Ok(_mapper.Map<List<RegionDTO>>(regionDomains));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw; 
        }
    }
    
    //GET SINGLE REGION ( GET REGION BY ID )
    [HttpGet]
    [Route("{id:guid}")]
    [Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {

        var regionDomain = await _regionRepository.GetById(id);
        if (regionDomain == null)
            return NotFound();
        
        return Ok(_mapper.Map<RegionDTO>(regionDomain));
    }
    
    //POST To Create a New Region
    [HttpPost]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        if(ModelState.IsValid)
        {
            //MAP or Convert DTO to Domain Model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            //Use Domain Model to Create Region 
            regionDomainModel = await _regionRepository.Create(regionDomainModel);

            // Map Domain Model back to DTO
            var regionDto = _mapper.Map<RegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
    
    //PUT
    [HttpPut]
    [Route("{id:Guid}")]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto )
    {

        if (ModelState.IsValid)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);
        
            regionDomainModel = await _regionRepository.Updated(id, regionDomainModel);

            if (regionDomainModel == null)
                return NotFound();

            return Ok(_mapper.Map<RegionDTO>(regionDomainModel));
        }
        else
        {
            return BadRequest(ModelState);
        }

    }

    [HttpDelete]
    [Route("{id:guid}")]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
    {
        var regionDomainModel = await _regionRepository.Delete(id);
        if (regionDomainModel == null)
            return NotFound();
       
        return Ok();
    }
}
