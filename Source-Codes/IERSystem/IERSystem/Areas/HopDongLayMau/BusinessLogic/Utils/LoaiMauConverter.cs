using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.Utils
{
    public static class LoaiMauConverter
    {
        public static string ToLoaiMau(string mamau)
        {
            if (mamau[0] == 'B') return "Bùn Thải";
            else if (mamau[0] == 'Đ') return "Đất";
            else if (mamau.Substring(0, 2).Equals("NC")) return "Nước Cấp";
            else if (mamau.Substring(0, 2).Equals("NT")) return "Nước Thải";
            else if (mamau.Substring(0, 2).Equals("NM")) return "Nước Mặt";
            else if (mamau.Substring(0, 2).Equals("KK")) return "Không Khí";
            else if (mamau.Substring(0, 2).Equals("TP")) return "Thực Phẩm";
            else return "Không Rõ";
        }
    }
}