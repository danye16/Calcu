using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace App1
{
    public partial class MainPage : ContentPage
    {
        private double valorActual = 0; //para los numeros
        private string operacion = ""; //Para las operaciones
        private bool operadorAuxiliar = true; //Para hacer nuevas operaciones

        public MainPage()
        {
            InitializeComponent();
        }

        private void Numeros(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressedKey = button.Text;

            if (operadorAuxiliar)
            {
                resultado.Text = pressedKey;
                operadorAuxiliar = false;
            }
            else
            {
                resultado.Text += pressedKey;
            }
        }

        private void Operador(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressedOperator = button.Text;

            if (!string.IsNullOrEmpty(operacion))
            {
                Operacion();
            }

            valorActual = double.Parse(resultado.Text);
            operacion = pressedOperator;
            operadorAuxiliar = true;
        }

        private void igual(object sender, EventArgs e)
        {
            Operacion();
            operacion = "";
        }

        private void Limpiar(object sender, EventArgs e)
        {
            resultado.Text = "0";
            valorActual = 0;
            operacion = "";
            operadorAuxiliar = true;
        }

        private void punto(object sender, EventArgs e)
        {
            if (!resultado.Text.Contains("."))
            {
                resultado.Text += ".";
                operadorAuxiliar = false;
            }
          

        }

        private void atras(object sender, EventArgs e)
        {
            if (resultado.Text.Length > 0)
            {
                resultado.Text = resultado.Text.Remove(resultado.Text.Length - 1);
            }

            if (resultado.Text.Length == 0)
            {
                resultado.Text = "0";
                operadorAuxiliar = true;
            }
        }

        private void Signos(object sender, EventArgs e)
        {
            double value = double.Parse(resultado.Text);
            value = -value;
            resultado.Text = value.ToString();
        }

        private void Operacion()
        {
            double newValue = double.Parse(resultado.Text);

            switch (operacion)
            {
                case "+":
                    valorActual += newValue;
                    break;
                case "-":
                    valorActual -= newValue;
                    break;
                case "*":
                    valorActual *= newValue;
                    break;
                case "÷":
                    if (newValue != 0)
                    {
                        valorActual /= newValue;
                    }
                    else
                    {
                        DisplayAlert("Estas Mal", "No se puede diviidir entre zero", "qwq");
                        //resultado.Text = "Error qwq";
                    }
                    break;
            }

            resultado.Text = valorActual.ToString();
            operadorAuxiliar = true;
        }
    }
}