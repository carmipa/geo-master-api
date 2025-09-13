using System.ComponentModel.DataAnnotations;

namespace GeoMasterAPI.Models;

public class Retangulo : ICalculos2D
{
    [Range(0.0000001, double.MaxValue, ErrorMessage = "Largura deve ser maior que zero.")]
    public double Largura { get; set; }

    [Range(0.0000001, double.MaxValue, ErrorMessage = "Altura deve ser maior que zero.")]
    public double Altura { get; set; }

    public double CalcularArea() => Largura * Altura;
    public double CalcularPerimetro() => 2 * (Largura + Altura);
}
