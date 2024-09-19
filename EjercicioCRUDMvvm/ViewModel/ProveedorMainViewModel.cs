using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Model;
using EjercicioCRUDMvvm.Services;
using EjercicioCRUDMvvm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUDMvvm.ViewModel
{
    public partial class ProveedorMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>();


        private readonly ProveedorService proveedorService;
        public ProveedorMainViewModel()
        {
            proveedorService = new ProveedorService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));

        }

        public void GetAll()
        {
            var get = proveedorService.GetAll();
            if (get.Count > 0)
            {
                ProveedorCollection.Clear();
                foreach (var proveedor in get)
                {
                    ProveedorCollection.Add(proveedor);
                }
            }
        }

        [RelayCommand]

        private async Task GoToAddProveedorForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProveedorFormView());
        }

        [RelayCommand]

        private async Task SelectProveedor(Proveedor proveedor)
        {
            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string respuesta = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "CANCELAR", null, ACTUALIZAR, ELIMINAR);

                if (respuesta == ACTUALIZAR)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ProveedorFormView(proveedor));

                }
                else if (respuesta == ELIMINAR)
                {
                    bool res = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PROVEEDOR", "¿Desea elminar el proveedor?", "Si", "No");

                    if (res)
                    {
                        int del = proveedorService.Delete(proveedor);
                        if (del > 0)
                        {
                            ProveedorCollection.Remove(proveedor);
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);

            }



        }
     }
}
