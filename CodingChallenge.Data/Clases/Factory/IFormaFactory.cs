using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Clases.Factory
{
    public interface IFormaFactory
    {
        Circulo CrearCirculo(decimal radio);

        Cuadrado CrearCuadrado(decimal lado);

        TrianguloEquilatero CrearTrianguloEquilatero(decimal lado);

        Trapecio CrearTrapecio(decimal ladoBaseMenor, decimal ladoBaseMayor, decimal altura);

        Rectangulo CrearRectangulo(decimal ladoBase, decimal altura);

        FormaGenerica CrearFormaGenerica(List<Lados> lados, List<Formula> formulas, List<NombreIdioma> nombresIdiomas);

    }
}

