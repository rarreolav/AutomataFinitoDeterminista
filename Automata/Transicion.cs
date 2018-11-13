namespace Automata
{
    public class Transicion
    {
        #region Atributos

        public string EstadoInicial { get; private set; }
        public char Simbolo { get; private set; }
        public string EstadoFinal { get; private set; }

        #endregion Atributos

        #region Constructor

        /// <summary>
        /// Constructor de la Transicion.
        /// </summary>
        /// <param name="estadoInicial">Estado inicial de la transición.</param>
        /// <param name="simbolo">Símbolo del lenguaje.</param>
        /// <param name="estadoFinal">Estado final de la transición.</param>
        public Transicion(string estadoInicial, char simbolo, string estadoFinal)
        {
            EstadoInicial = estadoInicial;
            Simbolo = simbolo;
            EstadoFinal = estadoFinal;
        }

        #endregion Constructor

        #region Métodos

        /// <summary>
        /// Método para formatear la salida de la transición.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}) ---> {2}\r\n", EstadoInicial, Simbolo, EstadoFinal);
        }

        #endregion Métodos
    }
}