using System;
using System.Collections.Generic;
using System.Text;

namespace BjornApp.Models
{
    public class Categoria
    {
        public string idcategoria { get; set; }
        public string prioridad { get; set; }
        public string categoria { get; set; }
        public string foto { get; set; }
        public string color { get; set; }

        //Cantidad de negocios con cada categoria
        public string contador { get; set; }
    }
}
