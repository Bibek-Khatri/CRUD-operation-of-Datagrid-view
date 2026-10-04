using System.Data;
using System.Data.OleDb;

namespace Datagrid
{
    public partial class Form1 : Form
    {
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
            OleDbDataAdapter oleDbDataAdpter = new OleDbDataAdapter(oleDbCommand);


        }
    }
}
