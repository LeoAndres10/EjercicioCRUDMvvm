using EjercicioCRUDMvvm.ViewModel;

namespace EjercicioCRUDMvvm.Views;

public partial class ProveedorMainView : ContentPage
{
    private ProveedorMainViewModel ViewModel;
    public ProveedorMainView()
	{
		InitializeComponent();
        ViewModel = new ProveedorMainViewModel();
        BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.GetAll();
    }

}
