using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BjornApp.Views;

namespace BjornApp.Views.IntroTutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Intro : ContentPage
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void btnSaltar_Clicked(object sender, EventArgs e) => Application.Current.MainPage = new NavigationPage(new Login.Login());
    }
}