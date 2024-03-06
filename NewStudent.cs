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
    public partial class NewStudent : Form
    {
        function fn = new function();
        string query;
        public NewStudent()
        {
            InitializeComponent();
        }
        private void clearAll()
        {
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtHome.Clear();
            txtCollege.Clear();
            txtIDProof.Clear();
            comboRoomNo.SelectedIndex = -1;
        }
        private void NewStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 125);
            //chọn phòng với điều kiện ở câu truy vấn
            query = "SELECT roomNo from rooms WHERE roomStatus = 'Yes' AND Booked = 'No'";

            //Lấy thông tin từ query
            DataSet ds = fn.GetData(query);
            //Lấy phần tử đã lọc
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //chuyển sang dạng Int64
                Int64 room = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                //thêm dữ liệu phòng đã lọc vào nút comboRoomNo
                comboRoomNo.Items.Add(room);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //phải điền đầy đủ
            if (txtName.Text != "" && txtPhoneNumber.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmail.Text != "" && txtCollege.Text != "" && txtHome.Text != "" && txtIDProof.Text != "" && comboRoomNo.SelectedIndex != -1)
            {
                //chuyển đổi kiểu dữ liệu được nhập vào
                Int64 PN = Int64.Parse(txtPhoneNumber.Text);
                String Name = txtName.Text;
                String FName = txtFather.Text;
                String MName = txtMother.Text;
                String Email = txtEmail.Text;
                String Addr = txtHome.Text;
                String Uni = txtCollege.Text;
                String ID = txtIDProof.Text;
                Int64 roomNo = Int64.Parse(comboRoomNo.Text);

                //thêm dữ liệu được nhập vào database và đặt trạng thái phòng đã thuê
                query = "insert into newStudent(mobile, name, fname, mname, email, paddress, college, idproof, roomNo) values (" + PN + ", '" + Name + "', '" + FName + "', '" + MName + "', '" + Email + "', '" + Addr + "', '" + Uni + "', '" + ID + "', " + roomNo + ") update rooms set Booked = 'Yes' where roomNo = " + roomNo + "";
                fn.setData(query, "Sinh viên đã đăng ký thành công");
                //khi đăng ký thành công thì reset lại
                clearAll();
            }
            else
            {
                MessageBox.Show("Sinh viên phải điền đầy đủ thông tin!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
