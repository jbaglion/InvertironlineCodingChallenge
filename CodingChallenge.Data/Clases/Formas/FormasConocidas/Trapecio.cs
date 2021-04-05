using System;

namespace CodingChallenge.Data.Clases
{
    public class Trapecio: FormaGeometricaBase
    {
        private decimal _ladoBaseMenor;
        private decimal _ladoBaseMayor;
        private decimal _altura;

        public Trapecio(decimal ladoBaseMenor, decimal ladoBaseMayor, decimal altura, Idiomas idioma) : base(idioma)
        {
            _ladoBaseMenor = ladoBaseMenor;
            _ladoBaseMayor = ladoBaseMayor;

            _altura = altura;
            NombreSingular = Res.Trapecio;
            NombrePlural = Res.Trapecios;
        }

        public override void CalcularArea()
        {
            this.Area = ((_ladoBaseMayor + _ladoBaseMenor) * _altura) / 2;
        }

        public override void CalcularPerimetro()
        {
            decimal lados = CalcularLados();

            this.Perimetro = lados * 2 + _ladoBaseMenor + _ladoBaseMayor;
        }

        private decimal CalcularLados()
        {
            decimal partBase = (_ladoBaseMayor - _ladoBaseMenor) / 2;
            return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(_altura * _altura + partBase * partBase)));
        }
    }
}
