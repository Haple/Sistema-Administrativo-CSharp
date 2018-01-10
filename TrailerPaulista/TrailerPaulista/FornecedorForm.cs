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

namespace TrailerPaulista
{
    public partial class FornecedorForm : UserControl
    {
        public FornecedorForm()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {

            if (txt_produto.Text == "")
            {
                MessageBox.Show("O campo 'Produto:' deve ser preenchido!");
                return;
            }

            if (txt_fornecedor.Text == "")
            {
                MessageBox.Show("O campo 'Fornecedor:' deve ser preenchido!");
                return;
            }

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            comando.CommandText = "INSERT INTO FORNECEDOR (NOME, PRODUTO, TELEFONE) VALUES (?NOME, ?PRODUTO, ?TELEFONE)";

            comando.Parameters.AddWithValue("?NOME", txt_fornecedor.Text);
            comando.Parameters.AddWithValue("?PRODUTO", txt_produto.Text);
            comando.Parameters.AddWithValue("?TELEFONE", txt_telefone.Text);

            comando.ExecuteNonQuery();

            conexao.Close();

            this.CustomControl4_Load_1(null, null);
        }

        private void CustomControl4_Load(object sender, EventArgs e)
        {
            
        }

        private void CustomControl4_Load_1(object sender, EventArgs e)
        {
            //1. Criar conexao
            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");
            //2. Abrir conexao
            conexao.Open();
            //3. Criar o comando
            MySqlCommand cmd = conexao.CreateCommand();
            //4. Adicionar comando
            cmd.CommandText = "SELECT * FROM FORNECEDOR";
            //6. Obtem os dados da consulta
            MySqlDataAdapter resultado_consulta = new MySqlDataAdapter(cmd);
            //7. Ligar a tabela e a grade
            DataSet DS = new DataSet();
            //8. Preencher a grade com os dados da tabela
            resultado_consulta.Fill(DS);
            //9.
            dataGridView1.DataSource = DS.Tables[0];
            //10.
            conexao.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_cod.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txt_fornecedor.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txt_produto.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            txt_telefone.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod = txt_cod.Text;

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");
     
            conexao.Open();
            
            MySqlCommand comando = conexao.CreateCommand();
            
            comando.CommandText = "DELETE FROM fornecedor WHERE cod = ?cod;";
            
            comando.Parameters.AddWithValue("?cod", cod);
            
            comando.ExecuteNonQuery();
            
            conexao.Close();

            this.CustomControl4_Load_1(null, null);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");
            
            conexao.Open();

            MySqlCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "SELECT * FROM FORNECEDOR WHERE NOME like ?pesquisa or PRODUTO like ?pesquisa or COD like ?pesquisa";

            cmd.Parameters.AddWithValue("?pesquisa", "%" + txt_pesquisa.Text.TrimStart() + "%");

            MySqlDataAdapter resultado_consulta = new MySqlDataAdapter(cmd);

            DataSet DS = new DataSet();

            resultado_consulta.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
     
            conexao.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
