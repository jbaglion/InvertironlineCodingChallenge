using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace CodingChallenge.Data.Clases
{
    public class Rectangulo: FormaGeometricaBase
    {
        private decimal _ladoBase;
        private decimal _ladoAltura;
        public Rectangulo(decimal ladoBase, decimal altura, Idiomas idioma) : base(idioma)
        {
            _ladoBase = ladoBase;
            _ladoAltura = altura;
            NombreSingular = Res.Rectangulo;
            NombrePlural = Res.Rectangulos;
        }

        public override void CalcularArea()
        {
            this.Area = _ladoBase * _ladoAltura;
        }

        public override void CalcularPerimetro()
        {
            this.Perimetro = _ladoBase * 2 + _ladoAltura * 2;
        }

    }
}
