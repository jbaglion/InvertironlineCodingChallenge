using System;
using System.Collections.Generic;


namespace CodingChallenge.Data.Clases.Factory
{
    public class FormaFactory: IFormaFactory
    {
        private Idiomas _idioma;
        public FormaFactory()
        {
            // Idioma por defecto.
            _idioma = Idiomas.Ingles;
        }
        public FormaFactory(Idiomas idioma)
        {
            _idioma = idioma;
        }

        public Circulo CrearCirculo(decimal radio)
        {
            var circulo = new Circulo(radio, _idioma);
            circulo.CalcularArea();
            circulo.CalcularPerimetro();

            return circulo;
        }

        public TrianguloEquilatero CrearTrianguloEquilatero(decimal lado)
        {
            var triangulo = new TrianguloEquilatero(lado, _idioma);
            triangulo.CalcularArea();
            triangulo.CalcularPerimetro();

            return triangulo;
        }

        public Cuadrado CrearCuadrado(decimal lado)
        {
            var cuadrado = new Cuadrado(lado, _idioma);
            cuadrado.CalcularArea();
            cuadrado.CalcularPerimetro();

            return cuadrado;
        }

        public Rectangulo CrearRectangulo(decimal ladoA, decimal ladoB)
        {
            var rectangulo = new Rectangulo(ladoA, ladoB, _idioma);
            rectangulo.CalcularArea();
            rectangulo.CalcularPerimetro();

            return rectangulo;
        }

        public Trapecio CrearTrapecio(decimal ladoBaseMenor, decimal ladoBaseMayor, decimal altura)
        {

            var trapecio = new Trapecio(ladoBaseMenor, ladoBaseMayor, altura, _idioma);
            trapecio.CalcularArea();
            trapecio.CalcularPerimetro();

            return trapecio;
        }

        public FormaGenerica CrearFormaGenerica(List<Lados> lados, List<Formula> formulas, List<NombreIdioma> nombresIdiomas)
        {

            var nuevaForma = new FormaGenerica(lados, formulas);
            nuevaForma.NombresIdiomas = nombresIdiomas;
            nuevaForma.CalcularArea();
            nuevaForma.CalcularPerimetro();

            return nuevaForma;
        }
    }
}
