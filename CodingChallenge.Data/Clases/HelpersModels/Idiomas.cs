using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Clases
{

    public class Idiomas
    {
        private Idiomas(string codigo) { Codigo = codigo; }
        public string Codigo { get; set; }

        public static Idiomas Castellano { get { return new Idiomas("es-ar"); } }
        public static Idiomas Ingles { get { return new Idiomas("en-us"); } }
        public static Idiomas Portugues { get { return new Idiomas("pt"); } }
    }
}
