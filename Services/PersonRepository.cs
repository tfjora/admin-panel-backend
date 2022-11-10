using AdminPanel.Database;
using AdminPanel.Entities;
using AdminPanel.Queries;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Services;

public class PersonRepository : IPersonRepository
{
    private readonly DatabaseContext _databaseContext;

    public PersonRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Person> AddPerson(Person person)
    {
        _databaseContext.Persons.Add(person);
        await _databaseContext.SaveChangesAsync();
        return person;
    }

   public async Task<Person> UpdatePerson(Person personUpdate)
   {
        await _databaseContext.SaveChangesAsync();
        return personUpdate;
    }

    public async Task<IEnumerable<Person>> GetPersons()
    {
        return await _databaseContext.Persons.Include(q => q.Clinics).ToListAsync();
    }

    public async Task<Person?> GetPerson(int personId)
    {
        return await _databaseContext.Persons.Include(p => p.Clinics).SingleOrDefaultAsync(c => c.Id == personId);
    }

    public void DeletePerson(Person person)
    {
        _databaseContext.Persons.Remove(person);
        _databaseContext.SaveChanges();
    }
}