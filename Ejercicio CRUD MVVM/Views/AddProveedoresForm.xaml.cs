using Ejercicio_CRUD_MVVM.Models;
using Ejercicio_CRUD_MVVM.ViewModels;

namespace Ejercicio_CRUD_MVVM.Views;

public partial class AddProveedoresForm : ContentPage
{

    private AddProveedoresFormViewModel viewModel;

    public AddProveedoresForm()
	{
		InitializeComponent();
		viewModel = new AddProveedoresFormViewModel();
		BindingContext = viewModel;
	}

	public AddProveedoresForm(Proveedores proveedores)
	{
		InitializeComponent();
		viewModel = new AddProveedoresFormViewModel(proveedores);
		BindingContext = viewModel;
	}

}
