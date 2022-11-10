using AdminPanel.Entities;
using AdminPanel.Queries;

namespace AdminPanel.Services;

public interface IClincRepository
{
    Task<Clinic> AddClinic(Clinic clinic);
    Task<Clinic> GetClinicAsync(int clinicId);
    Task<Clinic> UpdateClinic(Clinic clinic);
    Task<IEnumerable<Clinic>> GetClinic();
    void DeleteClinic(Clinic clinic);
}