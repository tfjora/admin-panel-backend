using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdminPanel.Entities;

public class Clinic
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public int Phone { get; set; }

    [JsonIgnore]
    public ICollection<Person>? Persons { get; set; }
}