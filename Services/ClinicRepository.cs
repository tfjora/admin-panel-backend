using AdminPanel.Database;
using AdminPanel.Entities;
using AdminPanel.Queries;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Services;

public class ClinicRepository : IClincRepository
{
    private readonly DatabaseContext _databaseContext;

    public ClinicRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Clinic> AddClinic(Clinic clinic)
    {
        _databaseContext.Clinics.Add(clinic);
        await _databaseContext.SaveChangesAsync();
        return clinic;
    }

    public async Task<Clinic> UpdateClinic(Clinic clinic)
    {
        await _databaseContext.SaveChangesAsync();
        return clinic;
    }


    public async Task<IEnumerable<Clinic>> GetClinic()
    {
        return await _databaseContext.Clinics.Include(q => q.Persons).ToListAsync();
    }

    public async Task<Clinic?> GetClinicAsync(int clinicId)
    {
        return await _databaseContext.Clinics.Include(p => p.Persons).SingleOrDefaultAsync(c => c.Id == clinicId);
    }
    
    public void DeleteClinic(Clinic clinic)
    {
        _databaseContext.Clinics.Remove(clinic);
        _databaseContext.SaveChanges();
    }
}