using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace TrailerPaulista
{
    public partial class RelatoriosForm : UserControl
    {

        string ano = "2017";


        public RelatoriosForm()
        {
            InitializeComponent();
        }

        public void RelatoriosForm_Load(object sender, EventArgs e)
        {

            chart1.Series.Clear();

            List<string> meses = new List<string> { };
            List<double> saldos = new List<double> { };    

            MySqlConnection conexao = new MySqlConnection("server=localhost;database=TRAILER;uid=root;pwd=;");

            for (int i = 1; i <=12; i++)
            {
                double VALOR = 0.0;
                string mes = "";
                double saldo = 0.0;

                conexao.Open();

                MySqlCommand comando = conexao.CreateCommand();

                mes = i.ToString("D2");

                comando.CommandText = "SELECT * FROM CAIXA WHERE DATA_REGISTRO LIKE '%/" + mes + "/" + ano + "%'";

                MySqlDataReader dados_consulta = comando.ExecuteReader();

                while (dados_consulta.Read())
                {

                    VALOR = dados_consulta.GetDouble("VALOR");

                    saldo += VALOR;         
                    
                }

                saldos.Add(saldo);
                meses.Add(DateTime.Parse("01/"+mes+"/2000").ToString("MMM", new CultureInfo("pt-BR")));

                conexao.Close();
            }

            System.Windows.Forms.DataVisualization.Charting.Series yearSeries = chart1.Series.Add("Fluxo de movimentações de " + ano);
            yearSeries.Points.DataBindXY(meses, saldos);
            yearSeries.ChartType = SeriesChartType.Column;
          
        }

        private void chart1_Click(object sender, EventArgs e){ }

        private void button1_Click(object sender, EventArgs e)
        {
            ano = txt_ano.Text;
            this.RelatoriosForm_Load(null,null);
        }


        private void button2_Click(object sender, EventArgs e) { }
    }
}
