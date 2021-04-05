using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CodingChallenge.Data.Clases
{
    public abstract class FormaGeometricaBase
    {
        public FormaGeometricaBase(Idiomas idioma)
        {
            CultureInfo ci = new CultureInfo(idioma.Codigo);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

        }
        public FormaGeometricaBase()
        {
        }

        public virtual string NombreSingular { get; set; }
        public virtual string NombrePlural { get; set; }

        public decimal Area { get; set; }
		public decimal Perimetro { get; set; }

        public string TraducirForma(int cantidad, Idiomas idioma)
        {
            bool singular = cantidad == 1;
            string nombre = singular ? NombreSingular : NombrePlural;

            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception("No se pudo traducir el nombre de la forma.");
            }

            return nombre;
        }

        public abstract void CalcularArea();

        public abstract void CalcularPerimetro();
    }
}
