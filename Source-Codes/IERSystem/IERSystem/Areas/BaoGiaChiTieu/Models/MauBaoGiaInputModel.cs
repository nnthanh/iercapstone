using IERSystem.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.BaoGiaChiTieu.Models
{
    public class ChiTieuPhanTichInputModel
    {
        public string TenChiTieu { get; set; }
        public decimal DonGia { get; set; }
        public List<string> PhuongPhaps { get; set; }
    }

    public class MauBaoGiaInputModel
    {
        public string NhomChiTieu { get; set; }
        public List<ChiTieuPhanTichInputModel> ChiTieus { get; set; }
        
        //public MauBaoGiaInputModel()
        //{
        //    PhuongPhap = new List<string>();
        //    TenChiTieu = new List<string>();
        //}

        //nthoang: TODO: WIP
        public ChiTieuPhanTich ToModel()
        {
            throw new NotImplementedException();
        }
    }
}