using BjornApp.Models;
using Firebase.Database.Query;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BjornApp.ViewModels
{
    public class VMNegocio
    {
        public async Task InsertarNegocio(Negocio negocio)
        {
            _ = await Constantes.firebase.Child("Negocios").PostAsync(new Negocio
            {
                celular = negocio.celular,
                descripcion = negocio.descripcion,
                direccion = negocio.direccion,
                foto = negocio.foto,
                nombre = negocio.nombre,
                idusuario = negocio.idusuario,
                idlocalidad = negocio.idlocalidad,
                prioridad = negocio.prioridad,
            });
        }

        public async Task<string> SubirImagenStorage(Stream imagen, string idUsuario)
        {
            return await new FirebaseStorage(Constantes.StorageUrl)
                                .Child("Negocios")
                                .Child(idUsuario + ".jpg")
                                .PutAsync(imagen);

        }

        public async Task<int> ContarNegociosXCategoria(string idCategoria)
        {
            var data = (await Constantes.firebase.Child("Categorias")
                .OrderByKey().OnceAsync<Categoria>())
                .Where(x => x.Key == idCategoria);

            return data.Count();
        }

        public async Task<List<Negocio>> MostrarNegociosGratis(string idCategoria, string idLocalidad)
        {
            List<Negocio> negocios = new List<Negocio>();
            

            //Obteniendio todas las categorias
            var data = (await Constantes.firebase.Child("Negocios")
                .OrderByKey().OnceAsync<Negocio>())
                .Where(x => x.Object.idcategoria == idCategoria && x.Object.prioridad == "0" && x.Object.idlocalidad == idLocalidad);

            //foreach (var item in data)
            //{
            //    //cantidad = await negocio.ContarNegociosXCategoria(item.Key);
            //    Categoria categoria = new Categoria
            //    {
            //        categoria = item.Object.categoria,
            //        prioridad = item.Object.prioridad,
            //        color = item.Object.color,
            //        foto = item.Object.foto,
            //        contador = $"({cantidad}) Disponible"
            //    };

            //    negocios.Add(categoria);
            //}

            return negocios;
        }
    }
}