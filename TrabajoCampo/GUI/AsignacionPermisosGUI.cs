using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace GUI
{
    public partial class AsignacionPermisosGUI : Form
    {
        Form prev;
        BLL.Usuario gestorUsuario = new BLL.Usuario();
        BLL.Componente gestorComponente = new BLL.Componente();

        public AsignacionPermisosGUI(Form Prev)
        {
            InitializeComponent();
            prev = Prev;
        }

        private void AsignacionPermisosGUI_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = gestorUsuario.ListarUsuarios();
            listBox1.DisplayMember = "Email";
            listBox2.DataSource = gestorComponente.traerFamilias();
            listBox2.DisplayMember = "Descripcion";
            listBox3.DataSource = gestorComponente.traerPatentes();
            listBox3.DisplayMember = "Descripcion";
        }

        private void AsignacionPermisosGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            prev.Show();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                BE.Usuario usu = (BE.Usuario)listBox1.SelectedItem;
                if (listBox2.SelectedIndex > -1)
                {
                    BE.Familia fam = (BE.Familia)listBox2.SelectedItem;
                    foreach (BE.Componente comp in fam.Permisos)
                    {
                        if (!usu.Permisos.ContainsKey(comp.Codigo))
                        {
                            usu.Permisos.Add(comp.Codigo, comp);
                            gestorUsuario.AgregarPermiso(usu,comp);
                        }

                    }
                }
                else if (listBox3.SelectedIndex > -1)
                {
                    if (!usu.Permisos.ContainsKey(((BE.Componente)listBox3.SelectedItem).Codigo))
                    {
                        usu.Permisos.Add(((BE.Componente)listBox3.SelectedItem).Codigo, (BE.Componente)listBox3.SelectedItem);
                        gestorUsuario.AgregarPermiso(usu,(BE.Componente)listBox3.SelectedItem);
                    }
                }
            }
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
            {
                listBox3.SelectedIndex = -1;
                listBox4.Show();
                listBox4.DataSource = ((BE.Familia)listBox2.SelectedItem).Permisos;
                listBox4.DisplayMember = "Descripcion";
            }
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex > -1)
            {
                listBox2.SelectedIndex = -1;
                listBox4.Hide();
            }
        }
    }
}
