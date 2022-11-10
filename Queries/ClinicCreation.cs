using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Queries;
public class ClinicCreation
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public int Phone { get; set; }
}