using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejercicio_CRUD_MVVM.Models;
using Ejercicio_CRUD_MVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_CRUD_MVVM.ViewModels
{
    public partial class AddProveedoresFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string direccion;

        [ObservableProperty]
        private string telefono;

        [ObservableProperty]
        private string email;

        private readonly ProveedoresService ProveedoresService;

        public AddProveedoresFormViewModel()
        {
            ProveedoresService = new ProveedoresService();
        }

        public AddProveedoresFormViewModel(Proveedores Proveedores)
        {
            ProveedoresService=new ProveedoresService();
            id= Proveedores.Id;
            nombre=Proveedores.Nombre;
            direccion=Proveedores.Direccion;
            telefono = Proveedores.Telefono;
            email=Proveedores.Email;
        }
       private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]

        private async Task AddUpdate()
        {
            try
            {
                Proveedores Proveedores = new Proveedores
                {
                    Id = id,
                    Nombre =nombre,
                    Direccion=direccion,
                    Telefono=telefono,
                    Email=email,
                };

                if (Validar(Proveedores))
                {
                    if (id == 0)
                    {
                        ProveedoresService.Insert(Proveedores);
                    }
                    else
                    {
                        ProveedoresService.Update(Proveedores);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }

        private bool Validar(Proveedores Proveedores)
        {
            if(Proveedores.Nombre == null || Proveedores.Nombre == "")
            {
                Alerta("Advertencia", "Ingrese el nombre del proveedor");
                return false;
            }
            else if (Proveedores.Direccion == null || Proveedores.Direccion == "")
            {
                Alerta("Advertencia", "Ingrese la dirección del proveedor");
                return false;
            }else if (Proveedores.Telefono == null || Proveedores.Telefono == "")
            {
                Alerta("Advertencia", "Ingrese el número de teléfono del proveedor");
                return false;
            }else if (Proveedores.Email == null || Proveedores.Email == "")
            {
                Alerta("Advertencia", "Ingrese el correo eléctronico del proveedor");
                return false;
            }

            return true;
        }

    }
}
