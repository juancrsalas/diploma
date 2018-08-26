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
    public partial class ServicesGUI : Form
    {
        Form menu;
        public ServicesGUI(Form Menu)
        {
            InitializeComponent();
            menu = Menu;
        }

        private void ServicesGUI_Load(object sender, EventArgs e)
        {

        }

        private void ServicesGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }
    }
}
