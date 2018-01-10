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
using System.Net;

namespace TrailerPaulista
{
    public partial class ClientesForm : UserControl
    {
        public ClientesForm()
        {
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {

            if (txt_cliente.Text == "")
            {

                MessageBox.Show("O campo 'Cliente:' é obrigatório!");
                return;

            }
            

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            comando.CommandText = "INSERT INTO CLIENTES (NOME, ANIVERSARIO, TELEFONE) VALUES (?NOME, ?ANIVERSARIO, ?TELEFONE)";

            comando.Parameters.AddWithValue("?NOME", txt_cliente.Text);
            comando.Parameters.AddWithValue("?ANIVERSARIO", txt_aniversario.Value.ToString("dd/MM/yyyy", new CultureInfo("pt-BR")));
            comando.Parameters.AddWithValue("?TELEFONE", txt_telefone.Text);

            comando.ExecuteNonQuery();

            conexao.Close();

            this.ClientesForm_Load(null, null);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            
            lista_clientes.Items.Clear();

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            string mes = DateTime.Now.ToString("MM", new CultureInfo("pt-BR"));

            comando.CommandText = "SELECT NOME, ANIVERSARIO, TELEFONE FROM CLIENTES WHERE ANIVERSARIO LIKE '%/" + mes + "/%'";

            MySqlDataReader dados_consulta = comando.ExecuteReader();

            while (dados_consulta.Read())
            {
                string NOME = dados_consulta.GetString("NOME");
                string ANIVERSARIO = dados_consulta.GetString("ANIVERSARIO");
                string TELEFONE = dados_consulta.GetString("TELEFONE");

                lista_clientes.Items.Insert(0, NOME + "; " + ANIVERSARIO + "; " + TELEFONE);

            }

            conexao.Close();
           

          
            conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");
          
            conexao.Open();
          
            MySqlCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "SELECT * FROM CLIENTES";
   
            MySqlDataAdapter resultado_consulta = new MySqlDataAdapter(cmd);

            DataSet DS = new DataSet();

            resultado_consulta.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];

            conexao.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_cod.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txt_cliente.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txt_telefone.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            txt_aniversario.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod = txt_cod.Text;

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            comando.CommandText = "DELETE FROM CLIENTES WHERE COD = ?cod;";

            comando.Parameters.AddWithValue("?cod", cod);

            comando.ExecuteNonQuery();

            conexao.Close();

            this.ClientesForm_Load(null, null);
        }

        private void txt_pesquisa_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "SELECT * FROM CLIENTES WHERE NOME like ?pesquisa OR ANIVERSARIO LIKE ?pesquisa";

            cmd.Parameters.AddWithValue("?pesquisa", "%" + txt_pesquisa.Text.TrimStart() + "%");

            MySqlDataAdapter resultado_consulta = new MySqlDataAdapter(cmd);

            DataSet DS = new DataSet();

            resultado_consulta.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];

            conexao.Close();
        }
    }
}
