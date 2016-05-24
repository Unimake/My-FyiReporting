using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reports.Test.RdlDesign.Forms;
using Unimake.Data.Generic;
using Unimake;

namespace Reports.Test
{
    /// <summary>
    /// Classe de extensões para os filtros dos relatórios
    /// </summary>
    public static class EnumerableFilterItem
    {
        /// <summary>
        /// Converte uma lsita de filtros em um objeto do tipo "Where"
        /// </summary>
        /// <param name="filterItens">Lista de filtros contendo os dados de filtragem</param>
        /// <returns>Objeto where</returns>
        public static Where ToWhere(this IEnumerable<FilterItem> filterItens)
        {
            Where result = new Where();

            if(!filterItens.IsNullOrEmpty())
            {
                foreach(FilterItem filter in filterItens)
                {
                    result.Add(String.Format("{0} {1}",
                                                filter.Name,
                                                GetComparison(filter)
                                              ),
                                CreateParameter(filter));
                    return result;
                }
            }
            return result;
        }

        private static IList<Parameter> CreateParameter(FilterItem filter)
        {
            IList<Parameter> result = new List<Parameter>();

            for(int i = 0; i < filter.Values.Count; i++)
            {
                result.Add(new Parameter
                {
                    ParameterName = filter.ParemeterName + "_" + i,
                    Value = GetValue(filter, i),
                    GenericDbType = filter.GenericDbType
                });
            }

            return result;
        }

        private static string GetComparison(FilterItem filter)
        {
            bool continua = true;
            string result = "";

            switch(filter.ComparisonType)
            {
                case Unimake.Data.Generic.ComparisonType.Equal:
                    result = "= {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.NotEqual:
                    result = "<> {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.GreaterThan:
                    result = "> {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.GreaterEqual:
                    result = ">= {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.LessThan:
                    result = "< {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.LessEqual:
                    result = "<= {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.StartsWith:
                    result = "LIKE {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.EndsWith:
                    result = "LIKE {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.Having:
                    result = "LIKE {0}";
                    break;
                case Unimake.Data.Generic.ComparisonType.Between:
                    result = string.Format("BETWEEN {0}_0 AND {0}_1", filter.ParemeterName);
                    continua = false;
                    break;
                default:
                    throw new NotImplementedException("A condição " + filter.ComparisonType + " ainda não foi implementada");
            }

            if(continua)
            {
                result = String.Format(result, filter.ParemeterName + "_0");

                switch(filter.GenericDbType)
                {
                    case GenericDbType.Integer:
                    case GenericDbType.Integer64:
                    case GenericDbType.Float:
                    case GenericDbType.Decimal:
                    case GenericDbType.Double:
                    case GenericDbType.Boolean:
                    case GenericDbType.DateTime:
                    case GenericDbType.TimeStamp:
                    case GenericDbType.Bit:
                    case GenericDbType.Byte:
                        result = result.Replace("LIKE", "=");
                        break;
                    case GenericDbType.Object:
                    case GenericDbType.Unknown:
                    case GenericDbType.String:
                    default:
                        break;
                }
            }
            return result;
        }

        private static object GetValue(FilterItem filter, int indice)
        {
            if(filter.Values.IsNullOrEmpty()) return "";

            object result = null;

            if(filter.Values.Count > 1)
            {
                if(filter.ComparisonType == ComparisonType.Between)
                    result = FormatValue(filter, indice);
                else if(filter.ComparisonType == ComparisonType.IN)
                    result = filter.Values.Join();
            }
            else
                result = FormatValue(filter, indice);

            return result;
        }

        /// <summary>
        /// Formata ou não o campo de acordo com a máscara
        /// </summary>
        /// <param name="filter">Filtro que contem o valor a ser formatado</param>
        /// <param name="indice">Índice do filtro, que contem o valor a ser formatado</param>
        /// <returns>Retorna o campo formatado de acordo com a máscara</returns>
        private static object FormatValue(FilterItem filter, int indice)
        {
            object result = null;

            if(!String.IsNullOrWhiteSpace(filter.Mascara))
            {
                if(Unimake.Utilities.IsNumeric(filter.Values[indice].ToString()))
                    result = String.Format(filter.Mascara, Unimake.Convert.ToUInt64(filter.Values[indice]));
                else
                    result = String.Format(filter.Mascara, filter.Values[indice]);
            }
            else
                result = filter.Values[indice];

            return result;
        }
    }
}
