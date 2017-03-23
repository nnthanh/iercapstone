using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLyKetQuaPhanTich.Models;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class MauLayHienTruongAPIImpl
    {
        public static IEnumerable<MauPTDaChuyenOutputModel> GetMauPTDaChuyen(IERSystemModelContainer db)
        {
            var tinhtrang_dachuyen = TinhTrangMauConverter.ToByte(TinhTrangMau.DaChuyen);
            //nthoang: Find all MauPT having TinhTrangMau == DaChuyen
            var cacmaudachuyen = (from maupt in db.MauLayHienTruongs
                                  where maupt.TinhTrang == tinhtrang_dachuyen
                                  select maupt);

            var result = new List<MauPTDaChuyenOutputModel>();
            foreach (var maudachuyen in cacmaudachuyen)
            {
                if (maudachuyen.SoKQThuNghiem != null)
                {
                    //nthoang: This maupt already has kqthunghiem
                    result.Add(new MauPTDaChuyenOutputModel()
                    {
                        Id = maudachuyen.Id,
                        MaMau = maudachuyen.MaMau,
                        NgayChuyen = maudachuyen.SoChuyenMau.NgayGiaoMau.ToShortDateString(),
                        NgayTra = maudachuyen.SoKQThuNghiem.NgayTraMau.ToShortDateString(),
                    });
                }
                else
                {
                    //nthoang: This maupt doesn't have kqthunghiem (yet)
                    result.Add(new MauPTDaChuyenOutputModel()
                    {
                        Id = maudachuyen.Id,
                        MaMau = maudachuyen.MaMau,
                        NgayChuyen = maudachuyen.SoChuyenMau.NgayGiaoMau.ToShortDateString(),
                        NgayTra = maudachuyen.SoChuyenMau.NgayTraKQ.ToShortDateString(),
                    });
                }
            }
            return result;
        }
    }
}