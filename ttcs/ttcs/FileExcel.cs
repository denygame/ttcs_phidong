using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace ttcs
{
    class FileExcel
    {
        //singleton
        private static FileExcel instance = null;

        public static FileExcel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileExcel();
                }
                return instance;
            }
        }
        public FileExcel() { }


        public List<ObjectThuaDat> DocFile(string link)
        {
            List<ObjectThuaDat> traVe = new List<ObjectThuaDat>();

            // chạy file Excel theo đường dẫn
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(link);
            // Lấy Sheet 1
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
            // Lấy phạm vi dữ liệu
            Excel.Range xlRange = xlWorksheet.UsedRange;
            // Tạo mảng lưu trữ dữ liệu
            object[,] valueArray = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

            //đọc row hiện có trong Excel
            for (int row = 2; row <= xlWorksheet.UsedRange.Rows.Count; row++)
            {
                int stt = int.Parse(valueArray[row, 1].ToString());
                string diaChi = valueArray[row, 2].ToString();
                double dienTich = double.Parse(valueArray[row, 3].ToString());
                string chuSoHuu = valueArray[row, 4].ToString();
                int loaiNha = int.Parse(valueArray[row, 5].ToString());
                string mucDich = valueArray[row, 6].ToString();
                double giaTien = double.Parse(valueArray[row, 7].ToString());

                traVe.Add(new ObjectThuaDat(stt, loaiNha, chuSoHuu, mucDich, dienTich, giaTien, diaChi));
            }

            // Đóng Workbook.
            xlWorkbook.Close(false);
            // Đóng application.
            xlApp.Quit();
            //Khử hết đối tượng
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            return traVe;
        }

        public string GhiFile(string link, List<ObjectThuaDat> list)
        {
            // Khởi động chtr Excell
            Excel.Application exApp = new Excel.Application();

            // Thêm file temp xls
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            // Lấy sheet 1.
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

            // Range là ô [1,1] (A1)
            ((Excel.Range)exSheet.Cells[1, 1]).Value2 = "STT";
            ((Excel.Range)exSheet.Cells[1, 2]).Value2 = "Dia Chi";
            ((Excel.Range)exSheet.Cells[1, 3]).Value2 = "Dien Tich";
            ((Excel.Range)exSheet.Cells[1, 4]).Value2 = "Chu So Huu Hien Tai";
            ((Excel.Range)exSheet.Cells[1, 5]).Value2 = "Loai Nha";
            ((Excel.Range)exSheet.Cells[1, 6]).Value2 = "Muc Dich Su Dung";
            ((Excel.Range)exSheet.Cells[1, 7]).Value2 = "Gia Tien";

            for (int i = 0; i < list.Count; i++)
            {
                ((Excel.Range)exSheet.Cells[i + 2, 1]).Value2 = list[i].Stt;
                ((Excel.Range)exSheet.Cells[i + 2, 2]).Value2 = list[i].DiaChi.writeAddress();
                ((Excel.Range)exSheet.Cells[i + 2, 3]).Value2 = list[i].DienTich;
                ((Excel.Range)exSheet.Cells[i + 2, 4]).Value2 = list[i].ChuSoHuu;
                ((Excel.Range)exSheet.Cells[i + 2, 5]).Value2 = list[i].LoaiNha;
                ((Excel.Range)exSheet.Cells[i + 2, 6]).Value2 = list[i].MucDichSuDung;
                ((Excel.Range)exSheet.Cells[i + 2, 7]).Value2 = list[i].GiaTien;
            }


            // Save file
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\file.xlsx";

            exBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
        false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            exBook.Close(false);
            exApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);

            return path;
        }
    }
}
