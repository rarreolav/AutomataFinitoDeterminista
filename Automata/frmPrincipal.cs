using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Automata
{
    public partial class frmPrincipal : Form
    {
        #region Constructor

        public frmPrincipal()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Eventos

        /// <summary>
        /// Evento click del botón examinar para seleccionar el archivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivo.Text = ofdArchivo.FileName;
                btnSimular.Enabled = true;
                btnMinimizar.Enabled = true;
                txtContenido.Text = System.IO.File.ReadAllText(txtRutaArchivo.Text);
            }
            else
            {
                txtRutaArchivo.Text = "Por favor, seleccione el archivo...";
                btnSimular.Enabled = false;
                btnMinimizar.Enabled = false;
                txtContenido.Text = string.Empty;
                txtResultado.Text = string.Empty;
                lblResultado.Visible = false;
                lblResultadoT.Visible = false;
            }
        }

        /// <summary>
        /// Evento click del botón simular, para cargar el archivo y simular.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSimular_Click(object sender, EventArgs e)
        {
            txtResultado.Text = string.Empty;
            //txtContenido.Text = System.IO.File.ReadAllText(txtRutaArchivo.Text);
            PreparaParametros(txtContenido.Text, false);
        }

        /// <summary>
        /// Evento click del botón minimizar, para cargar el archivo y minimizar el autómata y posteriormente simularlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = string.Empty;
            txtContenido.Text = System.IO.File.ReadAllText(txtRutaArchivo.Text);
            PreparaParametros(txtContenido.Text, true);
        }

        /// <summary>
        /// Evento click del botón simular para limpiar los componentes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRutaArchivo.Text = "Por favor, seleccione el archivo...";
            txtContenido.Text = string.Empty;
            txtResultado.Text = string.Empty;
            btnSimular.Enabled = false;
            lblResultado.Visible = false;
            lblResultadoT.Visible = false;
            lblResultado.Text = string.Empty;
            btnMinimizar.Enabled = false;
        }

        #endregion Eventos

        #region Métodos

        /// <summary>
        /// Método que simula el recorrido del autómata.
        /// </summary>
        /// <param name="textoArchivo">Texto a simular</param>
        /// <param name="minimiza">Bandera para saber si se va a minimizar.</param>
        /// <returns>Resultado de la simulación</returns>
        private bool PreparaParametros(string textoArchivo, bool minimiza)
        {
            try
            {
                bool resultado = false;
                textoArchivo = textoArchivo.Replace("\r\n", "\r");
                string[] cadena = textoArchivo.Split('\r');
                foreach (string linea in cadena)
                {
                    linea.Replace("\r", "");
                }

                string entrada = cadena[0].Replace(";", "");
                string alfabeto = cadena[1];
                string edoInicial = cadena[2];
                string edoFinal = cadena[3];

                var estadoInicial = "q" + edoInicial;
                var estados = new List<string>();
                int contador = 0;
                for (int i = 4; i < cadena.Length; i++)
                {
                    estados.Add("q" + contador);
                    contador++;
                }

                var lenguaje = new List<char>();
                string[] alfabetoA = alfabeto.Split(';');
                foreach (string caracter in alfabetoA)
                {
                    if (caracter != string.Empty)
                    {
                        lenguaje.Add(Convert.ToChar(caracter));
                    }
                }

                var estadoFinal = new List<string>();
                string[] edosFinales = edoFinal.Split(';');
                foreach (string caracter in edosFinales)
                {
                    if (caracter != string.Empty)
                    {
                        estadoFinal.Add('q' + caracter);
                    }
                }

                var estadosTransicion = new List<string>();
                for (int i = 4; i < cadena.Length; i++)
                {
                    estadosTransicion.Add(cadena[i]);
                }
                var matrizTransicion = GeneraMatrizTransicion(estadosTransicion, lenguaje, estados);
                var x = new List<string>();
                x.Add(estadoInicial);
                var automata = new Automata(estados, lenguaje, matrizTransicion, x, estadoFinal);
                if (minimiza)
                {                   
                    var banderita = true;
                    automata = Minimize.MinimizeDFSM(automata);
                    string delta = ObtieneMatriz(automata.Transicion);
                    string res = ComparaEstados(estados, automata.Estados);
                    if (banderita)
                    {
                        lblResultado.Text = "EJECUCIÓN\r\nCOMPLETADA";
                        txtResultado.Text = "Se encontraron estados equivalentes: " + res + "" +
                                            "\r\n\r\nLenguaje: " + alfabeto +
                                            "\r\nEstado Inicial: " + string.Join(";", automata.EstadoInicial.ToArray()) +
                                            "\r\nEstados Finales: " + string.Join(";", automata.EstadoFinal.ToArray()) +
                                            "\r\nMatriz Transición:\r\n" + delta;
                        string path = @"C:\ResultadoMinimización.txt";
                        if (!File.Exists(path))
                        {
                            File.Create(path);
                            TextWriter tw = new StreamWriter(path);
                            tw.WriteLine(txtResultado.Text);
                            tw.Close();
                        }
                        else if (File.Exists(path))
                        {
                            System.IO.File.WriteAllText(path, string.Empty);                            
                            using (var tw = new StreamWriter(path, true))
                            {
                                tw.WriteLine(txtResultado.Text);
                                tw.Close();
                            }
                        }
                    }
                    else
                    {
                        lblResultado.Text = "EJECUCIÓN\r\nCOMPLETADA";
                        txtResultado.Text = "No se encontraron estados equivalentes";
                    }
                    VisualizarComponentes();
                }
                else
                {
                    automata.Simular(entrada);
                    txtResultado.Text = Automata.resultadoTexto;
                    if (Automata.resultado)
                    {
                        lblResultado.Text = "ACEPTADA";
                    }
                    else
                    {
                        lblResultado.Text = "RECHAZADA";
                        txtResultado.Text = "La simulación no fue completada.\r\nYa que no es posible completar con éxito el recorrido de la entrada.";
                    }
                    VisualizarComponentes();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string ComparaEstados(List<string> estados, List<string> estadosMinimizacion)
        {
            try
            {
                string stats = string.Empty;                
                List<string> eq = new List<string>();                
                foreach (var e in estados)
                {
                    stats = stats + ' ' + e;
                }
                stats = stats.Substring(1);
                foreach (var m in estadosMinimizacion)
                {
                    if (stats != m)
                    {
                        eq.Add(m);
                    }                    
                }
                
                List<string> noEquivalentes = new List<string>();
                for (int i = 0; i < eq.Count ; i++)
                {
                    noEquivalentes.Add(eq[i].Substring(eq[i].Length - 2));
                }                

                var q = estados.Except(noEquivalentes);
                
                List<string> oa = new List<string>();
                oa.AddRange(q);
                string val = String.Empty;
                foreach (var e in oa)
                {
                    val = val + ' ' + e;
                }
                return val;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        private string ObtieneMatriz(List<Transicion> delta)
        {
            try
            {
                string resultado = string.Empty;

                foreach(var oa in delta)
                {
                    resultado = resultado + "\n" + oa;
                }

                return resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para visualizar los componentes del resultado.
        /// </summary>
        private void VisualizarComponentes()
        {
            txtResultado.Visible = true;
            lblResultado.Visible = true;
            lblResultadoT.Visible = true;
        }

        /// <summary>
        /// Método que genera la matriz recibiendo los valores para cada estado.
        /// </summary>
        /// <param name="matriz">Valores de transición para el estado.</param>
        /// <param name="lenguaje">Lenguaje del autómata.</param>
        /// <param name="estados">Estados del autómata.</param>
        private List<Transicion> GeneraMatrizTransicion(List<string> matriz, List<char> lenguaje, List<string> estados)
        {
            List<Transicion> matrizTransicion = new List<Transicion>();
            int numEstados = matriz.Count;
            string[] transiciones = null;
            var transicionesN = new List<string>();
            int numTransiciones = 0;
            for (int i = 0; i < numEstados; i++)
            {
                transiciones = matriz[i].Split(';');
                foreach (var x in transiciones)
                {
                    if (x != string.Empty)
                    {
                        x.Replace(";", "");
                        transicionesN.Add(x);
                    }
                }
            }
            numTransiciones = transicionesN.Count / lenguaje.Count;
            int contador = 0;
            for (int i = 0; i < numTransiciones; i++)
            {
                foreach (var x in lenguaje)
                {
                    matrizTransicion.Add(new Transicion("q" + i, x, "q" + transicionesN[contador]));
                    contador++;
                }
            }

            return matrizTransicion;
        }

        #endregion Métodos
    }
}