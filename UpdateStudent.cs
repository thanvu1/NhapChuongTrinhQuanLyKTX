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
    public partial class UpdateStudent : Form
    {
        function fn = new function();
        string query;
        public UpdateStudent()
        {
            InitializeComponent();
        }

        public void ClearAll() /*reset lại*/
        {
            txtPhoneNumber.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtHome.Clear();
            txtUni.Clear();
            txtIDproof.Clear();
            txtRoomNo.Clear();
            comboLiving.SelectedIndex = -1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 125);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //truy vấn ở sql để tìm sđt tương ứng
            query = "SELECT * FROM newStudent WHERE mobile =" + txtPhoneNumber.Text + "";
            //lấy dữ liệu qua sđt
            DataSet ds = fn.GetData(query);

            //gán giá trị database cho textbox
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtHome.Text = ds.Tables[0].Rows[0][6].ToString();
                txtUni.Text = ds.Tables[0].Rows[0][7].ToString();
                txtIDproof.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoomNo.Text = ds.Tables[0].Rows[0][9].ToString();
                comboLiving.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            else
            {
                ClearAll();
                MessageBox.Show("Số điện thoại này không tồn tại", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Nhập giá trị cho text box để thay đổi
            Int64 PN = Int64.Parse(txtPhoneNumber.Text);
            string Name = txtName.Text;
            string FName = txtFather.Text;
            string MName = txtMother.Text;
            string Email = txtEmail.Text;
            string Home = txtHome.Text;
            string Uni = txtUni.Text;
            string IDproof = txtIDproof.Text;
            Int64 roomNo = Int64.Parse(txtRoomNo.Text);
            string LivingStatus = comboLiving.Text;

            //cài đặt câu truy vấn cập nhật dữ liệu thay đổi thông tin sinh viên
            query = "update newStudent set name= '" + Name + "', fname= '" + FName + "', mname= '" + MName + "', email= '" + Email + "', paddress= '" + Home + "', college= '" + Uni + "', idproof= '" + IDproof + "', roomNo= " + roomNo + ", living= '" + LivingStatus + "' where mobile = " + PN + "update rooms set Booked = '" + LivingStatus + "' where roomNo = " + roomNo + "";
            fn.setData(query, "Cập nhật dữ liệu thành công");/*cập nhật dữ liệu*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //Truy vấn sql xóa dữ liệu sinh viên
                query = "delete from newStudent where mobile= " + txtPhoneNumber.Text + "";
                fn.setData(query, "Đã xóa thông tin sinh viên!");/*truyền câu truy vấn vào hàm để xóa dữ liệu*/
            }
        }
    }
}
