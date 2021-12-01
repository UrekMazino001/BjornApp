using Acr.UserDialogs;
using BjornApp.ViewModels;
using BjornApp.Views.Contenedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BjornApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            //La pagina de origen debe ser navigationPage

            //Vavegar a crear cuenta
            await Navigation.PushAsync(new CrearCorreo.CrearCorreo());
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    UserDialogs.Instance.ShowLoading("Validando datos...");
                    await ValidarDatos();
                }
                else
                {
                    await DisplayAlert("Alerta", "Datos incorrectos", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Ok");
            }
        }

        private async Task ValidarDatos()
        {
            try
            {
                var funcion = new VMCrearCuenta();
                await funcion.ValidarCuenta(txtCorreo.Text, txtPassword.Text);
                Application.Current.MainPage = new NavigationPage(new ContenedorPrincipal());

            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", ex.Message, "Ok");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private void txtCorreo_TextChanged(object sender, TextChangedEventArgs e)
        {
            animationView.Progress = (float)e.NewTextValue.Length / 10;
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            animationView.Progress = (float)e.NewTextValue.Length / 10;
        }
    }
}