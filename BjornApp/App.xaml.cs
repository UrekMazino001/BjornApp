using BjornApp.Views;
using BjornApp.Views.Configuraciones;
using BjornApp.Views.Contenedores;
using BjornApp.Views.CrearCorreo;
using BjornApp.Views.IntroTutorial;
using BjornApp.Views.Login;
using BjornApp.Views.TabPage;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BjornApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Categoria(); //Presentacion();// ContenedorPrincipal(); //NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
