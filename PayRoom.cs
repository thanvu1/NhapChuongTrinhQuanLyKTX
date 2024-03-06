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
    public partial class PayRoom : Form
    {
        function fn = new function();
        string query;
        public PayRoom()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PayRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 125);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MMMM yyyy";
        }
        private void ClearAll()
        {
            txtPhoneNumber.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtRoomNo.Clear();
            txtPayFees.Clear();
            dataGridView1.DataSource = 0;
        }
        public void setDataGrid(Int64 mobile)/* lấy dữ liệu cho datagridview*/
        {
            query = "SELECT * FROM fees WHERE mobileNo =" + mobile + "";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtPhoneNumber.Text != "")
            {
                //truy vấn tìm thông tin phòng qua sđt của sinh viên
                query = "SELECT name, email, roomNo from newStudent WHERE mobile =" + txtPhoneNumber.Text + "";
                DataSet ds = fn.GetData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtRoomNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    setDataGrid(Int64.Parse(txtPhoneNumber.Text));
                }
                else
                {
                    MessageBox.Show("Dữ liệu này không tồn tại!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //với điều kiện sđt và số tiền đã trả không rỗng
            if(txtPhoneNumber.Text != "" && txtPayFees.Text != "")
            {
                //truy vấn từ bảng fees bằng sđt và tháng trả tiền điện
                query = "SELECT * FROM fees WHERE mobileNo = " + Int64.Parse(txtPhoneNumber.Text) + " and fmonth='" + dateTimePicker.Text + "'";
                DataSet ds = fn.GetData(query);//Lấy dữ liệu từ database

                if (ds.Tables[0].Rows.Count == 0)
                {
                    //chuyển dữ liệu được nhập vào textbox
                    Int64 mobile = Int64.Parse(txtPhoneNumber.Text);
                    string month = dateTimePicker.Text;
                    Int64 fees = Int64.Parse(txtPayFees.Text);

                    query = "insert into fees values (" + mobile + ", '" + month + "', " + fees + ")";
                    fn.setData(query, "Phí đã được trả!");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Không có chi phí của tháng " + dateTimePicker.Text + " Còn lại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
