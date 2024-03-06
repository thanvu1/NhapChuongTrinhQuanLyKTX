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
    public partial class AddNewRoom : Form
    {
        function fn = new function();
        String query;
        public AddNewRoom()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(470, 125);
            lblRoomExist.Visible = false;
            lblRoom.Visible = false;

            query = "SELECT * FROM rooms";//truy vấn phòng
            DataSet ds = fn.GetData(query);//lấy dữ liệu phòng từ bảng rooms
            dataGridView1.DataSource = ds.Tables[0];//cập nhật datagridview
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            //truy vấn phòng qua phòng số để thêm phòng
            query = "SELECT * FROM rooms WHERE roomNo=" + txtRoomNo1.Text + "";
            DataSet ds = fn.GetData(query);//cập nhật dữ liệu database

            if (ds.Tables[0].Rows.Count == 0)//nếu số dòng trong hàng = 0 thì thêm phòng
            {
                String status;
                if(checkBox1.Checked)
                {
                    status = "Yes";
                }
                else
                {
                    status = "No";
                }
                lblRoomExist.Visible = false;
                //truy vấn thêm phòng qua dữ liệu đã được nhập ở textbox
                query = "insert into rooms (roomNo, roomStatus) values (" + txtRoomNo1.Text + ",'" + status + "')";
                fn.setData(query, "Đã thêm phòng");//cập nhật dữ liệu và thông báo
                AddNewRoom_Load(this, null);//cập nhật datagridview
            }
            else
            {
                lblRoomExist.Text = "Phòng đã có";
                lblRoomExist.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //truy vấn qua phòng số ở bảng room
            query = "SELECT * FROM rooms WHERE roomNo=" + txtRoomNo2.Text + "";
            DataSet ds = fn.GetData(query);//lấy dữ liệu từ câu truy vấn

            if (ds.Tables[0].Rows.Count == 0)
            {
                lblRoom.Text = "Phòng này không tồn tại";
                lblRoom.Visible = true;
                checkBox2.Checked = false;
            }
            else
            {
                lblRoom.Text = "Phòng này đã tìm thấy";
                lblRoom.Visible = true;

                if (ds.Tables[0].Rows[0][1].ToString() == "Yes")//kiểm tra roomStatus = 'Yes'
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Visible = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String status;
            if(checkBox2.Checked)//nếu cb được nhấn thì phòng vẫn còn có thể cho ở
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }
            //truy vấn để cập nhật bảng rooms nhập status của roomNo
            query = "update rooms set roomStatus='" + status + "' where roomNo = " + txtRoomNo2.Text + "";
            fn.setData(query, "Cập nhật chi tiết thành công!");//cập nhật dữ liệu và thông báo cập nhật thành công
            AddNewRoom_Load(this, null);//cập nhật datagridview
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lblRoom.Text == "Phòng này đã tìm thấy")
            {
                query = "delete from rooms where roomNo=" + txtRoomNo2.Text + "";
                fn.setData(query, "Đã xóa phòng");
                AddNewRoom_Load(this, null);
            }
            else
            {
                MessageBox.Show("Không thấy phòng cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
