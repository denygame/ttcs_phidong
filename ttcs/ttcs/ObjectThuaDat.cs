using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttcs
{
    class ObjectThuaDat
    {
        private ObjDiaChi diaChi;
        private double dienTich, giaTien;
        private string chuSoHuu, mucDichSuDung;
        private int loaiNha, stt;

        public ObjectThuaDat(int stt, int loaiNha, string chuSoHuu, string mucDich, double dienTich, double giaTien, string diaChi)
        {
            this.Stt = stt;
            this.LoaiNha = loaiNha;
            this.ChuSoHuu = chuSoHuu;
            this.MucDichSuDung = mucDich;
            this.DienTich = dienTich;
            this.GiaTien = giaTien;
            this.DiaChi = (new ObjDiaChi(diaChi));
        }

        public double DienTich { get { return dienTich; } set { dienTich = value; } }
        public double GiaTien { get { return giaTien; } set { giaTien = value; } }
        public string ChuSoHuu { get { return chuSoHuu; } set { chuSoHuu = value; } }
        public string MucDichSuDung { get { return mucDichSuDung; } set { mucDichSuDung = value; } }
        public int LoaiNha { get { return loaiNha; } set { loaiNha = value; } }
        public int Stt { get { return stt; } set { stt = value; } }
        internal ObjDiaChi DiaChi { get { return diaChi; } set { diaChi = value; } }
    }

    class ObjDiaChi
    {
        private int soNha;
        private string tenDuong = null, phuong = null, quan = null;

        public ObjDiaChi(string chuoiDiaChi)
        {
            string[] separators = { "," };
            string[] str = chuoiDiaChi.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            this.SoNha = int.Parse(str[0]);
            this.TenDuong = str[1];
            this.Phuong = str[2];
            this.Quan = str[3];
        }

        public string writeAddress()
        {
            return this.SoNha + "," + this.TenDuong + "," + this.Phuong + "," + this.Quan;
        }

        public int SoNha { get { return soNha; } set { soNha = value; } }
        public string TenDuong { get { return tenDuong; } set { tenDuong = value; } }
        public string Phuong { get { return phuong; } set { phuong = value; } }
        public string Quan { get { return quan; } set { quan = value; } }
    }
}
