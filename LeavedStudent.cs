using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhapChuongTrinhQuanLyKTX
{
    public partial class LeavedStudent : Form
    {
        function fn = new function();
        string query;
        public LeavedStudent()
        {
            InitializeComponent();
        }

        private void LeavedStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 125);
            //truy vấn dữ liệu các phòng không còn người ở
            query = "SELECT * FROM newStudent WHERE living = 'No'";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
