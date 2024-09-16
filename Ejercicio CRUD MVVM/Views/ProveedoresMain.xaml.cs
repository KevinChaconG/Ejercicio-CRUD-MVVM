using Ejercicio_CRUD_MVVM.ViewModels;

namespace Ejercicio_CRUD_MVVM.Views;

public partial class ProveedoresMain : ContentPage
{

	private ProveedoresMainViewModel viewModel;
	public ProveedoresMain()
	{
		InitializeComponent();
		viewModel = new ProveedoresMainViewModel();
		this.BindingContext = viewModel;	
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }
}