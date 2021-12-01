using BjornApp.Models;
using BjornApp.ViewModels;
using Firebase.Auth;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BjornApp.Views.CrearCorreo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearCorreo : ContentPage
    {
        VMCrearCuenta funcion = new VMCrearCuenta();
        VMNegocio negocio = new VMNegocio();

        string imagePath, idUsuario = "";

        MediaFile file;
        public CrearCorreo()
        {
            InitializeComponent();
        }

        private async void btnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                await CrearCuenta();
                await IniciarSesion();
                await ObtenerIdUSuario();
                await SubirFotoStorage();
                await InsertarNegocio();
            }
        }
        private async void btnSubirFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            try
            {
                file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                });

                if (file != null)
                {
                    imgFotoPerfil.Source = ImageSource.FromStream(file.GetStream);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task CrearCuenta()
        {
            await funcion.CrearCuenta(txtCorreo.Text, txtPassword.Text);
        }
        private async Task IniciarSesion()
        {
            await funcion.ValidarCuenta(txtCorreo.Text, txtPassword.Text);
        }
        private async Task ObtenerIdUSuario()
        {
            //idUsuario = await funcion.ObtenerIdUsuario();
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.WebApiFirebase));
                var guardarId = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                var Refrescar = await authProvider.RefreshAuthAsync(guardarId);

                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(Refrescar));
                idUsuario = guardarId.User.LocalId;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Ok");
            }
        }
        private async Task SubirFotoStorage()
        {
            imagePath = await negocio.SubirImagenStorage(file.GetStream(), idUsuario);
        }
        private async Task InsertarNegocio()
        {
            Negocio modelo = new Negocio
            {
                idusuario = idUsuario,
                nombre = txtNombre.Text,
                foto = imagePath,
                celular = "",
                descripcion = "",
                direccion = "",
                idlocalidad = "",
                prioridad = ""
            };

            await negocio.InsertarNegocio(modelo);
            await DisplayAlert("Listo", "Debe reiniciar la aplicación", "Ok");
            Process.GetCurrentProcess().CloseMainWindow();
        }

    }
}