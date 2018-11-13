using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automata
{
    public class Automata
    {
        #region Variables

        private readonly List<string> Estados = new List<string>();
        private readonly List<char> Lenguaje = new List<char>();
        private readonly List<Transicion> Transicion = new List<Transicion>();
        private string EstadoInicial;
        private readonly List<string> EstadoFinal = new List<string>();
        public static bool resultado;
        public static string resultadoTexto;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Constructor del Autómata.
        /// </summary>
        /// <param name="estados">Listado de los estados.</param>
        /// <param name="lenguaje">Listado de los caracteres del lenguaje.</param>
        /// <param name="transiciones">Matriz de transiciones.</param>
        /// <param name="estadoInicial">Estado inicial del autómata.</param>
        /// <param name="estadoFinal">Listado de los estados finales del autómata.</param>
        public Automata(IEnumerable<string> estados, IEnumerable<char> lenguaje,
           IEnumerable<Transicion> transiciones, string estadoInicial, IEnumerable<string> estadoFinal)
        {
            Estados = estados.ToList();
            Lenguaje = lenguaje.ToList();
            CrearTransicion(transiciones);
            CrearEstadoInicial(estadoInicial);
            CrearEstadosFinales(estadoFinal);
        }

        #endregion Constructor

        #region Métodos

        /// <summary>
        /// Método para crear una transición.
        /// </summary>
        /// <param name="transiciones">Matriz de transiciones.</param>
        private void CrearTransicion(IEnumerable<Transicion> transiciones)
        {
            foreach (var transicion in transiciones.Where(ValidaTransicion))
            {
                Transicion.Add(transicion);
            }
        }

        /// <summary>
        /// Método que valida una transición dado su estado inicial, estado final y el símbolo.
        /// </summary>
        /// <param name="transicion">Objeto del tipo Transición.</param>
        /// <returns></returns>
        private bool ValidaTransicion(Transicion transicion)
        {
            return Estados.Contains(transicion.EstadoInicial) &&
                   Estados.Contains(transicion.EstadoFinal) &&
                   Lenguaje.Contains(transicion.Simbolo);
        }

        /// <summary>
        /// Método que crea un estado inicial.
        /// </summary>
        /// <param name="q0">Estado inicial.</param>
        private void CrearEstadoInicial(string q0)
        {
            if (q0 != null)
            {
                EstadoInicial = q0;
            }
        }

        /// <summary>
        /// Método que crea los estados finales.
        /// </summary>
        /// <param name="estadosFinales">Listado con los estados finales.</param>
        private void CrearEstadosFinales(IEnumerable<string> estadosFinales)
        {
            foreach (var finalState in estadosFinales.Where(finalState => Estados.Contains(finalState)))
            {
                EstadoFinal.Add(finalState);
            }
        }

        /// <summary>
        /// Método que simula el autómata.
        /// </summary>
        /// <param name="entrada">Cadena de entrada a evaluar.</param>
        public void Simular(string entrada)
        {
            if (Simular(EstadoInicial, entrada, new StringBuilder()))
            {
                return;
            }
        }

        /// <summary>
        /// Método que simula el autómata.
        /// </summary>
        /// <param name="estadoActual">Estado actual del autómata.</param>
        /// <param name="entrada">Cadena de entrada a evaluar.</param>
        /// <param name="pasos">Cadena con los pasos de la transición.</param>
        /// <returns></returns>
        private bool Simular(string estadoActual, string entrada, StringBuilder pasos)
        {
            if (entrada.Length > 0)
            {
                var transiciones = ObtenerTransiciones(estadoActual, entrada[0]);
                foreach (var transicion in transiciones)
                {
                    var pasoActual = new StringBuilder(pasos.ToString() + transicion);
                    if (Simular(transicion.EstadoFinal, entrada.Substring(1), pasoActual))
                    {
                        return true;
                    }
                }
                return false;
            }
            if (EstadoFinal.Contains(estadoActual))
            {
                resultadoTexto = "Cadena simulada correctamente \r\n" +
                            "en el estado final: " + estadoActual + "\r\n" +
                            " con las transiciones:\r\n" + pasos;
                resultado = true;
                return true;
            }
            resultado = false;
            return false;
        }

        /// <summary>
        /// Método que obtiene la transición desde la transición actual.
        /// </summary>
        /// <param name="pasoActual">Transición actual.</param>
        /// <param name="caracter">Símbolo del lenguaje.</param>
        /// <returns></returns>
        private IEnumerable<Transicion> ObtenerTransiciones(string pasoActual, char caracter)
        {
            return Transicion.FindAll(t => t.EstadoInicial == pasoActual &&
                                      t.Simbolo == caracter);
        }

        #endregion Métodos
    }
}