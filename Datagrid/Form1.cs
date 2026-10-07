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


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ignore header row
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["BookKey"].Value?.ToString();
                textBox2.Text = row.Cells["Title"].Value?.ToString();
                textBox3.Text = row.Cells["Pages"].Value?.ToString();
                textBox4.Text = row.Cells["Publisher"].Value?.ToString();
            }
        }
    }
}
