﻿using System;
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
        string conn = @"Data Source = VLADYSLAV-PC\SQLEXPRESS; Initial Catalog = aFueling; Integrated Security = true;";

        public Form1()
        {
            InitializeComponent();
            InitialComboBoxFueling();
            //InitialComboBoxWorker();
            //InitialComboBoxFuel();
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
                    comboBox1.Items.Add($"{sqlDataReader["NameFueling"]}");
                }
            }
        }

        //private void InitialComboBoxWorker()
        //{
        //    SqlConnection connection = this.Connect();
        //    comboBox2.Items.Clear();
        //    command = new SqlCommand("select * from Workers;", connection);
        //    sqlDataReader = command.ExecuteReader();
        //    while (sqlDataReader.Read())
        //    {
        //        comboBox2.Items.Add($"{sqlDataReader["NameWorker"]} | {sqlDataReader["LastNameWorker"]}");
        //    }
            
        //}

        //private void InitialComboBoxFuel()
        //{
        //    SqlConnection connection = this.Connect();
        //    command = new SqlCommand("select * from Fuel;", connection);
        //    sqlDataReader = command.ExecuteReader();
        //    while (sqlDataReader.Read())
        //    {
        //        comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]} ");
        //    }
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            SqlConnection connection = this.Connect();
            command = new SqlCommand($"select Workers.NameWorker, Workers.LastNameWorker from Workers, Fueling where Fueling.id = Workers.Fueling_id and Fueling.NameFueling = '{comboBox1.Text}';", connection);
            sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox2.Items.Add($"{sqlDataReader["NameWorker"]} | {sqlDataReader["LastNameWorker"]}");
            }
            sqlDataReader.Close();
            command = new SqlCommand($"select Fuel.MarkaFuel from FuelForFueling fff, Fueling, Fuel where Fueling.id = fff.Fueling_id and Fuel.id = fff.Fuel_id and Fueling.NameFueling = '{comboBox1.Text}';", connection);
            sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox3.Items.Add($"{sqlDataReader["MarkaFuel"]}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = this.Connect();
            command = new SqlCommand($"select FuelForFueling.PriceOfLiter from Fueling, Fuel, FuelForFueling where Fuel.id = FuelForFueling.Fuel_id and Fueling.id = FuelForFueling.Fueling_id and Fueling.NameFueling = '{comboBox1.Text}' and Fuel.MarkaFuel = '{comboBox3.Text}';", connection);
            sqlDataReader = command.ExecuteReader();
            if (comboBox1.Text != string.Empty && comboBox2.Text != string.Empty && comboBox3.Text != string.Empty)
            {
                Console.WriteLine($"{sqlDataReader["PriceOfLiter"]}");
                list.Add($"{comboBox1.Text} | ");
                list.Add($"{comboBox2.Text} | ");
                list.Add($"{comboBox3.Text} | ");
                list.Add($"{sqlDataReader["PriceOfLiter"]}");
            }
        }
    }
}
