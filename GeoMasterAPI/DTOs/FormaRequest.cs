using System.ComponentModel.DataAnnotations;

namespace GeoMasterAPI.DTOs;

public class FormaRequest
{
    [Required]
    public string TipoForma { get; set; } = string.Empty;

    [Required]
    public Dictionary<string, double>? Propriedades { get; set; }
}