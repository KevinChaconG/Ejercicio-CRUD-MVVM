using Ejercicio_CRUD_MVVM.ViewModels;

namespace Ejercicio_CRUD_MVVM.Views;

public partial class ProveedoresMain : ContentPage
{

	private ProveedoresMainViewModel ViewModel;
	public ProveedoresMain()
	{
		InitializeComponent();
		ViewModel = new ProveedoresMainViewModel();
		this.BindingContext = ViewModel;	
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		ViewModel.GetAll();
    }
}