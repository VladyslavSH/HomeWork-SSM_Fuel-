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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlCommand command = null;
        SqlDataReader sqlDataReader = null;
        List<string> list = null;
        string conn = @"Data Source = DESKTOP-OUHKHRN\SQLEXPRESS; Initial Catalog = aFueling; Integrated Security = true;";

        public Form1()
        {
            InitializeComponent();
            InitialComboBoxFueling();
            InitialComboBoxWorker();
            InitialComboBoxFuel();
            list = new List<string>();
            
        }
        
        private SqlConnection Connect()
        {
            SqlConnection connection = new SqlConnection(this.conn);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        private void InitialComboBoxFueling()
        {
           SqlConnection connection = this.Connect();
           if(connection != null)
            {
                comboBox2.Items.Clear();
                command = new SqlCommand("select * from Fueling;", connection);
                sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox1.Items.Add($"{sqlDataReader["NameFueling"]} | {sqlDataReader["City"]}");
                }
            }
        }

        private void InitialComboBoxWorker()
        {
            SqlConnection connection = this.Connect();
            comboBox2.Items.Clear();
            command = new SqlCommand("select * from Workers;", connection);
            sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox2.Items.Add($"{sqlDataReader["NameWorker"]} | {sqlDataReader["LastNameWorker"]}");
            }
            
        }

        private void InitialComboBoxFuel()
        {
            SqlConnection connection = Connect();
            command = new SqlCommand("select * from Fuel;", connection);
            sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]} ");
                comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]} ");
                comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]} ");
                comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]} ");
                comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]} ");
                comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]} ");
                comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]} ");
            }
           
        }
    }
}
