using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BjornApp.Models;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace BjornApp.ViewModels
{
    public class VMCrearCuenta
    {
        FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.WebApiFirebase));
        public async Task CrearCuenta(string correo, string password)
        {
            await authProvider.CreateUserWithEmailAndPasswordAsync(correo, password);
        }

        public async Task ValidarCuenta(string correo, string password)
        {
            //var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.WebApiFirebase));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(correo, password);
                var serialice = JsonConvert.SerializeObject(auth);
                Preferences.Set("MyFirebaseRefreshToken", serialice);
                await App.Current.MainPage.DisplayAlert("Correcto", "Listpo", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Correcto", ex.Message, "Ok");
            }
            //    var contenido = await auth.GetFreshAuthAsync();
            //    var serializacion = JsonConvert.SerializeObject(contenido);

            //    Preferences.Set("MyFirebaseRefreshToken", serializacion);
        }


        //public async Task<string> ObtenerIdUsuario()
        //{
        //    var guardarId = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
        //    var Refrescar = await authProvider.RefreshAuthAsync(guardarId);

        //    Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(Refrescar));
        //    return guardarId.User.LocalId;
        //}

    }
}
