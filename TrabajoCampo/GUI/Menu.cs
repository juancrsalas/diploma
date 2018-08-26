﻿using System;
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
            prin = principal;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //gestorUsuario.AltaUsuario(textBox1.Text, textBox2.Text);
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.Gerencia ger = new GUI.Gerencia(this);
            ger.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.ServicesGUI serv = new GUI.ServicesGUI(this);
            serv.Show();
        }
    }
}
