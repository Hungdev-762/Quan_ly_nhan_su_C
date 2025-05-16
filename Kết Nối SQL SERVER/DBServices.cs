using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kết_Nối_SQL_SERVER
{
    internal class DBServices
    {
        private string connSring = @"Data Source=DESKTOP-T94QU8R\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True";
        private SqlConnection myConn;

        public DBServices()
        {
            myConn = new SqlConnection(connSring);
        }

        public DataTable getData(string sql)
        {
            try
            {
                SqlDataAdapter mydata = new SqlDataAdapter(sql, myConn);
                DataTable dtable = new DataTable();
                mydata.Fill(dtable);
                return dtable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void runQuery (string sql) 
        {
            try
            {
                myConn.Open();
                SqlCommand myComm = new SqlCommand(sql, myConn);
                myComm.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
