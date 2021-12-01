using BjornApp.ViewModels;
using BjornApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BjornApp.Views.TabPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Categoria : ContentPage
    {
        VMCategoria funcion = new VMCategoria();
        public Categoria()
        {
            InitializeComponent();
        }
        private async Task MostrarCategorias()
        {
            List<Models.Categoria> categoriasNormal = await funcion.MostrarCategoriasNormal();
            List<Models.Categoria> categoriasTop = await funcion.MostrarCategoriasTop();

            listaCategoriasNormal.ItemsSource = categoriasNormal;
            ListaCategoriasTendencia.ItemsSource = categoriasTop;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.FromResult(MostrarCategorias());
        }
    }
}