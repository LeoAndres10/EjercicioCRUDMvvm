using EjercicioCRUDMvvm.Model;
using EjercicioCRUDMvvm.ViewModel;

namespace EjercicioCRUDMvvm.Views;

public partial class ProveedorFormView : ContentPage
{
	private ProveedorMainViewModel viewModel;
	public ProveedorFormView()
	{
		InitializeComponent();
		viewModel = new ProveedorMainViewModel();
		BindingContext = viewModel;

	}

	public ProveedorFormView(Proveedor proveedor)
	{
		InitializeComponent();

		viewModel=new ProveedorMainViewModel();
		BindingContext = viewModel;
	}
}