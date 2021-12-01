using BjornApp.Views.Contenedores;
using BjornApp.Views.IntroTutorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BjornApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Presentacion : ContentPage
    {
        public Presentacion()
        {
            InitializeComponent();
            Animacion();
        }

        public async void Animacion()
        {
            Inicio.Opacity = 0;
            await Inicio.FadeTo(1, 3000);

            //Validando que el usuario ya este logeado
            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
            {
                Application.Current.MainPage = new NavigationPage(new ContenedorPrincipal());
            }
            else
            {
                Application.Current.MainPage = new Intro();
            }
        }
    }
}