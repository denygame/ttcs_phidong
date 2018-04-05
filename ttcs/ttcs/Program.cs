using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttcs
{
    class Program
    {
        static bool IsNumber(string pValue)
        {
            if (pValue == "") return false;
            foreach (Char c in pValue)
                if (!Char.IsDigit(c))
                    return false;
            return true;
        }

        static void Main(string[] args)
        {
            XuLy xuly = new XuLy();

            nhan:
            Console.WriteLine("\n\n********************* MENU *********************");
            Console.WriteLine("\t 0: Hien thi danh sach");
            Console.WriteLine("\t 1: Doc file Excel");
            Console.WriteLine("\t 2: Sap xep kieu heapsort theo so nha");
            Console.WriteLine("\t 3: Chen thua dat theo tieu chi cau 2");
            Console.WriteLine("\t 4: Xoa thua dat lien quan tu khoa");
            Console.WriteLine("\t 5: Tim kiem thua dat");
            //Console.WriteLine("\t 6: Ghi File");
            Console.WriteLine("\t 7: Xuat file excel");
            Console.WriteLine("\t 8: Dung Chuong Trinh");
            Console.WriteLine("************************************************\n\n");
            Console.Write("\t====> Chon Chuc Nang: ");
            string chucNang = Console.ReadLine();
            if (IsNumber(chucNang))
            {
                double s = double.Parse(chucNang);
                Console.WriteLine("    ================================   \r\n");
                switch (s)
                {
                    case 0:
                        xuly.hienThiDanhSach();
                        goto nhan;
                    case 1:
                        Console.WriteLine("Nhap duong dan den file excel hoac keo tha file vao day!");
                        Console.Write("Duong Dan: ");
                        string link = Console.ReadLine();
                        xuly.cau1(link);
                        goto nhan;
                    case 2:
                        nhan1:
                        Console.Write("=> Tang/Giam <0/1>: ");
                        string tangGiam = Console.ReadLine();
                        if (IsNumber(tangGiam))
                        {
                            int type = int.Parse(tangGiam);
                            if (type != 0 && type != 1) goto nhan1;
                            xuly.cau2(type);
                            goto nhan;
                        }
                        else goto nhan1;
                    case 3:
                        xuly.cau3();
                        goto nhan;
                    case 4:
                        Console.Write("=> Nhap tu khoa: ");
                        string key4 = Console.ReadLine();
                        xuly.cau4(key4);
                        goto nhan;
                    case 5:
                        Console.Write("=> Nhap tu khoa: ");
                        string key5 = Console.ReadLine();
                        xuly.cau5(key5);
                        goto nhan;
                    case 7:
                        string duongDan = @"C:\Users\thanh\Desktop\ttcs_phidong\file.xlsx";
                        xuly.cau7(duongDan);
                        goto nhan;
                    case 8: Console.ReadKey(); return;
                    default: Console.WriteLine("Khong co chuc nang nay!"); goto nhan;
                }
            }
        }
    }
}
