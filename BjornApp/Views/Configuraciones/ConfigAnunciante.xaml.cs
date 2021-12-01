using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BjornApp.Views.Configuraciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigAnunciante : ContentPage
    {
        public ConfigAnunciante()
        {
            InitializeComponent();
        }

        private void btnCerrar_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            Application.Current.MainPage = new NavigationPage(new Login.Login());
        }
    }
}