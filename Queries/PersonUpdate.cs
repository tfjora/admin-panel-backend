using System.ComponentModel.DataAnnotations;
using AdminPanel.Entities;

namespace AdminPanel.Queries;

public class PersonUpdate
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Phone { get; set; }
    public ICollection<Clinic> Clinics { get; set; }
}