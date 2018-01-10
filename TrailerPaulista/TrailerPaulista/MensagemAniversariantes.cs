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
using System.Globalization;

namespace TrailerPaulista
{
    public partial class MensagemAniversariantes : Form
    {
        public MensagemAniversariantes()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MensagemAniversariantes_Load(object sender, EventArgs e)
        {
            int NUMERO_ANIVERSARIANTES = 0;

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();


            string mes = DateTime.Now.ToString("MM", new CultureInfo("pt-BR"));

            comando.CommandText = "SELECT COUNT(*) FROM CLIENTES WHERE ANIVERSARIO LIKE '%/" + mes + "/%'";

            NUMERO_ANIVERSARIANTES = int.Parse(comando.ExecuteScalar().ToString());

            conexao.Close();


            if (NUMERO_ANIVERSARIANTES > 0)
            {
                txt_mensagem.Text = "O Trailer Paulista está com " + NUMERO_ANIVERSARIANTES + " clientes fazendo aniversário este mês! Dê os parabéns!";
            }
            else if (NUMERO_ANIVERSARIANTES <= 0)
            {
                txt_mensagem.Text = "Não há aniversariantes este mês!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
