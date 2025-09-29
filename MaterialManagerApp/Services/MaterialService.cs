using System.Collections.ObjectModel;
using System.Linq;
using MaterialManagerApp.Models;

namespace MaterialManagerApp.Services;

public class MaterialService
{
    private readonly ObservableCollection<Material> _materiales = new();

    public ObservableCollection<Material> ObtenerMateriales() => _materiales;

    public void Agregar(Material material)
    {
        if (string.IsNullOrWhiteSpace(material.Codigo))
        {
            throw new ArgumentException("El código es obligatorio", nameof(material));
        }

        if (_materiales.Any(m => string.Equals(m.Codigo, material.Codigo, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Ya existe un material con el código {material.Codigo}");
        }

        _materiales.Add(material);
    }

    public void Eliminar(Material material)
    {
        if (_materiales.Contains(material))
        {
            _materiales.Remove(material);
        }
    }
}
