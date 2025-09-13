using System.ComponentModel.DataAnnotations;

namespace GeoMasterAPI.DTOs;

public class FormasDuplasRequest
{
    [Required]
    public FormaRequest Externa { get; set; } = default!;

    [Required]
    public FormaRequest Interna { get; set; } = default!;
}