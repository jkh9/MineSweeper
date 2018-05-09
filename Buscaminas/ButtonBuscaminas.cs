using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas
{
    class BotonBuscaminas
    {
        public Label Boton { get; set; }
        public bool Bomba { get; set; }
        public int Number { get; set; }

        public BotonBuscaminas(Label boton)
        {
            Boton = boton;
        }
    }
}
