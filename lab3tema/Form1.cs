using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab3tema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Starea conexiunii: {0}", connection.State);
                    connection.Open();
                    Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("SELECT * from Orase;", connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Orase");
                    dataGridView2.DataSource = ds.Tables["Orase"];
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mesajul erorii este: {0}", ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string connectionString;
                connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    int rowIndex = dataGridView2.CurrentCell.RowIndex;
                    Console.WriteLine("Starea conexiunii: {0}", connection.State);
                    connection.Open();
                    Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("SELECT * from Scoli where id_oras = " + dataGridView2[0, rowIndex].Value.ToString() + ";", connection);
                    Console.WriteLine(adapter.SelectCommand.CommandText);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Scoli");
                    dataGridView1.DataSource = ds.Tables["Scoli"];
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mesajul erorii este: {0}", ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Starea conexiunii: {0}", connection.State);
                    connection.Open();
                    Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("SELECT * from Scoli;", connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Scoli");
                    dataGridView1.DataSource = ds.Tables["Scoli"];
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mesajul erorii este: {0}", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                try
                {
                    string connectionString;
                    connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        Console.WriteLine("Starea conexiunii: {0}", connection.State);
                        connection.Open();
                        Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);
                        SqlDataAdapter adapter = new SqlDataAdapter();

                        SqlCommand command = new SqlCommand("Update Scoli set id_oras=@id_oras, nume=@nume where id_scoala=@id_scoala;", connection);
                        command.Parameters.AddWithValue("@id_oras", dataGridView1[1, rowIndex].Value.ToString());
                        command.Parameters.AddWithValue("@nume", dataGridView1[2, rowIndex].Value.ToString());
                        command.Parameters.AddWithValue("@id_scoala", dataGridView1[0, rowIndex].Value.ToString());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Modificarile sunt salvate");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mesajul erorii este: {0}", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nu este selectata o inregistrare");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                try
                {
                    string connectionString;
                    connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        Console.WriteLine("Starea conexiunii: {0}", connection.State);
                        connection.Open();
                        Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.DeleteCommand = new SqlCommand("Delete Scoli where id_scoala = " + dataGridView1[0, rowIndex].Value.ToString() + ";", connection);
                        adapter.DeleteCommand.ExecuteNonQuery();
                        foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                        {
                            dataGridView1.Rows.RemoveAt(item.Index);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mesajul erorii este: {0}", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nu este selectata o inregistrare");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1 && 
                textBox1.Text != "" && 
                textBox3.Text != "")
            {
                try
                {
                    string connectionString;
                    connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int rowIndex = dataGridView2.CurrentCell.RowIndex;
                        Console.WriteLine("Starea conexiunii: {0}", connection.State);
                        connection.Open();
                        Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO Scoli (id_scoala, id_oras, nume) " +
                        "VALUES (@id_scoala, @id_oras, @nume);", connection);
                        insertCommand.Parameters.AddWithValue("@id_scoala", textBox1.Text);
                        insertCommand.Parameters.AddWithValue("@id_oras", dataGridView2[0,rowIndex].Value.ToString());
                        insertCommand.Parameters.AddWithValue("@nume", textBox3.Text);
                        insertCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mesajul erorii este: {0}", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nu este selectata o inregistrare sau exista campuri nule");
            }
        }
    }
}
