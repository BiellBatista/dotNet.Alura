using _06_03_XX_Simplificando_Expressoes_Condicionais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_03_XX_Simplificando_Expressoes_Condicionais
{
    public partial class FormCalculadoraDepois : Form, ICalculadoraObserver
    {
        CalculadoraIMC calculadora;

        public FormCalculadoraDepois()
        {
            InitializeComponent();

            calculadora = new CalculadoraIMC();
            calculadora.Adicionar(this);
        }

        public void ResultadoIMC(double imc)
        {
            txtIMC.Text = $"IMC calculado: {imc:0.00}";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double.TryParse(txtAltura.Text, out double altura);
            double.TryParse(txtPeso.Text, out double peso);

            try
            {
                calculadora.Calcular(altura, peso);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
