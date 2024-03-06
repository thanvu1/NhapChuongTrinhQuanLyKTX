using System;
using System.Collections;
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
    public partial class StudentStatus : Form
    {
        function fn = new function();
        string query;
        public StudentStatus()
        {
            InitializeComponent();
        }

        private void StudentStatus_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 125);
            query = "SELECT * FROM newStudent where living = 'Yes'";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
