using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrailerPaulista
{
    public partial class TrailerPaulista : Form
    {
        public TrailerPaulista()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag.Height = button1.Height;
            flag.Top = button1.Top;
            firstCustomControl1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag.Height = button3.Height;
            flag.Top = button3.Top;
            customControl41.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flag.Height = button4.Height;
            flag.Top = button4.Top;
            clientesForm1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            flag.Height = button6.Height;
            flag.Top = button6.Top;
            caixaForm1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flag.Height = button5.Height;
            flag.Top = button5.Top;
            relatoriosForm1.BringToFront();
            relatoriosForm1.RelatoriosForm_Load(null,null);
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Sobre s = new Sobre();
            s.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CONFIG C = new CONFIG();
            C.Show();
            Hide();
        }

        private void TrailerPaulista_Load(object sender, EventArgs e)
        {
            MensagemAniversariantes ma = new MensagemAniversariantes();
            ma.Show();
            ma.BringToFront();
        }
    }
}
