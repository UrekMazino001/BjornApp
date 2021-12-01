using BjornApp.Models;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BjornApp.ViewModels
{
    public class VMLocalidad
    {
        public async Task<List<Localidad>> MostrarLocalidades()
        {
            List<Localidad> localidades = new List<Localidad>();
            var data = (await Constantes.firebase.Child("Localidades")
                                           .OrderByKey()
                                           .OnceAsync<Localidad>()).Where(x => x.Object.departamento != "-");

            foreach (var item in data)
            {
                Localidad localidad = new Localidad();
                localidad.departamento = item.Object.departamento;
                localidad.idlocalidad = item.Key;

                localidades.Add(localidad);
            }

            return localidades;
        }
    }
}
