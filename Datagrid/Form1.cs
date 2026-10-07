using System.Data;
using System.Data.OleDb;

namespace Datagrid
{
    public partial class Form1 : Form
    {
        private OleDbDataAdapter oleDbDataAdapter;


        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string connectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Acer Nitro v16\Downloads\BookCSharp.accdb";

            using (OleDbConnection oleDbConnection = new OleDbConnection(connectionString))
            {
                string query = "SELECT BookKey, Title, Pages, Publisher FROM Books";
                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
                DataTable resultTable = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(oleDbCommand);
                adapter.Fill(resultTable);

                dataGridView1.DataSource = resultTable;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionSting = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Acer Nitro v16\Downloads\BookCSharp.accdb";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionSting);
            string query = "Select BookKey, Title,Pages,Publisher from Books";
            OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
            DataTable resultTable = new DataTable();
            oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
            oleDbDataAdapter.Fill(resultTable);
            dataGridView1.DataSource = resultTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Create_Click(object sender, EventArgs e)
        {
            string connectionSting = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Acer Nitro v16\Downloads\BookCSharp.accdb";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionSting);
            string query = "Insert into books( BookKey, Title,Pages,Publisher)values (?,?,?)";
            OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);
            oleDbCommand.Parameters.AddWithValue("@BookKey", int.Parse(textBox1.Text));
            oleDbCommand.Parameters.AddWithValue("@Title", textBox2.Text);
            oleDbCommand.Parameters.AddWithValue("@Pages", int.Parse(textBox3.Text));
            oleDbCommand.Parameters.AddWithValue("@Publisher", textBox4.Text);
            oleDbConnection.Open();
            oleDbCommand.ExecuteNonQuery();
            LoadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString =
             @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Acer Nitro v16\Downloads\BookCSharp.accdb";

            using (OleDbConnection oleDbConnection = new OleDbConnection(connectionString))
            {
                string query = "UPDATE Books SET Title=?, Pages=?, Publisher=? WHERE BookKey=?";
                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);

                // Parameters must match the order of ? placeholders
                oleDbCommand.Parameters.AddWithValue("Title", textBox2.Text);
                oleDbCommand.Parameters.AddWithValue("Pages", textBox3.Text);
                oleDbCommand.Parameters.AddWithValue("Publisher", textBox4.Text);
                oleDbCommand.Parameters.AddWithValue("BookKey", textBox1.Text);

                oleDbConnection.Open();
                int rowsAffected = oleDbCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No book found with that BookKey.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadData(); 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["BookKey"].Value?.ToString();
                textBox2.Text = row.Cells["Title"].Value?.ToString();
                textBox3.Text = row.Cells["Pages"].Value?.ToString();
                textBox4.Text = row.Cells["Publisher"].Value?.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Acer Nitro v16\Downloads\BookCSharp.accdb";

            using (OleDbConnection oleDbConnection = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM Books WHERE BookKey = @BookKey";
                OleDbCommand oleDbCommand = new OleDbCommand(query, oleDbConnection);


                oleDbCommand.Parameters.AddWithValue("@BookKey", textBox1.Text);

                oleDbConnection.Open();
                int rowsAffected = oleDbCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No book found with that BookKey.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadData();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }

}