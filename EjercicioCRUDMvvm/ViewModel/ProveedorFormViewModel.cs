using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Model;
using EjercicioCRUDMvvm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUDMvvm.ViewModel
{
    public partial class ProveedorFormViewModel : ObservableObject
    {
        [ObservableProperty]

        public int id;
        [ObservableProperty]
        public string nombre;

        [ObservableProperty]
        public string producto;

        [ObservableProperty]
        public string marca;

        [ObservableProperty]
        public string descripcion;

        [ObservableProperty]
        public double precio;

        private readonly ProveedorService proveedorService;

        public ProveedorFormViewModel()
        {
            proveedorService = new ProveedorService();
        }

        public ProveedorFormViewModel(Proveedor proveedor)
        {
            proveedorService = new ProveedorService();

            Id = proveedor.Id;
            Nombre = proveedor.Nombre;
            Producto = proveedor.Producto;
            Marca = proveedor.Marca;
            Descripcion = proveedor.Descripcion;
            Precio = proveedor.Precio;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));

        }

        private bool Validar(Proveedor proveedor)
        {
            if (proveedor.Nombre is null || proveedor.Nombre == "")
            {
                Alerta("ADVERTENCIA", "Por favor ingrese el nombre del proveedor");
                return false;
            }
            else if (proveedor.Producto is null || proveedor.Producto == "")
            {
                Alerta("ADVERTENCIA", "Por favor ingrese el producto");
                return false;
            }
            else if (proveedor.Marca is null || proveedor.Marca == "")
            {
                Alerta("ADVERTENCIA", "Por favor ingrese la marca del producto");
                return false;
            }
            else if (proveedor.Descripcion is null || proveedor.Descripcion == "")
            {
                Alerta("ADVERTENCIA", "Por favor ingrese la descripcion del producto");
                return false;
            }
            else if (proveedor.Precio == 0)
            {
                Alerta("ADVERTENCIA", "Por favor ingrese el precio del producto");
                return false;
            }
            else
            {
                return true;
            }
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Proveedor proveedor= new Proveedor();

                proveedor.Nombre= Nombre;
                proveedor.Producto= Producto;
                proveedor.Marca= Marca;
                proveedor.Descripcion=Descripcion;
                proveedor.Precio=Precio;

                if (Validar(proveedor))
                {
                    if (Id == 0)
                    {
                        proveedorService.Insert(proveedor);
                    }
                    else
                    {
                        proveedorService.Update(proveedor);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }

            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
