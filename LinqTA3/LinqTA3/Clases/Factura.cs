using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTA3.Clases
{
    public class Factura
    {
        public Factura()
        {

        }

        public string Observacion { get; set; }
        public int IDcliente { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }



    }
}
