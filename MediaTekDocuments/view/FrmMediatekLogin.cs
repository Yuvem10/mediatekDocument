using MediaTekDocuments.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTekDocuments.model;

namespace MediaTekDocuments.view
{
    public partial class FrmMediatekLogin : Form
    {
        private readonly FrmMediatekControllerLogin controller;

        public FrmMediatekLogin()
        {
            InitializeComponent();
            controller = new FrmMediatekControllerLogin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilisateur utilisateur = controller.checkLogin(textBox1.Text, textBox2.Text);
            if (utilisateur != null)
            {
                FrmMediatek frmMediatek = new FrmMediatek(utilisateur);
                try { frmMediatek.Show();
                    this.Hide();
                }
                catch (Exception ex) { MessageBox.Show("Vous n'avez pas les droits pour utiliser cette application"); }
                
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect");
            }
        }

    }
}
