using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MaterialManagerApp.Models;
using MaterialManagerApp.Services;
using Microsoft.Maui.Controls;

namespace MaterialManagerApp.ViewModels;

public class MaterialesViewModel : INotifyPropertyChanged
{
    private readonly MaterialService _materialService;

    private string _codigo = string.Empty;
    private string _categoria = string.Empty;
    private double _cantidadInicial;
    private string _unidadMedida = string.Empty;
    private decimal _precio;
    private double _totalEnStock;
    private string? _mensaje;
    private bool _esError;

    public MaterialesViewModel(MaterialService materialService)
    {
        _materialService = materialService;
        Materiales = _materialService.ObtenerMateriales();
        AgregarMaterialCommand = new Command(AgregarMaterial);
        EliminarMaterialCommand = new Command<Material>(EliminarMaterial);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Material> Materiales { get; }

    public ICommand AgregarMaterialCommand { get; }

    public ICommand EliminarMaterialCommand { get; }

    public string Codigo
    {
        get => _codigo;
        set => SetProperty(ref _codigo, value);
    }

    public string Categoria
    {
        get => _categoria;
        set => SetProperty(ref _categoria, value);
    }

    public double CantidadInicial
    {
        get => _cantidadInicial;
        set => SetProperty(ref _cantidadInicial, value);
    }

    public string UnidadMedida
    {
        get => _unidadMedida;
        set => SetProperty(ref _unidadMedida, value);
    }

    public decimal Precio
    {
        get => _precio;
        set => SetProperty(ref _precio, value);
    }

    public double TotalEnStock
    {
        get => _totalEnStock;
        set => SetProperty(ref _totalEnStock, value);
    }

    public string? Mensaje
    {
        get => _mensaje;
        private set => SetProperty(ref _mensaje, value);
    }

    public bool EsError
    {
        get => _esError;
        private set => SetProperty(ref _esError, value);
    }

    private void AgregarMaterial()
    {
        try
        {
            var material = new Material
            {
                Codigo = Codigo.Trim(),
                Categoria = Categoria.Trim(),
                CantidadInicial = CantidadInicial,
                UnidadMedida = UnidadMedida.Trim(),
                Precio = Precio,
                TotalEnStock = TotalEnStock
            };

            _materialService.Agregar(material);
            LimpiarFormulario();
            EsError = false;
            Mensaje = "Material agregado correctamente";
        }
        catch (Exception ex)
        {
            EsError = true;
            Mensaje = ex.Message;
        }
    }

    private void EliminarMaterial(Material? material)
    {
        if (material is null)
        {
            return;
        }

        _materialService.Eliminar(material);
        Mensaje = $"Material {material.Codigo} eliminado";
        EsError = false;
    }

    private void LimpiarFormulario()
    {
        Codigo = string.Empty;
        Categoria = string.Empty;
        CantidadInicial = 0;
        UnidadMedida = string.Empty;
        Precio = 0;
        TotalEnStock = 0;
    }

    private void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
        {
            return;
        }

        backingStore = value;
        OnPropertyChanged(propertyName);
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
