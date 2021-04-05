using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Clases
{
    public class Circulo : FormaGeometricaBase
    {

        private decimal _radio;

        public Circulo(decimal radio, Idiomas idioma) : base (idioma)
        {
            _radio = radio;
            NombreSingular = Res.Circulo;
            NombrePlural = Res.Circulos;
        }


        public override void CalcularArea()
        {
            this.Area = (decimal)Math.PI * _radio * _radio;
        }

        public override void CalcularPerimetro()
        {
            this.Perimetro = (decimal)Math.PI * _radio * 2;
        }

    }
}
