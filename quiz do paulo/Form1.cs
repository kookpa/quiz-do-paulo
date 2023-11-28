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

namespace quiz_do_paulo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string conexaoString = 
            "server=localhost;user=root;password=;database=quiz;";

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            string pergunta = "";
            string alternativaA = "", alternativaB = "", alternativaC = "", alternativaD = "";
            long ultimoID = 0;

            pergunta = rtxPergunta.Text;

            alternativaA = txbAlternativaA.Text;
            alternativaB=txbAlternativaB.Text;
            alternativaC=txbAlternativaC.Text;
            alternativaD=txbAlternativaD.Text;

            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                conexao.Open();
                string scriptInsert = "INSERT INTO 1perg (nome_pergunta) VALUE (@nome_pergunta)";

                using  (MySqlCommand comando = new MySqlCommand(scriptInsert, conexao))
                {
                    comando.Parameters.AddWithValue("@nome_pergunta", pergunta);

                    comando.ExecuteNonQuery();

                     ultimoID = comando.LastInsertedId;
                }

            }
            MessageBox.Show("Pegunta Cadastrada com Sucesso!" + ultimoID.ToString());
        }
    }
}
