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
using System.Configuration;

namespace lab3tema
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        SqlDataAdapter adapterParent = new SqlDataAdapter();
        SqlDataAdapter adapterChild = new SqlDataAdapter();
        BindingSource bindingSourceParent = new BindingSource();
        BindingSource bindingSourceChild = new BindingSource();
        string connectionString;
        public Form1()
        {
            InitializeComponent();
            ds.Tables.Add(ConfigurationManager.AppSettings["parentTable"]);
            ds.Tables.Add(ConfigurationManager.AppSettings["childTable"]);
            labelParent.Text = ConfigurationManager.AppSettings["parentTable"];
            labelChild.Text = ConfigurationManager.AppSettings["childTable"];
            connectionString = ConfigurationManager.AppSettings["connectionString"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapterParent.SelectCommand = new SqlCommand("SELECT * FROM " + ConfigurationManager.AppSettings["parentTable"], connection);
                    adapterParent.Fill(ds, ConfigurationManager.AppSettings["parentTable"]);
                    dataGridViewParent.DataSource = ds.Tables[ConfigurationManager.AppSettings["parentTable"]];

                    adapterChild.SelectCommand = new SqlCommand("SELECT * FROM " + ConfigurationManager.AppSettings["childTable"], connection);
                    adapterChild.Fill(ds, ConfigurationManager.AppSettings["childTable"]);

                    DataColumn pk = ds.Tables[ConfigurationManager.AppSettings["parentTable"]].Columns[ConfigurationManager.AppSettings["pkColumn"]];
                    DataColumn fk = ds.Tables[ConfigurationManager.AppSettings["childTable"]].Columns[ConfigurationManager.AppSettings["fkColumn"]];
                    DataRelation relation = new DataRelation(ConfigurationManager.AppSettings["fkConstraint"], pk, fk, true);
                    ds.Relations.Add(relation);

                    bindingSourceParent.DataSource = ds.Tables[ConfigurationManager.AppSettings["parentTable"]];
                    dataGridViewParent.DataSource = bindingSourceParent;

                    bindingSourceChild.DataSource = bindingSourceParent;
                    bindingSourceChild.DataMember = ConfigurationManager.AppSettings["fkConstraint"];
                    dataGridViewChild.DataSource = bindingSourceChild;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    dataGridViewParent.DataSource = ds.Tables["Orase"];
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

       /*
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string connectionString;
                connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    int rowIndex = dataGridViewParent.CurrentCell.RowIndex;
                    Console.WriteLine("Starea conexiunii: {0}", connection.State);
                    connection.Open();
                    Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("SELECT * from " + ConfigurationManager.AppSettings["childTable"] + " where " + ConfigurationManager.AppSettings["fkcolumn"] + " = " + dataGridViewParent[0, rowIndex].Value.ToString() + ";", connection);
                    Console.WriteLine(adapter.SelectCommand.CommandText);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Scoli");
                    dataGridViewChild.DataSource = ds.Tables["Scoli"];
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mesajul erorii este: {0}", ex.Message);
            }
        }*/

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
                    dataGridViewChild.DataSource = ds.Tables["Scoli"];
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
            if (dataGridViewChild.SelectedRows.Count == 1)
            {
                try
                {
                    string connectionString;
                    connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int rowIndex = dataGridViewChild.CurrentCell.RowIndex;
                        Console.WriteLine("Starea conexiunii: {0}", connection.State);
                        connection.Open();
                        Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);
                        SqlDataAdapter adapter = new SqlDataAdapter();

                        SqlCommand command = new SqlCommand("Update Scoli set id_oras=@id_oras, nume=@nume where id_scoala=@id_scoala;", connection);
                        command.Parameters.AddWithValue("@id_oras", dataGridViewChild[1, rowIndex].Value.ToString());
                        command.Parameters.AddWithValue("@nume", dataGridViewChild[2, rowIndex].Value.ToString());
                        command.Parameters.AddWithValue("@id_scoala", dataGridViewChild[0, rowIndex].Value.ToString());
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
            if (dataGridViewChild.SelectedRows.Count == 1)
            {
                try
                {
                    string connectionString;
                    connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int rowIndex = dataGridViewChild.CurrentCell.RowIndex;
                        Console.WriteLine("Starea conexiunii: {0}", connection.State);
                        connection.Open();
                        Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.DeleteCommand = new SqlCommand("Delete Scoli where id_scoala = " + dataGridViewChild[0, rowIndex].Value.ToString() + ";", connection);
                        adapter.DeleteCommand.ExecuteNonQuery();
                        foreach (DataGridViewRow item in this.dataGridViewChild.SelectedRows)
                        {
                            dataGridViewChild.Rows.RemoveAt(item.Index);
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
            if (dataGridViewParent.SelectedRows.Count == 1 && 
                textBox1.Text != "" && 
                textBox3.Text != "")
            {
                try
                {
                    string connectionString;
                    connectionString = @"Server=DESKTOP-H9AHHS4\SQLEXPRESS;Database=catalog_virtual;Integrated Security=true;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int rowIndex = dataGridViewParent.CurrentCell.RowIndex;
                        Console.WriteLine("Starea conexiunii: {0}", connection.State);
                        connection.Open();
                        Console.WriteLine("Starea conexiunii dupa apelul metodei Open(): {0}", connection.State);

                        SqlCommand insertCommand = new SqlCommand("INSERT INTO Scoli (id_scoala, id_oras, nume) " +
                        "VALUES (@id_scoala, @id_oras, @nume);", connection);
                        insertCommand.Parameters.AddWithValue("@id_scoala", textBox1.Text);
                        insertCommand.Parameters.AddWithValue("@id_oras", dataGridViewParent[0,rowIndex].Value.ToString());
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    adapterParent.SelectCommand.Connection = connection;
                    adapterChild.SelectCommand.Connection = connection;

                    SqlCommandBuilder commandBuilderClienti = new SqlCommandBuilder(adapterParent);
                    commandBuilderClienti.GetUpdateCommand();
                    adapterParent.Update(ds, ConfigurationManager.AppSettings["parentTable"]);

                    SqlCommandBuilder commandBuilderTelefoane = new SqlCommandBuilder(adapterChild);
                    commandBuilderTelefoane.GetUpdateCommand();
                    adapterChild.Update(ds, ConfigurationManager.AppSettings["childTable"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
