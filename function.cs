using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace NhapChuongTrinhQuanLyKTX
{
    class function
    {
        protected SqlConnection GetSqlConnection() /*kết nối với database*/
        {
            //tạo một database mới cho sql
            SqlConnection con = new SqlConnection();
            //Kết nối với database 'domitory' trong SSMS
            con.ConnectionString = "Data Source=HOANG_THAN_VU;database=dormitory;integrated security=True";
            return con;
        }
        public DataSet GetData(String query)
        {
            //lấy dữ liệu trong database
            SqlConnection con = GetSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;//dùng query để truy vấn các câu lệnh sql
            SqlDataAdapter adp = new SqlDataAdapter(cmd);//khai báo và khởi tạo đối tượng liên kết nó với một đối tượng SqlCommand. SqlDataAdapter này sau đó có thể được sử dụng để điều chỉnh dữ liệu giữa DataSet và cơ sở dữ liệu thông qua các phương thức như Fill, Update, và Select. 
            DataSet ds = new DataSet();//khai báo và khởi tạo đối tượng của lớp dataset(giúp lưu trữ và quản lý dữ liệu trong bộ nhớ tạm thời và có thể được sử dụng để làm việc với dữ liệu từ nhiều nguồn khác nhau.)
            adp.Fill(ds);//cập nhật dữ liệu sql
            return ds;
        }
        public void setData(String query, string msg)
        {

            SqlConnection con = GetSqlConnection();/*tạo kết nối database với visual*/
            SqlCommand cmd = new SqlCommand();/*tạo lệnh*/
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
