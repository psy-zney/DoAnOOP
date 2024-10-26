using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static DoAnOOP.QuanLiBanTin;

namespace DoAnOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            /*
            // Tạo đối tượng BaiViet
            BaiViet baiViet = new BaiViet();
            baiViet.TieuDe = "Bài viết về lập trình C#";
            baiViet.NoiDung = "";
            baiViet.TacGia = "Nguyen Van A";
            baiViet.NgayDang = DateTime.Now;
            // Serialize thành chuỗi JSON
            string json = JsonConvert.SerializeObject(baiViet);

            // Lưu vào file
            File.WriteAllText("baiviet.json", json);*/
            string filePath = "baiviet.json";
            string jsonString = File.ReadAllText(filePath);

            // Deserialize danh sách các bản tin
            BaiViet baiViet = JsonConvert.DeserializeObject<BaiViet>(jsonString);
            // Duyệt qua danh sách và hiển thị thông tin
            
            {
                Console.WriteLine($"Tiêu đề: {baiViet.TieuDe}");
                Console.WriteLine($"Nội dung: {baiViet.NoiDung}");
            }
            Console.ReadKey();
        }   
        
    
    }
}
