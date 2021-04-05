/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data.Clases
{
    public class EjecucionFormaGeometrica
    {

        private readonly Idiomas _idioma;

        public EjecucionFormaGeometrica()
        {
            // Idioma por defecto.
            _idioma = Idiomas.Ingles;
        }
        public EjecucionFormaGeometrica(Idiomas idioma)
        {
            _idioma = idioma;
        }

        public string Imprimir(List<FormaGeometricaBase> formas)
        {
            EstablecerCultura();

            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append("<h1>" + Res.ListaVacia + "</h1>");
            }
            else
            {
                sb.Append("<h1>" + Res.ReporteFormas + "</h1>");

                var formasByType = formas.GroupBy(x => x.NombreSingular);
                decimal totalAreas = 0;
                decimal totalPerimetros = 0;
                foreach (var formaGrupo in formasByType)
                {
                    //foreach (var forma in formaGrupo)
                    //{
                        var totalAreasGrupo = formaGrupo.Sum(x => x.Area);
                        var totalPerimetrosGrupo = formaGrupo.Sum(x => x.Perimetro);
                        totalAreas += totalAreasGrupo;
                        totalPerimetros += totalPerimetrosGrupo;
                        sb.Append(ObtenerLinea(formaGrupo.Count(), totalAreasGrupo, totalPerimetrosGrupo, formaGrupo.FirstOrDefault()));
                    //}
                }

                // FOOTER
                sb.Append(Res.Total + ":<br/>");
                sb.Append(formas.Count + " " + Res.Formas + " ");
                sb.Append(Res.Perimetro + " " + totalPerimetros.ToString("#.##") + " ");
                sb.Append(Res.Area + " " + totalAreas.ToString("#.##"));
            }

            return sb.ToString();
        }



        private string ObtenerLinea(int cantidad, decimal area, decimal perimetro, FormaGeometricaBase forma)
        {
            EstablecerCultura();

            if (cantidad > 0)
            {
                return $"{cantidad} {forma.TraducirForma(cantidad, _idioma)} | { Res.Area } {area:#.##} | { Res.Perimetro } {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private void EstablecerCultura()
        {
            CultureInfo ci = new CultureInfo(_idioma.Codigo);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}
