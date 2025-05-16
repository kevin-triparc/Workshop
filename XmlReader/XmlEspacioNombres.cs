namespace XmlReader
{
    /// <summary>
    /// Clase que representa un espacio de nombres XML con su prefijo y URI.
    /// </summary>
    public class XmlEspacioNombres
    {
        /// <summary>
        /// Constructor que crea un nuevo espacio de nombres XML.
        /// </summary>
        /// <param name="prefijo">Prefijo del espacio de nombres</param>
        /// <param name="uri">URI del espacio de nombres</param>
        public XmlEspacioNombres(string prefijo, string uri)
        {
            Prefijo = prefijo;
            Uri = uri;
        }

        /// <summary>
        /// Obtiene o establece el prefijo del espacio de nombres.
        /// </summary>
        public string Prefijo { get; set; }

        /// <summary>
        /// Obtiene o establece la URI del espacio de nombres.
        /// </summary>
        public string Uri { get; set; }
    }
}