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
    public partial class TarefasForm : UserControl
    {
        public TarefasForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void SecondCustomControl_Load(object sender, EventArgs e)
        {
            lista_tarefas.Items.Clear();

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            comando.CommandText = "SELECT * FROM TAREFAS";

            MySqlDataReader dados_consulta = comando.ExecuteReader();

            while (dados_consulta.Read())
            {
                string tarefa = dados_consulta.GetString("TAREFA");

                lista_tarefas.Items.Insert(0, tarefa);
            
            }

            conexao.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");
            
            conexao.Open();
            
            MySqlCommand comando = conexao.CreateCommand();
            
            comando.CommandText = "INSERT INTO TAREFAS (TAREFA) VALUES (?tarefa)";
            
            comando.Parameters.AddWithValue("?tarefa", txt_anotacoes.Text);

            comando.ExecuteNonQuery();

            conexao.Close();

            this.SecondCustomControl_Load(null,null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            conexao.Open();

            MySqlCommand comando = conexao.CreateCommand();

            comando.CommandText = "DELETE FROM TAREFAS";

            comando.Parameters.AddWithValue("?tarefa", txt_anotacoes.Text);

            comando.ExecuteNonQuery();

            conexao.Close();

            this.SecondCustomControl_Load(null, null);
        }
    }
}
