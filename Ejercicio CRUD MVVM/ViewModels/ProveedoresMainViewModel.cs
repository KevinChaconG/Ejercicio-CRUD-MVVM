using CommunityToolkit.Mvvm.ComponentModel;
using Ejercicio_CRUD_MVVM.Models;
using Ejercicio_CRUD_MVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_CRUD_MVVM.Views;
using CommunityToolkit.Mvvm.Input;

namespace Ejercicio_CRUD_MVVM.ViewModels
{
    public partial class ProveedoresMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Proveedores> proveedoresCollection = new ObservableCollection<Proveedores>();

        private readonly ProveedoresService ProveedoresService;

        public ProveedoresMainViewModel()
        {
            ProveedoresService = new ProveedoresService();  
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll = ProveedoresService.GetAll();

            if(getAll.Count > 0)
            {
                proveedoresCollection.Clear();
                foreach (var empleado in getAll)
                {
                    proveedoresCollection.Add(empleado);
                }
            }
        }

        [RelayCommand]
        private async Task goToAddProveedoresForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddProveedoresForm());
        }

        [RelayCommand]
        private async Task SelectProveedores(Proveedores proveedores)
        {
            try
            {
                string actualizar = "Actualizar";
                string eliminar = "Elimnar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, actualizar, eliminar);

                if (res == actualizar)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddProveedoresForm(proveedores));
                }
                else if (res == eliminar)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("Eliminar Proveedor", "¿Desea eliminar este proveedor?", "Si", "No");

                    if (respuesta)
                    {
                        int del = ProveedoresService.Delete(proveedores);

                        if(del > 0)
                        {
                            proveedoresCollection.Remove(proveedores);
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }
    }
}
