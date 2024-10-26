using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using static DoAnOOP.QuanLiBanTin;

namespace DoAnOOP
{
    public interface IBaiVietRepository
    {
        void ThemBaiViet(BaiViet baiViet);
        void SuaBaiViet(BaiViet baiViet);
        void XoaBaiViet(BaiViet baiViet);
    }
    public class BaiViet
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string TacGia { get; set; }
        public ChuyenMuc ChuyenMuc { get; set; }
        public TrangThaiBaiViet TrangThai { get; set; }
        public DateTime NgayDang { get; set; }
    }
    public enum ChuyenMuc
    {
        Thoisu,
        TheThao,
        GiaiTri
    }
    public enum TrangThaiBaiViet
    {
        Nhap,
        DaDuyet,
        DaPhatSong
    }

    public class FileBaiVietRepository : IBaiVietRepository
    {
        private string filePath = "baiviet.json"; // Đường dẫn đến file JSON

        public void ThemBaiViet(BaiViet baiViet)
        {
            // Đọc danh sách bài viết hiện tại từ file
            List<BaiViet> danhSachBaiViet = DocDanhSachBaiViet();

            // Thêm bài viết mới vào danh sách
            danhSachBaiViet.Add(baiViet);

            // Ghi danh sách bài viết cập nhật vào file
            GhiDanhSachBaiViet(danhSachBaiViet);
        }

        private List<BaiViet> DocDanhSachBaiViet()
        {
            if (!File.Exists(filePath))
            {
                return new List<BaiViet>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<BaiViet>>(jsonString) ?? new List<BaiViet>();
        }

        private void GhiDanhSachBaiViet(List<BaiViet> danhSachBaiViet)
        {
            string jsonString = JsonConvert.SerializeObject(danhSachBaiViet, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }
    }
    internal class QuanLiBanTin
    {
        public event EventHandler<BaiViet> BaiVietDaThem;

        private IBaiVietRepository _repository;

        public QuanLyBanTin(IBaiVietRepository repository)
        {
            _repository = repository;
        }

        public void ThemBaiViet(BaiViet baiViet)
        {
            _repository.ThemBaiViet(baiViet);
            BaiVietDaThem?.Invoke(this, baiViet);
        }

    }
        
}
