namespace MaterialManagerApp.Models;

public class Material
{
    public string Codigo { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public double CantidadInicial { get; set; }
    public string UnidadMedida { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public double TotalEnStock { get; set; }
}
