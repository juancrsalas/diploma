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
    public partial class Gerencia : Form
    {
        Form menu;
        public Gerencia(Form Menu)
        {
            InitializeComponent();
            menu = Menu;
        }

        private void Gerencia_Load(object sender, EventArgs e)
        {
            
        }

        private void Gerencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.AsignacionPermisosGUI asigp = new GUI.AsignacionPermisosGUI(this);
            asigp.Show();
        }
    }
}
