using System.ComponentModel.DataAnnotations;
using AdminPanel.Entities;

namespace AdminPanel.Queries;

public class PersonCreation
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Phone { get; set; }
    public ICollection<Clinic>? Clinics { get; set; }
}