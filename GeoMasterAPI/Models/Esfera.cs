using System.ComponentModel.DataAnnotations;

namespace GeoMasterAPI.Models;

public class Esfera : ICalculos3D
{
    [Range(0.0000001, double.MaxValue, ErrorMessage = "Raio deve ser maior que zero.")]
    public double Raio { get; set; }

    public double CalcularVolume() => (4.0 / 3.0) * Math.PI * Math.Pow(Raio, 3);
    public double CalcularAreaSuperficial() => 4 * Math.PI * Math.Pow(Raio, 2);
}
