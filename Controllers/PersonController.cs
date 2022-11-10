using AdminPanel.Entities;
using AdminPanel.Queries;
using AdminPanel.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : Controller
{
    private readonly IPersonRepository _personRepository;
    public readonly IMapper _iMapper;

    public PersonController(IMapper iMapper, IPersonRepository personRepository)
    {
        _iMapper = iMapper ?? throw new ArgumentNullException(nameof(iMapper));
        _personRepository = personRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Person>> AddPerson(PersonCreation personParams)
    {
        try
        {
            var person = _iMapper.Map<Person>(personParams);
            var personAdded = await _personRepository.AddPerson(person);
            return Ok(personAdded);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
    {
        var results = await _personRepository.GetPersons();
        return Ok(_iMapper.Map<IEnumerable<Person>>(results));
    }

    [HttpPut]
    public async Task<ActionResult<IEnumerable<Person>>> PutPerson(PersonCreation personParams, int personId)
    {
        try
        {
            var personExist = await _personRepository.GetPerson(personId);
            if (personExist == null)
                return NotFound("Person do not exist.");
            
            var person = _iMapper.Map(personParams, personExist);
            var personUpdated = await _personRepository.UpdatePerson(person);
            return Ok(personUpdated);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeletePerson(int id)
    {
        var personToDelete = await _personRepository.GetPerson(id);
        if (personToDelete == null)
            return NotFound($"The person with the id {id} was not found");
        _personRepository.DeletePerson(personToDelete);

        return NoContent();
    }
}