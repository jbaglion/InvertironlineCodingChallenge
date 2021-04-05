using System;
using System.Linq;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;

namespace CodingChallenge.Data.Clases
{
    public class FormaGenerica : FormaGeometricaBase
    {
        private readonly List<Lados> _lados;
        private readonly List<Formula> _formulas;
        public List<NombreIdioma> NombresIdiomas { get; set; }

        public FormaGenerica(List<Lados> lados, List<Formula> formulas)
        {
            _lados = lados;
            _formulas = formulas;
        }

        public override string NombreSingular
        {
            get
            {
                var nombres = NombresIdiomas.Where(x => x.Idioma.Codigo.ToLower() == System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToLower()).FirstOrDefault();
                if (string.IsNullOrEmpty(nombres?.NombreSingular))
                {
                    throw new Exception("El nombre singular para esta forma no fue cargado en el idioma actual.");
                }
                return nombres.NombreSingular;
            }
        }

        public override string NombrePlural
        {
            get
            {
                var nombres = NombresIdiomas.Where(x => x.Idioma.Codigo.ToLower() == System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToLower()).FirstOrDefault();
                if (string.IsNullOrEmpty(nombres?.NombreSingular))
                {
                    throw new Exception("El nombre singular para esta forma no fue cargado en idioma actual.");
                }
                return nombres.NombrePlural;
            }
        }

        public override void CalcularArea()
        {
            string expresion = _formulas.Where(x => x.Nombre == "CalcularArea").FirstOrDefault().Expresion;
            if (string.IsNullOrEmpty(expresion))
                throw new Exception("CalcularArea no fue definida para esta forma.");

            this.Area = EjecutarExpresion(expresion);
        }

        private decimal EjecutarExpresion(string expresion)
        {
            PrimitiveElement[] elements = new PrimitiveElement[_lados.Count];
            for (int i = 0; i < elements.Length; i++)
            {
                var arg = new Argument(_lados[i].NombreLado + " = " + _lados[i].Longitud);
                if (arg.getArgumentValue() == 0 || double.IsNaN(arg.getArgumentValue()))
                    arg = new Argument(_lados[i].NombreLado + " = " + _lados[i].Longitud.ToString().Replace(",", "."));
                elements[i] = arg;
            }

            Expression e = new Expression(expresion, elements);

            return Convert.ToDecimal(e.calculate());
        }

        public override void CalcularPerimetro()
        {
            string expresion = _formulas.Where(x => x.Nombre == "CalcularPerimetro").FirstOrDefault().Expresion;
            if (string.IsNullOrEmpty(expresion))
                throw new Exception("CalcularPerimetro no fue definida para esta forma.");

            this.Perimetro = EjecutarExpresion(expresion);
        }

    }
}
