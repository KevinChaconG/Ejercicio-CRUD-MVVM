﻿using Ejercicio_CRUD_MVVM.Views;

namespace Ejercicio_CRUD_MVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProveedoresMain());
        }
    }
}
