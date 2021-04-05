using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Clases
{
    public class Cuadrado : FormaGeometricaBase
    {
        private decimal _lado;
        public Cuadrado(decimal lado, Idiomas idioma) : base(idioma)
        { 
            _lado = lado;
            NombreSingular = Res.Cuadrado;
            NombrePlural = Res.Cuadrados;
        }

        public override void CalcularArea()
        {
            this.Area = _lado * _lado;
        }

        public override void CalcularPerimetro()
        {
            this.Perimetro = _lado * 4;
        }

    }
}
