using System;
using System.Drawing;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Realiza la operación guarda las operaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;

            this.lblResultado.Text = Operar(numero1, numero2, operador).ToString("0.###");
            if(!(string.IsNullOrEmpty(numero1) && string.IsNullOrEmpty(numero2)))
            {
                if(string.IsNullOrEmpty(operador) && !(string.IsNullOrEmpty(numero1) || string.IsNullOrEmpty(numero2)))
                {
                    operador = "+";
                }
                this.lstOperaciones.Items.Add($"{numero1} {operador} {numero2} = {this.lblResultado.Text}");
            }
            this.ActivarBotonesConvertir(true);
        }
        
        /// <summary>
        /// Llama al metodo limpiar al clickear el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.ActivarBotonesConvertir(true);
        }

        /// <summary>
        /// Convierte el resultado de decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);
            this.ActivarBotonesConvertir(false);
        }

        /// <summary>
        /// Convierte el resultado de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.BinarioDecimal(this.lblResultado.Text);
            this.ActivarBotonesConvertir(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero1">Primer numero ingresado</param>
        /// <param name="numero2">Segundo numero ingresado</param>
        /// <param name="operador">Operador seleccionado</param>
        /// <returns>Resultado de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
           if (string.IsNullOrEmpty(operador))
           {
                operador = " ";
           }
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
        }

        /// <summary>
        /// Limpia los elementos del formulario
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// Pregunta al usuario si quiere cerrar el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea cerrar?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        
        /// <summary>
        /// Activa y desactiva los botones de conversion
        /// </summary>
        /// <param name="status"></param>
        private void ActivarBotonesConvertir(bool status)
        {
            this.btnConvertirADecimal.Enabled = status ? false : true;
            this.btnConvertirABinario.Enabled = status ? true : false;
        }

        /// <summary>
        /// Activa y desactiva el modo oscuro modificando el color del fondo y los botones 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModoClaro_Click(object sender, EventArgs e)
        {
            // Colores //
            Color botonesModoClaro = Color.Gainsboro;
            Color fondoModoClaro = Color.WhiteSmoke;
            Color botonesModoOscuro = Color.DarkGray;
            Color fondoModoOscuro = Color.FromArgb(38,38,38);

            this.BackColor = this.BackColor == fondoModoClaro ? fondoModoOscuro : fondoModoClaro;
            this.btnOperar.BackColor = this.btnOperar.BackColor == botonesModoClaro ? botonesModoOscuro : botonesModoClaro;
            this.btnLimpiar.BackColor = this.btnLimpiar.BackColor == botonesModoClaro ? botonesModoOscuro : botonesModoClaro;
            this.btnCerrar.BackColor = this.btnCerrar.BackColor == botonesModoClaro ? botonesModoOscuro : botonesModoClaro;
            this.btnConvertirABinario.BackColor = this.btnConvertirABinario.BackColor == botonesModoClaro ? botonesModoOscuro : botonesModoClaro;
            this.btnConvertirADecimal.BackColor = this.btnConvertirADecimal.BackColor == botonesModoClaro ? botonesModoOscuro : botonesModoClaro;

            // Boton on/off //
            if (this.pboxModoClaro.Visible == true)
            {
                this.pboxModoClaro.Visible = false;
                this.pboxModoOscuro.Visible = true;
            }
            else if (this.pboxModoOscuro.Visible == true)
            {
                this.pboxModoClaro.Visible = true;
                this.pboxModoOscuro.Visible = false;
            }
        }
    }
}
