using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TrailerPaulista
{
    public partial class MensagensForm : UserControl
    {
        public MensagensForm()
        {
            InitializeComponent();
        }

        private void MensagensForm_Load(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            comando.CommandText = "SELECT * FROM MENSAGENS";

            MySqlDataReader dados_consulta = comando.ExecuteReader();

            while (dados_consulta.Read())
            {
                string MENSAGEM = dados_consulta.GetString("MENSAGEM");

                lista_mensagens.Items.Insert(0, MENSAGEM);

            }

            comando.CommandText = "SELECT * FROM PEDIDOS";

            dados_consulta = comando.ExecuteReader();

            while (dados_consulta.Read())
            {
                string PEDIDO = dados_consulta.GetString("PEDIDO");
                string MESA = dados_consulta.GetString("MESA");

                lista_pedidos.Items.Insert(0, "Pedido: " + PEDIDO + "; Mesa: " + MESA);

            }


            conexao.Close();
        }
    }
}
