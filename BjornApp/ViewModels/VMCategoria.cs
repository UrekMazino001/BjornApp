using BjornApp.Models;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BjornApp.ViewModels
{
    public class VMCategoria
    {

        VMNegocio negocio = new VMNegocio();
        public async Task InsertarCategoria(Categoria modelo)
        {
            _ = await Constantes.firebase.Child("Categorias").PostAsync(new Categoria
            {
                categoria = modelo.categoria,
                color = modelo.color,
                foto = modelo.foto,
                prioridad = modelo.prioridad
            });
        }

        public async Task<List<Categoria>> MostrarCategoriasNormal()
        {
            List<Categoria> categorias = new List<Categoria>();
            int cantidad = 0;

            //Obteniendio todas las categorias
            var data = (await Constantes.firebase.Child("Categorias")
                .OrderByKey().OnceAsync<Categoria>())
                .Where(x => x.Object.prioridad == "0" && x.Object.categoria.Length > 1);

            foreach (var item in data)
            {
                cantidad = await negocio.ContarNegociosXCategoria(item.Key);
                Categoria categoria = new Categoria
                {
                    categoria = item.Object.categoria,
                    prioridad = item.Object.prioridad,
                    color = item.Object.color,
                    foto = item.Object.foto,
                    contador = $"({cantidad}) Disponible"
                };
                categorias.Add(categoria);
            }
            return categorias;
        }

        public async Task<List<Categoria>> MostrarCategoriasTop()
        {
            List<Categoria> categorias = new List<Categoria>();
            int cantidad = 0;

            //Obteniendio todas las categorias
            var data = (await Constantes.firebase.Child("Categorias")
                .OrderByKey().OnceAsync<Categoria>())
                .Where(x => x.Object.prioridad == "1" && x.Object.categoria.Length > 1);

            foreach (var item in data)
            {
                cantidad = await negocio.ContarNegociosXCategoria(item.Key);
                Categoria categoria = new Categoria
                {
                    categoria = item.Object.categoria,
                    prioridad = item.Object.prioridad,
                    color = item.Object.color,
                    foto = item.Object.foto,
                    contador = $"({cantidad}) Disponible"
                };

                categorias.Add(categoria);
            }

            return categorias;
        }
    }
}