using System;
using System.Collections.Generic;
using Selenium;
using System.Windows.Forms;
using System.Linq;

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
        
        //LISTA PARA LAS TRIGONOMETRICAS
        static List<Button> listaTrigo = new List<Button>();
        //List<String> stringTrigo = new List<string>();
        int indiceTexto = 0;

        public Form1()
        {
            InitializeComponent();
            lista1.Add(buttonSumar);
            lista1.Add(buttonRestar);
            lista1.Add(buttonDividir);
            lista1.Add(buttonMulti);
            /////
            ///basic arit
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
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "(");
            indiceTexto++;
            EnableSing();
        }

        private void buttonParentesisCerrado_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, ")");
            indiceTexto++;
            EnableSing();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "^");
            indiceTexto++;
            EnableSing();
        }

        private void buttonRaiz_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "√()");
            indiceTexto += 2;
            EnableSing();
        }

        private void buttonDividir_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "/");
            indiceTexto++;
            unableSing();
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "*");
            indiceTexto++;
            unableSing();
        }

        private void buttonRestar_Click(object sender, EventArgs e)
        {
            if (txtEnfocado)
            {
                textBox1.Text = textBox1.Text.Insert(indiceTexto, "-");
                indiceTexto++;
            }
            else {
                Typing("-");
            }
            unableSing();
        }

        private void buttonSumar_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "+");
            indiceTexto++;
            unableSing();
        }

        private void buttonPi_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "π");
            indiceTexto++;
            EnableSing();
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            if (txtEnfocado == false)
            {
                textBox1.Text = textBox1.Text.Insert(indiceTexto, "y");
                indiceTexto++;
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
                textBox1.Text = textBox1.Text.Insert(indiceTexto, "x");
                indiceTexto++;
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
                textBox1.Text = textBox1.Text.Insert(indiceTexto, ".");
                indiceTexto++;
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
            else if (limiteInferior && boxLimiteInferior.Text.Length > 0)
            {
                boxLimiteInferior.Text = boxLimiteInferior.Text.Substring(0, boxLimiteInferior.Text.Length - 1);
                //validacionesLimites();
            }
            else if (limiteSuperior && boxLimiteSuperior.Text.Length > 0)
            {
                boxLimiteSuperior.Text = boxLimiteSuperior.Text.Substring(0, boxLimiteSuperior.Text.Length - 1);
                //validacionesLimites();
            }
            else if (textBox1.Text.Length > 0 && limiteInferior == false && limiteSuperior == false)
            {
                textBox1.Text = textBox1.Text.Substring(0, indiceTexto - 1);
                indiceTexto--; 
                VerificarSigno();
                //VerificarTrigonometrica();
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Typing("0");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            limiteInferior = false;
            limiteSuperior = false;
            indiceTexto = textBox1.SelectionStart;
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
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "sin()");
            indiceTexto += 4;
            panel2.Visible = !panel2.Visible;
        }

        private void btnCos_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "cos()");
            indiceTexto += 4;
            panel2.Visible = !panel2.Visible;
        }

        private void btnTan_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "tan()");
            indiceTexto += 4;
            panel2.Visible = !panel2.Visible;
        }

        private void Typing(string x)
        {
            if (limiteSuperior)
            {
                boxLimiteSuperior.Text += x;
            }
            else if (limiteInferior)
            {
                boxLimiteInferior.Text += x;

            }
            else
            {
                textBox1.Text = textBox1.Text.Insert(indiceTexto, x);  
                indiceTexto++;
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

        //private static void unableTrigo() {
        //    foreach (var dato in listaTrigo) {
        //        dato.Enabled = false;
        //    }
        //}

        //private static void enableTrigo() {
        //    foreach (var dato in listaTrigo) {
        //        dato.Enabled = true;
        //    }
        //}

        private void button10_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "")
            {
                Resultado form = new Resultado();
                form.label1.Visible = true;
                form.pictureBox1.Visible = false;
                form.Visible = true;
                var funcion = FuncionTraductor.Traducir(textBox1.Text);
                string result = Webdriver.MathSolver(funcion, boxLimiteInferior.Text, boxLimiteSuperior.Text, textBox2.Text);
                form.label1.Visible = false;
                form.pictureBox1.ImageLocation = result;
                form.pictureBox1.Visible = true;
                Clear();
            }
            else
            {
                MessageBox.Show("Debe de especificar con respecto a que variable se va a integral");
                txtEnfocado = true;
                textBox2.Focus();
            }   
        }

        public void Clear()
        {
            textBox1.Text = "";
            boxLimiteInferior.Text = "";
            boxLimiteSuperior.Text = "";
            textBox2.Text = "";
            indiceTexto = 0;
            EnableSing();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "csc()");
            indiceTexto += 4;
            panel2.Visible = !panel2.Visible;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "cot()");
            indiceTexto += 4 ;
            panel2.Visible = !panel2.Visible;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "sec");
            indiceTexto += 4;
            panel2.Visible = !panel2.Visible;
        }

        private void VerificarSigno() 
        { 
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
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "e");
            indiceTexto++;
        }

        private void boxLimiteSuperior_TextChanged(object sender, EventArgs e)
        {
                foreach (var datos in lista2)
                {
                    if (datos == "-")
                    {
                        unableSing();
                    }
                }
        }

        private void boxLimiteSuperior_Click_1(object sender, EventArgs e)
        {
            limiteSuperior = true;
            limiteInferior = false;
            txtEnfocado = false;
        }

        private void boxLimiteInferior_Click(object sender, EventArgs e)
        {
            limiteInferior = true;
            limiteSuperior = false;
            txtEnfocado = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(indiceTexto, "Ln()");
            indiceTexto += 3;
        }

        //private void VerificarTrigonometrica()
        //{
        //    string ultimoCaracter;
        //    bool bandera = false;
        //    if (textBox1.Text.Length > 0)
        //    {
        //        ultimoCaracter = textBox1.Text.Substring(textBox1.Text.Length - 1);
        //        //MessageBox.Show(ultimoCaracter);
        //        foreach (var dato in stringTrigo)
        //        {
        //            if (ultimoCaracter == dato)
        //            {
        //                bandera = true;
        //            }
        //        }
        //        if (bandera)
        //        {
        //            unableTrigo();
        //        }
        //        else
        //        {
        //            enableTrigo();
        //        }
        //    }
        //}
    }
}