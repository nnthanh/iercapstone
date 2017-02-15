﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class MauLayHienTruong
    {
        public int Id { get; set; }
        public String MaMau { get; set; }
        public String ViTriLayMau { get; set; }
        public uint Soluong { get; set; }
        public String DonVi { get; set; }
        public String MoTaMau { get; set; }
        //public DateTime NgayNhanMau { get; set; }
        //public DateTime NgayTraMau { get; set; }
        public int MaHDPhanTich { get; set; }
        public String MaChiTieuPhanTich { get; set; }
        public uint NamLayMau { get; set; }
        
        public virtual Request Request { get; set; }

    }
}