using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace TrailerPaulista
{
    public partial class CaixaForm : UserControl
    {
        public CaixaForm()
        {
            InitializeComponent();
        }

        private void CaixaForm_Load(object sender, EventArgs e)
        {
            double total = 0.0;

            lista_caixa.Items.Clear();

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            comando.CommandText = "SELECT DATA_REGISTRO, VALOR FROM CAIXA";

            MySqlDataReader dados_consulta = comando.ExecuteReader();

            while (dados_consulta.Read())
            {
                string DATA_REGISTRO = dados_consulta.GetString("DATA_REGISTRO");
                double VALOR = Convert.ToDouble(dados_consulta.GetString("VALOR"));

                string texto_valor;
                if (VALOR < 0) texto_valor = "Retirada de " + String.Format("{0:0.00}", VALOR);
                else texto_valor = "Depósito de " + String.Format("{0:0.00}", VALOR);

                lista_caixa.Items.Insert(0, DATA_REGISTRO + ", " + texto_valor);

                total += VALOR;
            }

            txt_total.Text = "R$" + String.Format("{0:0.00}", total);

            conexao.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string texto_hoje = DateTime.Now.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");
            
            conexao.Open();
            
            MySqlCommand comando = conexao.CreateCommand();
            
            comando.CommandText = "INSERT INTO CAIXA (DATA_REGISTRO, VALOR) VALUES ( ?DATA_REGISTRO, ?VALOR)";
            
            comando.Parameters.AddWithValue("?DATA_REGISTRO", texto_hoje);
            comando.Parameters.AddWithValue("?VALOR", txt_valor.Text);
         
            comando.ExecuteNonQuery();
            
            conexao.Close();

            this.CaixaForm_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string texto_hoje = DateTime.Now.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            comando.CommandText = "INSERT INTO CAIXA (DATA_REGISTRO, VALOR) VALUES ( ?DATA_REGISTRO, ?VALOR)";

            comando.Parameters.AddWithValue("?DATA_REGISTRO", texto_hoje);
            comando.Parameters.AddWithValue("?VALOR", "-" + txt_valor.Text);

            comando.ExecuteNonQuery();

            conexao.Close();

            this.CaixaForm_Load(null,null);
        }
    }
}
