using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.ActivarBotonesConvertir(true);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = string.Empty;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            this.lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}");
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            if (string.IsNullOrEmpty(operador))
            {
                operador = " ";
            }
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
        } 


        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);
            this.ActivarBotonesConvertir(false);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.BinarioDecimal(this.lblResultado.Text);
            this.ActivarBotonesConvertir(true);
        }

        /// <summary>
        /// Activa 
        /// </summary>
        /// <param name="status"></param>
        private void ActivarBotonesConvertir(bool status)
        {
            this.btnConvertirADecimal.Enabled = status ? false : true;
            this.btnConvertirABinario.Enabled = status ? true : false;
        }

        /// <summary>
        /// Pregunta al usuario si quiere cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Esta seguro que desea cerrar?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            } 
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            this.BackColor = this.BackColor == Color.WhiteSmoke ? Color.Black : Color.WhiteSmoke;
            this.btnOperar.BackColor = this.btnOperar.BackColor == Color.Gainsboro ? Color.DarkGray : Color.Gainsboro;
            this.btnLimpiar.BackColor = this.btnLimpiar.BackColor == Color.Gainsboro ? Color.DarkGray : Color.Gainsboro;
            this.btnCerrar.BackColor = this.btnCerrar.BackColor == Color.Gainsboro ? Color.DarkGray : Color.Gainsboro;
            this.btnDarkMode.BackColor = this.btnDarkMode.BackColor == Color.Gainsboro ? Color.DarkGray : Color.Gainsboro;
            this.btnConvertirABinario.BackColor = this.btnConvertirABinario.BackColor == Color.Gainsboro ? Color.DarkGray : Color.Gainsboro;
            this.btnConvertirADecimal.BackColor = this.btnConvertirADecimal.BackColor == Color.Gainsboro ? Color.DarkGray : Color.Gainsboro;
        }
    }
}
