using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TrailerPaulista
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();


            comando.CommandText = "SELECT count(*) FROM USUARIOS WHERE NOME = '" + txt_usuario.Text + "' AND SENHA = '" + txt_senha.Text + "'";

            int resposta = int.Parse(comando.ExecuteScalar().ToString());

            if (resposta == 1)
            {
                TrailerPaulista tp = new TrailerPaulista();
                Hide();
                tp.Show();

            }
            else
            {
                MessageBox.Show("TENTE NOVAMENTE");
            }


            conexao.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
