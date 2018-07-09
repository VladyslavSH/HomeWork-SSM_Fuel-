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
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataReader sqlDataReader = null;
        List<string> list = null; 

        public Form1()
        {
            InitializeComponent();
            InitialComboBoxFueling();
            InitialComboBoxWorker();
            InitialComboBoxFuel();
            connection = new SqlConnection(@"Data Source = COMP409\SQLEXPRESS; Initial Catalog = aFueling; Integrated Security = true;");
            command = new SqlCommand();
            list = new List<string>();
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally {
                connection?.Close();
            }
        }

        private void InitialComboBoxFueling()
        {
            throw new NotImplementedException();
        }

        private void InitialComboBoxWorker()
        {
            throw new NotImplementedException();
        }

        private void InitialComboBoxFuel()
        {
            throw new NotImplementedException();
        }
    }
}
