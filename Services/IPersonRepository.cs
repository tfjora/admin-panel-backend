using AdminPanel.Entities;
using AdminPanel.Queries;

namespace AdminPanel.Services;

public interface IPersonRepository
{
    Task<Person> AddPerson(Person person);
    Task<Person> UpdatePerson(Person person);
    Task<IEnumerable<Person>> GetPersons();
    Task<Person> GetPerson(int personId);
    void DeletePerson(Person person);
}