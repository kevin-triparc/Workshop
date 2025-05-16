using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

namespace XmlReader
{
    /// <summary>
    /// Clase utilitaria para convertir valores entre diferentes tipos.
    /// </summary>
    internal static class Convertidor
    {
        /// <summary>
        /// Obtiene el valor de un resultado de evaluación XPath.
        /// </summary>
        /// <param name="result">Resultado de la evaluación XPath</param>
        /// <returns>Valor extraído del resultado</returns>
        public static object ObtenerValor(object result)
        {
            if (result is string)
                return result;

            if (result is bool)
                return result;

            if (result is double)
                return result;

            if (result is XPathNodeIterator iterator)
            {
                if (iterator.Count == 0)
                    return null;

                iterator.MoveNext();
                return iterator.Current?.Value;
            }

            return result?.ToString();
        }

        /// <summary>
        /// Cambia el tipo de un objeto al tipo especificado.
        /// </summary>
        /// <param name="value">Objeto a convertir</param>
        /// <param name="type">Tipo de destino</param>
        /// <returns>Objeto convertido al tipo especificado</returns>
        public static object CambiarTipo(object value, Type type)
        {
            if (value == null)
                return null;

            if (type == typeof(string))
                return value.ToString();

            if (type == typeof(bool) && bool.TryParse(value.ToString(), out bool boolResult))
                return boolResult;

            if (type == typeof(int) && int.TryParse(value.ToString(), out int intResult))
                return intResult;

            if (type == typeof(double) && double.TryParse(value.ToString(), out double doubleResult))
                return doubleResult;

            if (type == typeof(decimal) && decimal.TryParse(value.ToString(), out decimal decimalResult))
                return decimalResult;

            if (type == typeof(DateTime) && DateTime.TryParse(value.ToString(), out DateTime dateTimeResult))
                return dateTimeResult;

            if (type == typeof(Guid) && Guid.TryParse(value.ToString(), out Guid guidResult))
                return guidResult;

            return value;
        }

        /// <summary>
        /// Obtiene múltiples valores de un resultado de evaluación XPath.
        /// </summary>
        /// <param name="result">Resultado de la evaluación XPath</param>
        /// <returns>Lista de valores extraídos del resultado</returns>
        public static IEnumerable<object> ObtenerDeValoresMultiples(object result)
        {
            if (result is XPathNodeIterator iterator)
            {
                var list = new List<object>();
                while (iterator.MoveNext())
                {
                    list.Add(iterator.Current?.Value);
                }
                return list;
            }

            return null;
        }
    }
}