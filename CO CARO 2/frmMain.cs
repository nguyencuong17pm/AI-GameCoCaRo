using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CO_CARO_2
{
    
    public partial class fmCoCaro : Form
    {
        public static int ChieuRongBanCo;
        public static int ChieuCaoBanCo;
        private Graphics grp;
        private C_DieuKhien DieuKhien;
        

        public fmCoCaro()
        {
            InitializeComponent();
            //vẽ nên pnlBanCo
            grp = pnlBanCo.CreateGraphics();
            
            //lấy chiều rộng và chiều cao pnBanCo để vẽ bàn cờ
            ChieuCaoBanCo = pnlBanCo.Height;
            ChieuRongBanCo = pnlBanCo.Width;

            //khởi tạo đối tượng điều khiển trò chơi
            DieuKhien = new C_DieuKhien();
        }

        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            if (DieuKhien.SanSang)
            {
                //vẽ bàn cờ
                DieuKhien.veBanCo(grp);
                //vẽ lại các quân cờ trong stack
                DieuKhien.veLaiQuanCo(grp);
            }
        }

        private void chơiVớiNgườiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiNguoi(grp);

            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (DieuKhien.SanSang)
            {
                //chơi với người
                if (DieuKhien.CheDoChoi == 1)
                {
                    //đánh cờ với tọa độ chuột khi lick vào panel bàn cờ
                    DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                    //sau khi đánh cờ thì kiểm tra chiến thắng luôn
                    DieuKhien.kiemTraChienThang(grp);
                }
                //chơi với máy
                else
                {
                    //người chơi đánh
                    DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                    //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                    if (!DieuKhien.kiemTraChienThang(grp))
                    {
                        //máy đánh
                        DieuKhien.mayDanh(grp);
                        DieuKhien.kiemTraChienThang(grp);
                    }
                }
            }
        }

        private void chơiVớiMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiMay(grp);

            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void luậtChơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmLuatChoi f2 = new fmLuatChoi();
            f2.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTin TT = new frmThongTin();
            TT.ShowDialog();
           // MessageBox.Show("Game Cờ caro, phiên bản sinh viên DH17PM (nhóm 1-AGU)","thôngtin",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
           // DialogResult thongbao;
           // thongbao = (MessageBox.Show("Bạn có muốn thoát game không?", "Chú ý",
             //   MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            //if (thongbao == DialogResult.Yes)
               // Application.Exit();
           DialogResult thongbao =  (MessageBox.Show("Bạn có muốn thoát không ? ", "Chú ý", MessageBoxButtons.YesNo,MessageBoxIcon.Information));
            if( thongbao == DialogResult.Yes)
                  this.Close();
        }

        private void btnChoiVoiNguoi_Click(object sender, EventArgs e)
        {
            chơiVớiNgườiToolStripMenuItem_Click(sender, e);
        }

        private void btnChoiVoiMay_Click(object sender, EventArgs e)
        {
            chơiVớiMáyToolStripMenuItem_Click(sender, e);
        }

        private void btnLuatChoi_Click(object sender, EventArgs e)
        {
            luậtChơiToolStripMenuItem_Click(sender, e);
        }

        private void btnThongTinPhanMem_Click(object sender, EventArgs e)
        {
            thôngTinToolStripMenuItem_Click(sender, e);
        }

    }
}
