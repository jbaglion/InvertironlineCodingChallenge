using System.Collections.Generic;
using CodingChallenge.Data.Clases;
using CodingChallenge.Data.Clases.Factory;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVaciaEnCastellano()
        {
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica(Idiomas.Castellano);

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase>()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormas()
        {
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica();
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase>()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadradoEnCastellano()
        {
            var _idioma = Idiomas.Castellano;
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica(_idioma);
            IFormaFactory formaFactory = new FormaFactory(_idioma);

            var resumen = ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase> { formaFactory.CrearCuadrado(5) });

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var formas = new List<FormaGeometricaBase>();

            IFormaFactory factory = new FormaFactory();
            formas.Add(factory.CrearCuadrado(5));
            formas.Add(factory.CrearCuadrado(1));
            formas.Add(factory.CrearCuadrado(3));

            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica();

            var resumen = ejecucionFormaGeometrica.Imprimir(formas);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometricaBase>();

            IFormaFactory factory = new FormaFactory();
            formas.Add(factory.CrearCuadrado(5));
            formas.Add(factory.CrearCirculo(3));
            formas.Add(factory.CrearTrianguloEquilatero(4));
            formas.Add(factory.CrearCuadrado(2));
            formas.Add(factory.CrearTrianguloEquilatero(9));
            formas.Add(factory.CrearCirculo(2.75m));
            formas.Add(factory.CrearTrianguloEquilatero(4.2m));

            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica();

            var resumen = ejecucionFormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52.03 | Perimeter 36.13 <br/>3 Equilateral triangle | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 115.73 Area 130.67",
                resumen);

            // El círculos se calcula de otra manera.
            //"<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var _idioma = Idiomas.Castellano;

            var formas = new List<FormaGeometricaBase>();

            IFormaFactory factory = new FormaFactory(_idioma);
            formas.Add(factory.CrearCuadrado(5));
            formas.Add(factory.CrearCirculo(3));
            formas.Add(factory.CrearTrianguloEquilatero(4));
            formas.Add(factory.CrearCuadrado(2));
            formas.Add(factory.CrearTrianguloEquilatero(9));
            formas.Add(factory.CrearCirculo(2.75m));
            formas.Add(factory.CrearTrianguloEquilatero(4.2m));


            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica(_idioma);

            var resumen = ejecucionFormaGeometrica.Imprimir(formas);
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 52,03 | Perimetro 36,13 <br/>3 Triángulo Equilátero | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 115,73 Area 130,67",
                resumen);

            // El círculos se calcula de otra manera.
            //"<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
        }

        #region nuevos

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica();
            IFormaFactory formaFactory = new FormaFactory();

            var resumen = ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase> { formaFactory.CrearRectangulo(5, 7) });

            Assert.AreEqual("<h1>Shapes report</h1>1 Rectangle | Area 35 | Perimeter 24 <br/>TOTAL:<br/>1 shapes Perimeter 24 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectanguloEnCastellano()
        {
            var _idioma = Idiomas.Castellano;
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica(_idioma);
            IFormaFactory formaFactory = new FormaFactory(_idioma);

            var resumen = ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase> { formaFactory.CrearRectangulo(5, 7) });

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectángulo | Area 35 | Perimetro 24 <br/>TOTAL:<br/>1 formas Perimetro 24 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectanguloEnPortugues()
        {
            var _idioma = Idiomas.Portugues;
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica(_idioma);
            IFormaFactory formaFactory = new FormaFactory(_idioma);

            var resumen = ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase> { formaFactory.CrearRectangulo(5, 7) });

            Assert.AreEqual("<h1>Relatório de Formas</h1>1 Retângulo | Área 35 | Perímetro 24 <br/>TOTAL:<br/>1 formas Perímetro 24 Área 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica();
            IFormaFactory formaFactory = new FormaFactory();

            var resumen = ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase> { formaFactory.CrearTrapecio(3, 9, 4) });

            Assert.AreEqual("<h1>Shapes report</h1>1 Trapeze | Area 24 | Perimeter 22 <br/>TOTAL:<br/>1 shapes Perimeter 22 Area 24", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioEnCastellano()
        {
            var _idioma = Idiomas.Castellano;
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica(_idioma);
            IFormaFactory formaFactory = new FormaFactory(_idioma);

            var resumen = ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase> { formaFactory.CrearTrapecio(3, 9, 4) });

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 24 | Perimetro 22 <br/>TOTAL:<br/>1 formas Perimetro 22 Area 24", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioEnPortugues()
        {
            var _idioma = Idiomas.Portugues;
            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica(_idioma);
            IFormaFactory formaFactory = new FormaFactory(_idioma);

            var resumen = ejecucionFormaGeometrica.Imprimir(new List<FormaGeometricaBase> { formaFactory.CrearTrapecio(3, 9, 4) });

            Assert.AreEqual("<h1>Relatório de Formas</h1>1 Trapézio | Área 24 | Perímetro 22 <br/>TOTAL:<br/>1 formas Perímetro 22 Área 24", resumen);
        }

        [TestCase]
        public void TestResumenAgregarNuevaForma()
        {
            var formas = new List<FormaGeometricaBase>();

            IFormaFactory factory = new FormaFactory();

            #region crear nueva forma
            
            // Esta información puede ser cargada en una interfaz de usuario, permitiéndole al usuario crear nuevas formas.
            var nombresIdiomas = new List<NombreIdioma> {
                new NombreIdioma { Idioma = Idiomas.Ingles, NombrePlural = "Pentagons", NombreSingular = "Pentagon" },
                new NombreIdioma { Idioma = Idiomas.Castellano, NombrePlural = "Pentágonos", NombreSingular = "Pentágono" },
                new NombreIdioma { Idioma = Idiomas.Portugues, NombrePlural = "Pentágonos", NombreSingular = "Pentágono" },
            };
            List<Lados> lados = new List<Lados> { new Lados { NombreLado = "lado", Longitud = 5 }, new Lados { NombreLado = "apotema", Longitud = 3.44m } };
            List<Formula> formulas = new List<Formula>
            {
                new Formula { Nombre = "CalcularArea", Expresion = "(lado * 5 * apotema )/ 2" },
                new Formula { Nombre = "CalcularPerimetro", Expresion = "lado * 5" }
            };

            var nuevaForma = factory.CrearFormaGenerica(lados, formulas, nombresIdiomas);

            formas.Add(nuevaForma);
            #endregion

            EjecucionFormaGeometrica ejecucionFormaGeometrica = new EjecucionFormaGeometrica();

            var resumen = ejecucionFormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
            "<h1>Shapes report</h1>1 Pentagon | Area 43 | Perimeter 25 <br/>TOTAL:<br/>1 shapes Perimeter 25 Area 43",
            resumen);
        }

        #endregion
    }
}
