using System;
using System.Collections.Generic;
using Selenium;
using System.Windows.Forms;

namespace Cálculadora_de_Integrales
{
    public partial class Form1 : Form
    {
        bool limiteSuperior, limiteInferior = false;
        bool txtEnfocado = false;
        //verificacion del punto.
        bool revisionDato = false;

        //lista con los signos aritmeticos
        static List<Button> lista1 = new List<Button>();
        List<string> lista2 = new List<string>();
        bool signosVerificacion = false;

        public Form1()
        {
            InitializeComponent();
            lista1.Add(buttonSumar);
            lista1.Add(buttonRestar);
            lista1.Add(buttonDividir);
            lista1.Add(buttonMulti);
            /////
            ///
            lista2.Add("+");
            lista2.Add("-");
            lista2.Add("/");
            lista2.Add("*");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Typing("1");
            revisionDato = true;
            EnableSing();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Typing("2");
            revisionDato = true;
            EnableSing();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Typing("3");
            revisionDato = true;
            EnableSing();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Typing("4");
            revisionDato = true;
            EnableSing();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Typing("5");
            revisionDato = true;
            EnableSing();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Typing("6");
            revisionDato = true;
            EnableSing();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Typing("7");
            revisionDato = true;
            EnableSing();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Typing("8");
            revisionDato = true;
            EnableSing();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Typing("9");
            revisionDato = true;
            EnableSing();
        }

        private void buttonParentesisAbierto_Click(object sender, EventArgs e)
        {

            textBox1.Text += "(";
            EnableSing();
        }

        private void buttonParentesisCerrado_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
            EnableSing();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^";
            EnableSing();
        }

        private void buttonRaiz_Click(object sender, EventArgs e)
        {
            textBox1.Text += "√";
            EnableSing();
        }

        private void buttonDividir_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
            unableSing();
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
            unableSing();
        }

        private void buttonRestar_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
            unableSing();
        }

        private void buttonSumar_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
            unableSing();
        }

        private void buttonPi_Click(object sender, EventArgs e)
        {
            textBox1.Text += "π";
            EnableSing();
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            if (txtEnfocado == false)
            {
                textBox1.Text += "y";
                EnableSing();
            }
            else
            {
                textBox2.Text = "y";
            }
         
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            if (txtEnfocado == false)
            {
                textBox1.Text += "x";
                EnableSing();
            }
            else
            {
                textBox2.Text = "x";
            }
        }

        private void buttonPunto_Click(object sender, EventArgs e)
        {
            if (revisionDato)
            {
                textBox1.Text += ".";
                revisionDato = false;
                unableSing();
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if (txtEnfocado)
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            }
            else if (limiteInferior && tbLimiteInferior.Text.Length > 0)
            {
                tbLimiteInferior.Text = tbLimiteInferior.Text.Substring(0, tbLimiteInferior.Text.Length - 1);
            }
            else if (limiteSuperior && tbLimiteSuperior.Text.Length > 0)
            {
                tbLimiteSuperior.Text = tbLimiteSuperior.Text.Substring(0, tbLimiteSuperior.Text.Length - 1);
            }
            
            else if (textBox1.Text.Length > 0 && limiteInferior == false && limiteSuperior == false)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                VerificarSigno();
            }

        }

        private void tbLimiteSuperior_Click(object sender, EventArgs e)
        {
            limiteSuperior = true;
            limiteInferior = false;
            txtEnfocado = false;
        }

        private void tbLimiteInferior_Click(object sender, EventArgs e)
        {
            limiteInferior = true;
            limiteSuperior = false;
            txtEnfocado = false;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Typing("0");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            limiteInferior = false;
            limiteSuperior = false;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            txtEnfocado = true;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txtEnfocado = false;
        }

        private void btnTrigonometricas_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;
        }

        private void btnSeno_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "sin";

        }

        private void btnCos_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "cos";
        }

        private void btnTan_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "tan";
        }

        private void Typing(string x)
        {
            if (limiteSuperior)
            {
                tbLimiteSuperior.Text += x;
            }
            else if (limiteInferior)
            {
                tbLimiteInferior.Text += x;

            }
            else
            {
                textBox1.Text += x;
            }
        }

        private void unableSing() {
            foreach (var dato in lista1) {
                dato.Enabled = false;
            }
        }

        private static void EnableSing()
        {
            foreach (var dato in lista1)
            {
                dato.Enabled = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "")
            {
                Resultado form = new Resultado();
                form.label1.Visible = true;
                form.pictureBox1.Visible = false;
                form.Visible = true; 
                
                string result = Selenium.Webdriver.MathSolver(textBox1.Text, tbLimiteInferior.Text, tbLimiteSuperior.Text, textBox2.Text);
                form.label1.Visible = false;
                form.pictureBox1.ImageLocation = result;
                form.pictureBox1.Visible = true;



            }
            else
            {
                MessageBox.Show("Debe de especificar con respecto a que variable se va a integral");
                txtEnfocado = true;
                textBox2.Focus();
            }
            
           
            
        }

        public static void Clear()
        {
            textBox1.Text = "";
            tbLimiteInferior.Text = "";
            tbLimiteSuperior.Text = "";
            textBox2.Text = "";
            EnableSing();
        }
        

        private void VerificarSigno() {
            string ultimoCaracter;
            bool bandera = false;
            if (textBox1.Text.Length > 0)
            {
                ultimoCaracter = textBox1.Text.Substring(textBox1.Text.Length - 1);
                //MessageBox.Show(ultimoCaracter);
                foreach (var dato in lista2)
                {
                    if ( ultimoCaracter == dato) {
                        bandera = true; 
                    }
                }

                if (bandera)
                {
                    unableSing();
                }
                else {
                    EnableSing();
                }
            }
        }
    }
}
