using System;
using System.Windows.Forms;

namespace Suche
{
    public partial class Form1 : Form
    {
        #region FormAktionen
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main.StartMenu(textBox1.Text);
        } //Der Such Button

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Hide();
                Main.StartMenu(textBox1.Text);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
       



        #endregion FormAktionen

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main.StartBigSync();
        }
    }

}
