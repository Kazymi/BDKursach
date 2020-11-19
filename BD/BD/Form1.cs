using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class Form1 : Form
    {
        DataGridView DG;
        string qSelect;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartCLub("SELECT * FROM Club ORDER BY IDClub");
        }
        void StartCLub(string Text)
        {
            clearClub();
            DG = dataGridView1;
            qSelect = Text;
            string conect = Library.Patch;
            SqlConnection connection = new SqlConnection(conect);
            connection.Open();
            SqlCommand CommandqSelect = new SqlCommand(qSelect, connection);
            SqlDataReader sqlData = CommandqSelect.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (sqlData.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = sqlData[0].ToString();
                data[data.Count - 1][1] = sqlData[1].ToString();
                data[data.Count - 1][2] = sqlData[2].ToString();
                data[data.Count - 1][3] = sqlData[3].ToString();
            }
            sqlData.Close();
            connection.Close();
            foreach (string[] i in data)
            {
                DG.Rows.Add(i);
            }
        }

          void clearClub()
        {
            dataGridView1.Rows.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StartCLub("SELECT * FROM Club ORDER BY IDClub");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StartCLub("SELECT * FROM Club ORDER BY Name");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartCLub("SELECT * FROM Club ORDER BY NumberClub");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearClub();
            DG = dataGridView1;
            qSelect = "SELECT * FROM Club where IDClub = @id";
            string conect = Library.Patch;
            SqlConnection connection = new SqlConnection(conect);
            connection.Open();
            SqlCommand CommandqSelect = new SqlCommand(qSelect, connection);
            CommandqSelect.Parameters.AddWithValue("id", textBox1.Text);
            SqlDataReader sqlData = CommandqSelect.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (sqlData.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = sqlData[0].ToString();
                data[data.Count - 1][1] = sqlData[1].ToString();
                data[data.Count - 1][2] = sqlData[2].ToString();
                data[data.Count - 1][3] = sqlData[3].ToString();
            }
            sqlData.Close();
            connection.Close();
            foreach (string[] i in data)
            {
                DG.Rows.Add(i);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearClub();
            DG = dataGridView1;
            qSelect = "SELECT * FROM Club where Name = @id";
            string conect = Library.Patch;
            SqlConnection connection = new SqlConnection(conect);
            connection.Open();
            SqlCommand CommandqSelect = new SqlCommand(qSelect, connection);
            CommandqSelect.Parameters.AddWithValue("id", textBox2.Text);
            SqlDataReader sqlData = CommandqSelect.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (sqlData.Read())
            {
                data.Add(new string[4]);
                data[data.Count - 1][0] = sqlData[0].ToString();
                data[data.Count - 1][1] = sqlData[1].ToString();
                data[data.Count - 1][2] = sqlData[2].ToString();
                data[data.Count - 1][3] = sqlData[3].ToString();
            }
            sqlData.Close();
            connection.Close();
            foreach (string[] i in data)
            {
                DG.Rows.Add(i);
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
