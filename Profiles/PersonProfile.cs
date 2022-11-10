using AdminPanel.Entities;
using AdminPanel.Queries;
using AutoMapper;

namespace AdminPanel.Profiles;

public class PersonProfile: Profile
{
    public PersonProfile()
    {
        CreateMap<PersonCreation, Person>();
        CreateMap<ClinicCreation, Clinic>();
    }
}