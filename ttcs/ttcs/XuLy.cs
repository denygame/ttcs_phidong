using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ttcs
{
    class XuLy
    {
        List<ObjectThuaDat> listThuaDat = new List<ObjectThuaDat>();
        int type = -1;

        //doc file excel
        public void cau1(string duongDan)
        {
            if (File.Exists(duongDan))
            {
                listThuaDat.Clear();
                listThuaDat = FileExcel.Instance.DocFile(duongDan);
                hienThiDanhSach();
            }
            else
            {
                Console.WriteLine("Duong dan khong hop le");
            }
        }

        //sắp xếp kiểu heap sort theo số nhà của địa chỉ
        public void cau2(int type)
        {
            if (listThuaDat.Count == 0)
            {
                Console.WriteLine("Danh Sach Trong!");
            }
            else
            {
                this.type = type;
                Cau2_HeapSort sort = new Cau2_HeapSort();
                sort.HeapSort(listThuaDat, type);
                hienThiDanhSach();
            }
        }

        //chèn 1 thửa đất theo sắp xếp ở câu 2
        public void cau3()
        {
            if (listThuaDat.Count == 0)
            {
                Console.WriteLine("Danh Sach Trong!");
            }
            else
            {
                if (this.type == -1)
                {
                    Console.WriteLine("Chua Sap Xep!");
                }
                else
                {
                    Console.WriteLine("\r\n-------------------------------");
                    Console.WriteLine("Nhap Dia Chi: ");
                    nhapSoNha:
                    Console.Write("\t=> So nha: ");
                    string soNha = Console.ReadLine();
                    if (!IsNumber(soNha))
                    {
                        Console.WriteLine("!!! So nha chi duoc nhap so !!!\r\n");
                        goto nhapSoNha;
                    }
                    Console.Write("\r\n\t=> Duong: ");
                    string tenDuong = Console.ReadLine();
                    Console.Write("\r\n\t=> Phuong: ");
                    string phuong = Console.ReadLine();
                    Console.Write("\r\n\t=> Quan: ");
                    string quan = Console.ReadLine();
                    string diaChi = soNha + "," + tenDuong + "," + phuong + "," + quan;

                    nhapDT:
                    Console.Write("\r\nNhap Dien Tich: ");
                    string dt = Console.ReadLine();
                    if (!IsNumber(dt))
                    {
                        Console.WriteLine("!!! Dien tich chi duoc nhap so !!!\r\n");
                        goto nhapDT;
                    }
                    double dienTich = double.Parse(dt);

                    Console.Write("\r\nNhap Chu So Huu: ");
                    string chuSoHuu = Console.ReadLine();

                    nhapLN:
                    Console.Write("\r\nNhap Loai Nha <1/2/3/4>: ");
                    string ln = Console.ReadLine();
                    if (!IsNumber(ln))
                    {
                        Console.WriteLine("!!! Loai nha chi duoc nhap so tu 1 den 4 !!!\r\n");
                        goto nhapLN;
                    }
                    else
                    {
                        int test = int.Parse(ln);
                        if (test != 1 && test != 2 && test != 3 && test != 4)
                        {
                            Console.WriteLine("!!! Loai nha chi duoc nhap so tu 1 den 4 !!!\r\n");
                            goto nhapLN;
                        }
                    }
                    int loaiNha = int.Parse(ln);

                    Console.Write("\r\nNhap Muc Dich Su Dung: ");
                    string mucDich = Console.ReadLine();

                    nhapGT:
                    Console.Write("\r\nNhap Gia Tien: ");
                    string gt = Console.ReadLine();
                    if (!IsNumber(gt))
                    {
                        Console.WriteLine("!!! Gia tien chi duoc nhap so !!!\r\n");
                        goto nhapGT;
                    }
                    double giaTien = double.Parse(gt);

                    int stt = listThuaDat.Count + 1;

                    //thêm vào danh sách
                    listThuaDat.Add(new ObjectThuaDat(stt, loaiNha, chuSoHuu, mucDich, dienTich, giaTien, diaChi));

                    //thực hiện lại câu 2 - sap xep danh sach theo tieu chi cu
                    cau2(this.type);
                }
            }
        }

        //xóa thửa đât theo từ khóa
        public void cau4(string key)
        {
            if (listThuaDat.Count == 0)
            {
                Console.WriteLine("Danh Sach Trong!");
            }
            else
            {
                var dsTraVe = danhSachTimKiem(key);
                if (dsTraVe.Count != 0)
                {
                    nhan:
                    Console.Write("\t====> Ban xac nhan xoa? <0/1>: ");
                    string nhap = Console.ReadLine();
                    if (IsNumber(nhap))
                    {
                        int so = int.Parse(nhap);
                        switch (so)
                        {
                            case 0: return;
                            case 1:
                                foreach (var ds in dsTraVe)
                                {
                                    listThuaDat.Remove(ds);
                                }
                                hienThiDanhSach();
                                return;
                            default: goto nhan;
                        }
                    }
                }
            }
        }

        //tìm kiếm thửa đất
        public void cau5(string key)
        {
            if (listThuaDat.Count == 0)
            {
                Console.WriteLine("Danh Sach Trong!");
            }
            else
            {
                var dsTraVe = danhSachTimKiem(key);
            }
        }

        //ghi file excel
        public void cau7(string duongDan)
        {
            if (listThuaDat.Count == 0)
            {
                Console.WriteLine("Danh Sach Trong!");
            }
            else
            {
                string path = FileExcel.Instance.GhiFile(duongDan, listThuaDat);
                Console.WriteLine("==> Da luu file tai: " + path);
            }
        }

        public void hienThiDanhSach()
        {
            if (listThuaDat.Count == 0)
            {
                Console.WriteLine("Danh Sach Trong!");
            }
            else
            {
                foreach (var item in listThuaDat)
                {
                    Console.WriteLine("\r\n-------------------------------");
                    Console.WriteLine("STT: " + item.Stt);
                    Console.WriteLine("Dia Chi: " + item.DiaChi.writeAddress());
                    Console.WriteLine("Dien Tich: " + item.DienTich);
                    Console.WriteLine("Chu So  Huu: " + item.ChuSoHuu);
                    Console.WriteLine("Loai Nha: " + item.LoaiNha);
                    Console.WriteLine("Muc Dich Su Dung: " + item.MucDichSuDung);
                    Console.WriteLine("Gia Tien: " + item.GiaTien);
                    Console.WriteLine("-------------------------------\r\n");
                }
            }
        }

        private bool IsNumber(string pValue)
        {
            if (pValue == "") return false;
            foreach (Char c in pValue)
                if (!Char.IsDigit(c))
                    return false;
            return true;
        }

        private List<ObjectThuaDat> danhSachTimKiem(string key)
        {
            var ls = new List< ObjectThuaDat>();

            foreach (var item in listThuaDat)
            {
                //tìm trong địa chỉ
                if (item.DiaChi.writeAddress().ToLower().Contains(key.ToLower()))
                    ls.Add(item);

                //tìm trong Chu So  Huu
                if (item.ChuSoHuu.ToLower().Contains(key.ToLower()))
                {
                    if (!tonTaiTrongList(ls, item)) ls.Add(item);
                }

                //tìm trong muc dich su dung
                if (item.MucDichSuDung.ToLower().Contains(key.ToLower()))
                {
                    if (!tonTaiTrongList(ls, item)) ls.Add(item);
                }

                if (IsNumber(key))
                {
                    double num = double.Parse(key);

                    //tìm trong số thứ tự
                    if (item.Stt == num)
                    {
                        if (!tonTaiTrongList(ls, item)) ls.Add(item);
                    }

                    //tìm trong dien tich
                    if (item.DienTich == num)
                    {
                        if (!tonTaiTrongList(ls, item)) ls.Add(item);
                    }

                    //tìm trong Loai Nha
                    if (item.LoaiNha == num)
                    {
                        if (!tonTaiTrongList(ls, item)) ls.Add(item);
                    }

                    //tìm trong gia tien
                    if (item.GiaTien == num)
                    {
                        if (!tonTaiTrongList(ls, item)) ls.Add(item);
                    }
                }
            }

            //hien thi danh sach ra
            if (ls.Count == 0)
            {
                Console.WriteLine("Khong tim thay thua dat nao theo tu khoa!");
            }
            else
            {
                Console.WriteLine("=> Tim duoc " + ls.Count + " thua dat sau: \r\n");
                foreach (var item in ls)
                {
                    Console.WriteLine("\r\n-------------------------------");
                    Console.WriteLine("STT: " + item.Stt);
                    Console.WriteLine("Dia Chi: " + item.DiaChi.writeAddress());
                    Console.WriteLine("Dien Tich: " + item.DienTich);
                    Console.WriteLine("Chu So  Huu: " + item.ChuSoHuu);
                    Console.WriteLine("Loai Nha: " + item.LoaiNha);
                    Console.WriteLine("Muc Dich Su Dung: " + item.MucDichSuDung);
                    Console.WriteLine("Gia Tien: " + item.GiaTien);
                    Console.WriteLine("-------------------------------\r\n");
                }
            }

            return ls;
        }

        private bool tonTaiTrongList(List<ObjectThuaDat> list, ObjectThuaDat item)
        {
            foreach (var i in list)
            {
                if (i.Stt == item.Stt) return true;
            }
            return false;
        }
    }
}
