using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoChuyenMau.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class CacSoChuyenMauAPIImpl
    {
        public static async Task<IEnumerable<CacSoChuyenMauOutputModel>> CreateView(IERSystemModelContainer db)
        {
            var queried_async = await db.CacSoChuyenMaus.ToListAsync();
            return queried_async.Select((cacsonhanmau_model, index) =>
            {
                return new CacSoChuyenMauOutputModel()
                {
                    //nthoang: QuyenSo should start from 1
                    QuyenSo = index + 1,
                    CreatedBy = cacsonhanmau_model.CreatedBy,
                    Id = cacsonhanmau_model.Id,
                    TuNgay = cacsonhanmau_model.TuNgay.ToShortDateString(),
                    DenNgay = cacsonhanmau_model.DenNgay.ToShortDateString(),
                    NoiDung = cacsonhanmau_model.SoChuyenMaus.ToList().Select((sonhanmau_model) =>
                    {
                        //nthoang: Cache db query result to reuse(if needed)
                        var maulayhientruong_mapped = sonhanmau_model.MauLayHienTruong;
                        return new SoChuyenMauOutputModel()
                        {
                            MaMau = sonhanmau_model.MauLayHienTruong.MaMau,
                            MaKhachHang = maulayhientruong_mapped.PhieuYeuCau.MaDon,
                            NgayGiao = sonhanmau_model.NgayGiaoMau.ToShortDateString(),
                            NgayTraKQ = sonhanmau_model.NgayTraKQ.ToShortDateString(),
                            ChiTieuThuNghiem = String.Join(", ", maulayhientruong_mapped.ChiTieuPhanTiches.Select((item) => item.TenChiTieu))
                        };
                    })
                };
            });
        }

        internal static void CreateModel(SoChuyenMauInputModel cacsochuyenmau_inp, IERSystemModelContainer db)
        {
            db.CacSoChuyenMaus.Add(new CacSoChuyenMau()
            {
                UserId = cacsochuyenmau_inp.CreatedBy.Id,
                CreatedBy = cacsochuyenmau_inp.CreatedBy,
                CreatedDate = DateTime.Now,
                TuNgay = new DateTime(cacsochuyenmau_inp.Nam, cacsochuyenmau_inp.TuThang, 1),
                DenNgay = new DateTime(
                    cacsochuyenmau_inp.Nam, cacsochuyenmau_inp.DenThang, 
                    DateTime.DaysInMonth(cacsochuyenmau_inp.Nam, cacsochuyenmau_inp.DenThang))
            });
        }
    }
}