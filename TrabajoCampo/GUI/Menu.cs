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
    public partial class Menu : Form
    {
        Form prin;
        BLL.DigitoVerificador gestorDigito = new BLL.DigitoVerificador();
        BLL.Usuario gestorUsuario = new BLL.Usuario();
        BLL.Bitacora gestorBitacora = new BLL.Bitacora();

        public Menu(Form principal)
        {
            InitializeComponent();
            label2.Text = Servicios.Sesion.Instancia.usuario.Email;
            prin = principal;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gestorUsuario.AltaUsuario(textBox1.Text, textBox2.Text);
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            gestorDigito.ActualizarDigito();
            gestorBitacora.EscribirBitacora("Logout", Servicios.TipoEvento.Information, Servicios.Sesion.Instancia.usuario);
            Servicios.Sesion.Instancia.Logout();
            prin.Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
