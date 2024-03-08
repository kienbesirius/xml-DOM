using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Bai01_Phieu_Xuat_Kho
{
    public partial class Form1 : Form
    {

        String dataPath = @"C:\\Users\\bechj\\OneDrive\\second_semester_dec_2023_2024\\XML_LEARN\\visual_microsoft_code\\repos\\Bai01_Phieu_Xuat_Kho\\PhieuXuatKho.xml";
        public Form1()
        {
            InitializeComponent();
            Bai01(PhieuXuatKhoGridView);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Bai01DataGridViewSetUp(DataGridView gridView)
        {
            clearDataGridView(gridView);
            gridView.Visible = true;
            gridView.Columns.Add("STT", "STT");
            gridView.Columns.Add("TenHang", "Ten Hang");
            gridView.Columns.Add("MaSo", "Ma So");
            gridView.Columns.Add("DonViTinh", "Don Vi Tinh");
            gridView.Columns.Add("YeuCau", "Yeu Cau");
            gridView.Columns.Add("ThucXuat", "Thuc Xuat");
            gridView.Columns.Add("ThanhTien", "Thanh Tien");
            gridView.Columns.Add("DonGia", "Don Gia");

            // Set the width of the ID column to 100 pixels
            // dgv.Columns["IDColumn"].Width = 100;
            gridView.Columns["TenHang"].Width = 200;
            gridView.Columns["DonViTinh"].Width = 200;
            gridView.Columns["ThanhTien"].Width = 200;
            // Set the width of the Name column to 200 pixels
            // dgv.Columns["NameColumn"].Width = 200;
            ////////////////////////////////////////////////////////////////////////////////
            // Load the XML data
            XDocument doc = XDocument.Load(dataPath);

            // Select the PhieuXuatKho element with NgayThangNam="01/01/2019"
            var phieuXuatKhoElement = doc.Descendants("PhieuXuatKho")
                .Where(x => (string)x.Attribute("NgayThangNam") == "01/01/2019")
                .FirstOrDefault();


            if (phieuXuatKhoElement != null)
            {
                
                string donVi = phieuXuatKhoElement.Attribute("DonVi").Value;
                string boPhan = phieuXuatKhoElement.Attribute("BoPhan").Value;
                string so = phieuXuatKhoElement.Attribute("So").Value;
                string ngayThangNam = phieuXuatKhoElement.Attribute("NgayThangNam").Value;
                string hovaTenNguoiNhanHang = phieuXuatKhoElement.Element("HovaTenNguoiNhanHang").Value;
                string diaChiBoPhan = phieuXuatKhoElement.Element("DiaChi_BoPhan").Value;
                string lyDoXuatKho = phieuXuatKhoElement.Element("LyDoXuatKho").Value;
                string xuatTaiKho = phieuXuatKhoElement.Element("XuatTaiKho").Value;
                string diaDiem = phieuXuatKhoElement.Element("DiaDiem").Value;

                string tongSoTien = phieuXuatKhoElement.Element("TongSoTien").Value;
                string soChungTuKemTheo = phieuXuatKhoElement.Element("SoChungTuGocKemTheo").Value;
                string ngayThangNam2 = phieuXuatKhoElement.Element("NgayThangNam2").Value;
                string nguoiLapPhieu = phieuXuatKhoElement.Element("NguoiLapPhieu").Value;
                string nguoiNhanHang = phieuXuatKhoElement.Element("NguoiNhanHang").Value;
                string thuKho = phieuXuatKhoElement.Element("ThuKho").Value;
                string keToanTruong = phieuXuatKhoElement.Element("KeToanTruong").Value;
                string giamDoc = phieuXuatKhoElement.Element("GiamDoc").Value;

                DonVi.Text = donVi;
                BoPhan.Text = boPhan;
                So.Text = so;
                HovaTenNguoiNhanHang.Text = hovaTenNguoiNhanHang;
                DiaChi_BoPhan.Text = diaChiBoPhan;
                LyDoXuatKho.Text = lyDoXuatKho;
                XuatTaiKho.Text = xuatTaiKho;
                DiaDiem.Text = diaDiem;
                TongSoTien.Text = tongSoTien;
                SoChungTuKemTheo.Text = soChungTuKemTheo;
                NgayThangNam2.Text = ngayThangNam2;
                NgayThangNam.Text = ngayThangNam;
                NguoiLapPhieu.Text = nguoiLapPhieu;
                NguoiNhanHang.Text = nguoiNhanHang;
                ThuKho.Text = thuKho;
                KeToanTruong.Text = keToanTruong;
                GiamDoc.Text = giamDoc;
                No.Text = "...";
                Co.Text = "...";
                // Access other elements or attributes as needed


                // Print or use other elements or attributes as needed

                // Find the BangChamCong element
               // XElement DanhSach = doc.Descendants("DanhSach").FirstOrDefault();
                var DanhSach1 = phieuXuatKhoElement.Element("DanhSach");

                // Create a DataTable to hold the data
                // DataTable dataTable = new DataTable();
                int stt = 1;
                int index = 0;
                // Add columns to the DataTable
                /*   dataTable.Columns.Add("STT", typeof(int));
                   dataTable.Columns.Add("MaNhanVien", typeof(string));
                   dataTable.Columns.Add("HoTenNhanVien", typeof(string));
                   dataTable.Columns.Add("SoNgayCong", typeof(int));
                   dataTable.Columns.Add("GhiChu", typeof(string));
                   */
                // Loop through each SanPhamHangHoa element under Danh Sach
                foreach (XElement SanPhamHangHoa in DanhSach1.Elements("SanPhamHangHoa"))
                {
                    // Extract data from each CongNhanVien element
                    string STT = SanPhamHangHoa.Element("STT").Value;
                    string TenHang = SanPhamHangHoa.Element("TenHang").Value;
                    int MaSo = int.Parse(SanPhamHangHoa.Element("MaSo").Value);
                    string DonViTinh = SanPhamHangHoa.Element("DonViTinh").Value;
                    int YeuCau = int.Parse(SanPhamHangHoa.Element("YeuCau").Value);
                    int ThucXuat = int.Parse(SanPhamHangHoa.Element("ThucXuat").Value);
                    double ThanhTien = double.Parse(SanPhamHangHoa.Element("ThanhTien").Value);
                    double DonGia = double.Parse(SanPhamHangHoa.Element("DonGia").Value);

                    // Add a row to the DataTable
                    //dataTable.Rows.Add(stt, maNhanVien, hoTenNhanVien, soNgayCong, ghiChu);


                    // lấy giá trị của thuộc tính masach gán vào cột đầu tiên trên dòng thứ sd
                    gridView.Rows.Add();
                    gridView.Rows[index].Cells[0].Value = STT;
                    gridView.Rows[index].Cells[1].Value = TenHang;
                    gridView.Rows[index].Cells[2].Value = MaSo;
                    gridView.Rows[index].Cells[3].Value = DonViTinh;
                    gridView.Rows[index].Cells[4].Value = YeuCau;
                    gridView.Rows[index].Cells[5].Value = ThucXuat;
                    gridView.Rows[index].Cells[6].Value = ThanhTien;
                    gridView.Rows[index].Cells[7].Value = DonGia;
                    stt++;
                    index++;

                }
            }
            // Bind the DataTable to the DataGridView
            //gridView.DataSource = dataTable;
        }

        private void Bai01(DataGridView gridView)
        {
            Bai01DataGridViewSetUp(gridView);
        }

        private void clearDataGridView(DataGridView gridView)
        {
            gridView.Rows.Clear();
            gridView.Columns.Clear();
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}
