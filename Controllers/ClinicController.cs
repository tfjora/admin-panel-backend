using System.Collections;
using Microsoft.AspNetCore.Mvc;
using AdminPanel.Entities;
using AdminPanel.Queries;
using AdminPanel.Services;
using AutoMapper;

namespace AdminPanel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClinicController : Controller
{
    private readonly IClincRepository _clincRepository;
    public readonly IMapper _iMapper;

    public ClinicController(IMapper iMapper, IClincRepository clinicsRepository)
    {
        _clincRepository = clinicsRepository;
        _iMapper = iMapper ?? throw new ArgumentNullException(nameof(iMapper));
    }

    [HttpPost]
    public async Task<ActionResult<Clinic>> AddClinic(ClinicCreation clinicParams)
    {
        try
        {
            var clinic = _iMapper.Map<Clinic>(clinicParams);
            var clinicAdded = await _clincRepository.AddClinic(clinic);
            return Ok(clinicAdded);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
        }
    }

    [HttpPut]
    public async Task<ActionResult<Clinic>> UpdateClinic(ClinicCreation clinicParams, int clinicId)
    {
        try
        {
            var clinicExist = await _clincRepository.GetClinicAsync(clinicId);
            if (clinicExist == null)
                return NotFound("Person do not exist.");
            
            var clinic = _iMapper.Map(clinicParams, clinicExist);
            var clinicUpdated = await _clincRepository.UpdateClinic(clinic);
            return Ok(clinicUpdated);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clinic>>> GetClinic()
    {
        var results = await _clincRepository.GetClinic();
        return Ok(results);
    }
    
    [HttpDelete]
    public async Task<ActionResult> DeleteClinic(int id)
    {
        var clinicToDelete = await _clincRepository.GetClinicAsync(id);
        if (clinicToDelete == null)
            return NotFound($"The clinic with the id {id} was not found");
        _clincRepository.DeleteClinic(clinicToDelete);
        
        return NoContent();
    }
}