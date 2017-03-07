using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoNhanMau.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class CacSoNhanMauAPIImpl
    {
        public static void CreateModel(SoNhanMauInputModel input_request, IERSystemModelContainer db)
        {
            var cacsonhanmau_model = input_request.ToModel();
            db.CacSoNhanMaus.Add(cacsonhanmau_model);
        }

        public static async Task<IEnumerable<CacSoNhanMauOutputModel>> CreateView(IERSystemModelContainer db)
        {
            var queried_async = await db.CacSoNhanMaus.ToListAsync();
            return queried_async.Select((cacsonhanmau_model, index) =>
            {
                return new CacSoNhanMauOutputModel()
                {
                    //nthoang: QuyenSo should start from 1
                    QuyenSo = index + 1,
                    Id = cacsonhanmau_model.Id,
                    TuNgay = cacsonhanmau_model.TuNgay.ToShortDateString(),
                    DenNgay = cacsonhanmau_model.DenNgay.ToShortDateString(),
                    NoiDung = cacsonhanmau_model.SoNhanMaus.ToList().Select((sonhanmau_model) => {
                        //nthoang: Cache db query result to reuse(if needed)
                        var maulayhientruong_mapped = sonhanmau_model.MauLayHienTruong;
                        return new SoNhanMauOutputModel()
                        {
                            Id = sonhanmau_model.Id,
                            MaMau = sonhanmau_model.MauLayHienTruong.MaMau,
                            MaMauKH = maulayhientruong_mapped.MaMauKH,
                            MaPhieuYeuCau = maulayhientruong_mapped.PhieuYeuCau.MaDon,
                            NgayNhan = sonhanmau_model.NgayNhan.ToShortDateString(),
                            NgayTraKQ = sonhanmau_model.NgayTraKQ.ToShortDateString(),
                            TenDiaChiKH =
                                maulayhientruong_mapped.PhieuYeuCau.TenKhachHang + " / " +
                                maulayhientruong_mapped.PhieuYeuCau.DiaChiKhachHang
                        };
                    })
                };
            });
        }

    }
}