using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        BLL.Usuario gestorUsuario = new BLL.Usuario();
        BLL.DigitoVerificador gestorDigito = new BLL.DigitoVerificador();
        BLL.Bitacora gestorBitacora = new BLL.Bitacora();
        BLL.Traductor traductor = new BLL.Traductor();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestorUsuario.AltaUsuario(textBox1.Text, textBox2.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (gestorUsuario.Validar(textBox1.Text, textBox2.Text)==Servicios.LoginResult.ValidUser)
                {
                    BE.Usuario user = gestorUsuario.TraerUsuario(textBox1.Text);
                    Servicios.Sesion.Instancia.Login(user);
                    gestorBitacora.EscribirBitacora("Login", Servicios.TipoEvento.Information, user);
                    this.Hide();
                    GUI.Menu m = new GUI.Menu(this);
                    m.Show();
                }
            }
            catch (Servicios.LoginException ex)
            {
                MessageBox.Show(ex.resultado.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                gestorDigito.VerificarDigito();
                traductor.CambiarIdioma(1);
                string trad = "";
                Servicios.Diccionario.Instancia.diccionario.TryGetValue("P1LBL1", out trad);
                label1.Text = trad;
                Servicios.Diccionario.Instancia.diccionario.TryGetValue("P1LBL2", out trad);
                label2.Text = trad;
                Servicios.Diccionario.Instancia.diccionario.TryGetValue("P1B1", out trad);
                button1.Text = trad;
            }
            catch (Servicios.DigitoException ex)
            {
                MessageBox.Show(ex.resultado.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
