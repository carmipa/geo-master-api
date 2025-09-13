using System.ComponentModel.DataAnnotations;

namespace GeoMasterAPI.Models;

public class Circulo : ICalculos2D
{
    [Range(0.0000001, double.MaxValue, ErrorMessage = "O raio deve ser maior que zero.")]
    public double Raio { get; set; }

    public double CalcularArea() => Math.PI * Math.Pow(Raio, 2);
    public double CalcularPerimetro() => 2 * Math.PI * Raio;
}