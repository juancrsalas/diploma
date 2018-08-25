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
        BLL.Componente gestorComponente = new BLL.Componente();

        public Menu(Form principal)
        {
            InitializeComponent();
            label2.Text = Servicios.Sesion.Instancia.usuario.Email;
            prin = principal;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = gestorComponente.traerFamilias();
            listBox1.DisplayMember = "Descripcion";
            listBox2.DataSource = gestorComponente.traerPatentes();
            listBox2.DisplayMember = "Descripcion";

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                BE.Familia fam= (BE.Familia)listBox1.SelectedItem;
                foreach (BE.Componente comp in fam.Permisos)
                {
                    if (!Servicios.Sesion.Instancia.usuario.Permisos.ContainsKey(comp.Codigo))
                    {
                        Servicios.Sesion.Instancia.usuario.Permisos.Add(comp.Codigo, comp);
                        gestorUsuario.AgregarPermiso(comp);
                    }
                    
                }
            }
            else if (listBox2.SelectedIndex >-1)
            {
                if (!Servicios.Sesion.Instancia.usuario.Permisos.ContainsKey(((BE.Componente)listBox2.SelectedItem).Codigo))
                {
                    Servicios.Sesion.Instancia.usuario.Permisos.Add(((BE.Componente)listBox2.SelectedItem).Codigo, (BE.Componente)listBox2.SelectedItem);
                    gestorUsuario.AgregarPermiso((BE.Componente)listBox2.SelectedItem);
                }    
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
            {
                listBox1.SelectedIndex = -1;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox2.SelectedIndex = -1;
            }
        }
    }
}
