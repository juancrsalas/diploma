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
    public partial class AltaIdioma : Form
    {
        Form prev;
        BLL.Traductor traductor = new BLL.Traductor();
        Dictionary<string, string> nuevoDiccionario = new Dictionary<string, string>();

        public AltaIdioma(Form Prev)
        {
            InitializeComponent();
            prev = Prev;
        }

        private void AltaIdioma_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic = traductor.TraerControles();
            foreach(KeyValuePair<string,string> row in dic)
            {
                listBox1.Items.Add(row);
            }
            //listBox1.DataSource = new BindingSource(dic, null);
            listBox1.DisplayMember = "CodigoControl";
        }

        private void AltaIdioma_FormClosing(object sender, FormClosingEventArgs e)
        {
            prev.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                KeyValuePair<string, string> val = (KeyValuePair<string, string>)listBox1.SelectedItem;
                textBox1.Text = val.Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null && textBox2.Text!="")
            {
                KeyValuePair<string, string> val = (KeyValuePair<string, string>)listBox1.SelectedItem;
                nuevoDiccionario.Add(val.Key.ToString(), textBox2.Text.ToString());
                listBox1.Items.Remove(val);
                listBox1.SelectedItem = null;
                textBox2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text!="" && listBox1.Items.Count==0)
            {
                traductor.CrearTraduccion(textBox3.Text, nuevoDiccionario);
            }
        }
    }
}
