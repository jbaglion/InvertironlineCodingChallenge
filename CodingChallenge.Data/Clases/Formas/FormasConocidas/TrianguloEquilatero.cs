using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data.Clases
{
    public class TrianguloEquilatero: FormaGeometricaBase
    {
        private decimal _lado;
        public TrianguloEquilatero(decimal lado, Idiomas idioma) : base(idioma)
        {
            _lado = lado;
            NombreSingular = Res.TrianguloEquilatero;
            NombrePlural = Res.TrianguloEquilatero;
        }
        public override void CalcularArea()
        {
            this.Area = ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override void CalcularPerimetro()
        {
            this.Perimetro = _lado * 3;
        }

    }
}
