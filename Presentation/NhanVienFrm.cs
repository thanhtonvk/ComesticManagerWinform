using QuanLyMyPham.BLL;
using QuanLyMyPham.BLL.InterfaceService;
using QuanLyMyPham.DAL;
using QuanLyMyPham.Models;
using QuanLyMyPham.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMyPham.Presentation
{
    public partial class NhanVienFrm : Form
    {
        public NhanVienFrm()
        {
            InitializeComponent();
        }
        ISanPhamBLL sanPhamBLL = new SanPhamBLL();
        ILoaiSanPhamBLL loaiSanPhamBLL = new LoaiSanPhamBLL();
        IHoaDonNhapBLL hoaDonNhapBLL = new HoaDonNhapBLL();
        IHoaDonBanBLL hoaDonBanBLL = new HoaDonBanBLL();
        IDaiLyBLL daiLyBLL = new DaiLyBLL();
        DBContext db = new DBContext();
        string maloai = "-1";
        private void NhanVienFrm_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadLoaiSP();
            loadDaiLy();
            loadHoaDonNhap();
            loadHoaDonBan();
            thongKe();
        }
        private void loadSanPham()
        {
            dataGridView1.DataSource = sanPhamBLL.GetAll("");
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comboBox1.DataSource = loaiSanPhamBLL.GetAll("");
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tensp = textBox2.Text;
            DateTime ngaysx = dateTimePicker1.Value;
            DateTime hansd = dateTimePicker2.Value;
            int solo = int.Parse(textBox5.Text.Trim());
            int dongia = int.Parse(textBox6.Text);
            SanPham sanPham = new SanPham()
            {
                TenSP = tensp,
                NgaySX = ngaysx,
                HanSD = hansd,
                SoLo = solo,
                DonGia = dongia,
                MaLoai = int.Parse(maloai.Trim())
            };
            string rs = sanPhamBLL.Add(sanPham);
            MessageBox.Show(rs);

            dataGridView1.DataSource = sanPhamBLL.GetAll("");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string masp = label2.Text.Trim();
            string tensp = textBox2.Text;
            DateTime ngaysx = dateTimePicker1.Value;
            DateTime hansd = dateTimePicker2.Value;
            int solo = int.Parse(textBox5.Text.Trim());
            int dongia = int.Parse(textBox6.Text);
            SanPham sanPham = new SanPham()
            {
                MaSP = int.Parse(masp),
                TenSP = tensp,
                NgaySX = ngaysx,
                HanSD = hansd,
                SoLo = solo,
                DonGia = dongia,
                MaLoai = int.Parse(maloai.Trim())
            };
            string rs = sanPhamBLL.Update(sanPham);
            MessageBox.Show(rs);

            dataGridView1.DataSource = sanPhamBLL.GetAll("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string masp = label2.Text.Trim();
            string rs = sanPhamBLL.Delete(int.Parse(masp));


            dataGridView1.DataSource = sanPhamBLL.GetAll("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sanPhamBLL.GetAll(textBox7.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                label2.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                comboBox1.SelectedIndex = int.Parse(row.Cells[2].Value.ToString()) - 1;

                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                dateTimePicker2.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
            }
        }
        //loại sản phẩm
        private void loadLoaiSP()
        {
            dataGridView2.DataSource = loaiSanPhamBLL.GetAll("");
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoaiSanPham loaiSanPham = new LoaiSanPham()
            {
                TenLoai = textBox4.Text
            };
            string rs = loaiSanPhamBLL.Add(loaiSanPham);
            MessageBox.Show(rs);
            dataGridView2.DataSource = loaiSanPhamBLL.GetAll("");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoaiSanPham loaiSanPham = new LoaiSanPham()
            {
                MaLoai = int.Parse(label12.Text),
                TenLoai = textBox4.Text
            };
            string rs = loaiSanPhamBLL.Update(loaiSanPham);
            MessageBox.Show(rs);
            dataGridView2.DataSource = loaiSanPhamBLL.GetAll("");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int maloai = int.Parse(label12.Text);
            string rs = loaiSanPhamBLL.Delete(maloai);

            dataGridView2.DataSource = loaiSanPhamBLL.GetAll("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = loaiSanPhamBLL.GetAll(textBox1.Text);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                label12.Text = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[1].Value.ToString();

            }
        }
        //đại lý
        private void loadDaiLy()
        {

            dataGridView3.DataSource = daiLyBLL.GetAll("");
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DaiLy daiLy = new DaiLy()
            {
                TenDL = textBox3.Text,
                SDT = textBox9.Text,
                DiaChi = textBox10.Text
            };
            string rs = daiLyBLL.Add(daiLy);
            MessageBox.Show(rs);
            dataGridView3.DataSource = daiLyBLL.GetAll("");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DaiLy daiLy = new DaiLy()
            {
                MaDL = int.Parse(label13.Text),
                TenDL = textBox3.Text,
                SDT = textBox9.Text,
                DiaChi = textBox10.Text
            };
            string rs = daiLyBLL.Update(daiLy);
            MessageBox.Show(rs);
            dataGridView3.DataSource = daiLyBLL.GetAll("");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int MaDL = int.Parse(label13.Text);
            daiLyBLL.Delete(MaDL);
            dataGridView3.DataSource = daiLyBLL.GetAll("");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = daiLyBLL.GetAll(textBox8.Text);

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                label13.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox9.Text = row.Cells[2].Value.ToString();
                textBox10.Text = row.Cells[3].Value.ToString();

            }
        }
        string madaily = "-1";
        private void loadHoaDonNhap()
        {
            dataGridView4.DataSource = hoaDonNhapBLL.GetAll("");
            dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comboBox2.DataSource = daiLyBLL.GetAll("");
            comboBox2.DisplayMember = "TenDL";
            comboBox2.ValueMember = "MaDL";
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
           

        }

        private void button16_Click(object sender, EventArgs e)
        {
            HoaDonNhap hoaDonNhap = new HoaDonNhap()
            {
                MaDL = int.Parse(madaily),
                NgayNhap = dateTimePicker4.Value
            };
            string rs = hoaDonNhapBLL.Add(hoaDonNhap);
            MessageBox.Show(rs);
            loadHoaDonNhap();
            int lastIndex = db.HoaDonNhaps.ToList().Count-1;
            Common.MaHDN = db.HoaDonNhaps.ToArray()[lastIndex].MaHD;
            ChiTietHDNFrm frm = new ChiTietHDNFrm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.SelectedRows)
            {
                Common.MaHDN = int.Parse(row.Cells[0].Value.ToString());
               
            }
            ChiTietHDNFrm frm = new ChiTietHDNFrm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.SelectedRows)
            {
                label18.Text = row.Cells[0].Value.ToString();
                dateTimePicker4.Text = row.Cells[1].Value.ToString();
                comboBox2.Text= row.Cells[2].Value.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = hoaDonNhapBLL.GetAll(textBox11.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            HoaDonNhap hoaDonNhap = new HoaDonNhap()
            {
                MaHD= int.Parse(label18.Text),
                MaDL = int.Parse(madaily),
                NgayNhap = dateTimePicker4.Value
            };
            string rs = hoaDonNhapBLL.Update(hoaDonNhap);
            MessageBox.Show(rs);
            dataGridView4.DataSource = hoaDonNhapBLL.GetAll("");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hoaDonNhapBLL.Delete(int.Parse(label18.Text));
            dataGridView4.DataSource = hoaDonNhapBLL.GetAll("");
        }
        INhanVienBLL nhanVienBLL = new NhanVienBLL();
        //hóa đơn bán
        string manv = "-1";
        private void loadHoaDonBan()
        {
            dataGridView5.DataSource = hoaDonBanBLL.GetAll("");
            dataGridView5.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comboBox3.DataSource = nhanVienBLL.GetAll("");
            comboBox3.DisplayMember = "TenNV";
            comboBox3.ValueMember = "MaNV";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            HoaDonBan hoaDonBan = new HoaDonBan()
            {
                NgayBan = dateTimePicker3.Value,
                TenKhach = textBox13.Text,
                SDT = textBox14.Text,
                DiaChi = textBox15.Text,
                MaNV = int.Parse(manv)
            };
            string rs = hoaDonBanBLL.Add(hoaDonBan);
            MessageBox.Show(rs);
            dataGridView5.DataSource = hoaDonBanBLL.GetAll("");
            int lastIndex = db.HoaDonBans.ToList().Count - 1;
            Common.MaHDB = db.HoaDonBans.ToList()[lastIndex].MaHD;
            ChiTietHDBFrm frm = new ChiTietHDBFrm();
            this.Hide();
            frm.ShowDialog();
            this.Show();

        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
         
        }

        private void button19_Click(object sender, EventArgs e)
        {
            HoaDonBan hoaDonBan = new HoaDonBan()
            {
                MaHD =int.Parse(label27.Text),
                NgayBan = dateTimePicker3.Value,
                TenKhach = textBox13.Text,
                SDT = textBox14.Text,
                DiaChi = textBox15.Text,
                MaNV = int.Parse(manv)
            };
            string rs = hoaDonBanBLL.Update(hoaDonBan);
            MessageBox.Show(rs);
            dataGridView5.DataSource = hoaDonBanBLL.GetAll("");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int MaHD = int.Parse(label27.Text);
            hoaDonBanBLL.Delete(MaHD);
            dataGridView5.DataSource = hoaDonBanBLL.GetAll("");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = hoaDonBanBLL.GetAll(textBox12.Text);
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.SelectedRows)
            {
                label27.Text = row.Cells[0].Value.ToString();
                dateTimePicker3.Text = row.Cells[1].Value.ToString();
                textBox13.Text = row.Cells[2].Value.ToString();
                textBox14.Text = row.Cells[3].Value.ToString();
                textBox15.Text = row.Cells[4].Value.ToString();
                comboBox3.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.SelectedRows)
            {
                Common.MaHDB = int.Parse(row.Cells[0].Value.ToString());
               
            }
            ChiTietHDBFrm frm = new ChiTietHDBFrm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
        ThongKeDAL thongKeDAL = new ThongKeDAL();
        private void thongKe()
        {
            dg_banchay.DataSource = thongKeDAL.sanPhamBanChays();
            dg_theongay.DataSource = thongKeDAL.thongKeTheoNgay();
            dg_banchay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dg_theongay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg_banchay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dg_theongay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
