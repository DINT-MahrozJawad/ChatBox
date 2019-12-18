using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBox
{
    public class Mensaje
    {
        public string Emisor { get; set; }
        public string Msg { get; set; }

        public Mensaje(string emisor, string mensaje)
        {
            Emisor = emisor;
            Msg = mensaje;
        }

    }
}
