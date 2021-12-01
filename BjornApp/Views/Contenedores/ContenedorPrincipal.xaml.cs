using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace BjornApp.Views.Contenedores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContenedorPrincipal : Xamarin.Forms.TabbedPage
    {
        public ContenedorPrincipal()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}