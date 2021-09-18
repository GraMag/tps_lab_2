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
            this.lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString("#,00");
            this.lstOperaciones.Text = $"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}";
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
        private void ActivarBotonesConvertir(bool status)
        {
            if (status)
            {
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = true;
            }
            else
            {
                this.btnConvertirADecimal.Enabled = true;
                this.btnConvertirABinario.Enabled = false;
            }
        }

        /*private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult restult = MessageBox.Show("Esta seguro que desea cerrar?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (restult == DialogResult.OK)
            {
                this.Dispose();
            }
        }*/
    }
}
