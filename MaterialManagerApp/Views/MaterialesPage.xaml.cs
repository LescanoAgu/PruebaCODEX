using MaterialManagerApp.Services;
using MaterialManagerApp.ViewModels;
using Microsoft.Maui.Controls;

namespace MaterialManagerApp.Views;

public partial class MaterialesPage : ContentPage
{
    public MaterialesPage()
    {
        InitializeComponent();
        BindingContext ??= new MaterialesViewModel(new MaterialService());
    }
}
