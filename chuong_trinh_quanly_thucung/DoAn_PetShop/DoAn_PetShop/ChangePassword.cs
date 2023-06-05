using DoAn_PetShop.CSDL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PetShop
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btndmk_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("vui lòng điền đầy đủ thông tin");
            }
            else
            {
                DbConnect dbcon = new DbConnect();
                OracleConnection con = dbcon.connectionSYS();
                if (con != null)
                {
                    try
                    {
                        OracleCommand cmd = new OracleCommand("alter user " + txtUser.Text + " identified by " + txtPassword.Text + "", con);
                        try
                        {
                            con.Open();
                        }
                        catch
                        {
                            con.Close();
                            MessageBox.Show("đổi mật khẩu thất bại \ncần đăng nhập vào chương trình \nbằng sys sau đó quay lại đổi mật khẩu user mong muốn");
                            return;
                        }
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("đổi mật khẩu thành công");
                            con.Close();
                            this.Close();
                    }
                    catch
                    {
                        con.Close();
                        MessageBox.Show("không được đổi mật khẩu đã được sử dụng");
                    }
                }
                else
                {
                    MessageBox.Show("vì lý do bắt buộc cần\nđăng nhập chương trình bằng user sys sau đó\nquay lại đổi mật khẩu user mong muốn");
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.TextLength > 2)
            {
                btndmk.Enabled = true;
            }
            else
            {
                btndmk.Enabled = false;
            }
        }
    }
}
