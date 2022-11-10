using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdminPanel.Entities;

public class Person
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Phone { get; set; }

    public ICollection<Clinic>? Clinics { get; set; } = new List<Clinic>();
}