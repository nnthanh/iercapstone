using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.Utils
{
    public enum TinhTrangMau {
        KhoiTao, DaNhan, DaChuyen, DaCoKQ, Unknown
    }

    public static partial class TinhTrangMauConverter
    {
        public static TinhTrangMau ToTinhTrangMau(byte tinhtrangmau_data)
        {
            switch (tinhtrangmau_data)
            {
                case 0: return TinhTrangMau.KhoiTao;
                case 1: return TinhTrangMau.DaNhan;
                case 2: return TinhTrangMau.DaChuyen;
                case 3: return TinhTrangMau.DaCoKQ;
                default: return TinhTrangMau.Unknown;
            }
        }

        public static byte ToByte(TinhTrangMau tinhtrangmau_data)
        {
            switch (tinhtrangmau_data)
            {
                case TinhTrangMau.KhoiTao: return 0;
                case TinhTrangMau.DaNhan: return 1;
                case TinhTrangMau.DaChuyen: return 2;
                case TinhTrangMau.DaCoKQ: return 3;
                default: return 4;
            }
        }
    }
}