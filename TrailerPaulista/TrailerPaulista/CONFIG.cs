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
    public partial class CONFIG : Form
    {
        public CONFIG()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            TrailerPaulista tp = new TrailerPaulista();
            tp.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();


            comando.CommandText = "SELECT count(*) FROM USUARIOS WHERE COD = 1 AND SENHA = '" + txt_senha_atual.Text + "'";

            int resposta = int.Parse(comando.ExecuteScalar().ToString());

            if (resposta == 1)
            {

                comando.CommandText = "UPDATE USUARIOS SET NOME = '" + txt_usuario.Text + "', SENHA= '" + txt_nova_senha.Text + "' WHERE COD = 1;";
                comando.ExecuteNonQuery();
                MessageBox.Show("AS CREDENCIAIS FORAM ATUALIZADAS");
            }
            else
            {
                MessageBox.Show("TENTE NOVAMENTE");
            }


            conexao.Close();
        }
    }
}
