using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BjornApp.Models;
using BjornApp.ViewModels;

namespace BjornApp.Views.Configuraciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarCategoria : ContentPage
    {
        readonly VMCategoria funcion = new VMCategoria();
        Categoria modelo = new Categoria();

        public AgregarCategoria()
        {
            InitializeComponent();
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            await InsertarCategoria();
        }

        private async Task InsertarCategoria()
        {
            modelo.categoria = txtCategoria.Text;
            modelo.foto = "-";
            modelo.prioridad = txtPrioridad.Text;
            modelo.color = txtColor.Text;

            await funcion.InsertarCategoria(modelo);
            await DisplayAlert("Listo", "Catgoria agregada!", "OK");
        }
    }
}