

using System;

namespace My_WebApi_Core.Models
{
    public class HangHoaVM
    {
        public string TenHH { get; set; }
        public double DonGia { get; set;}
    } 
    public class HangHoa : HangHoaVM
    {
        public Guid MaHH { get; set; }
    }

}
