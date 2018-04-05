using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttcs
{
    class Cau2_HeapSort
    {
        private int heapSize, type;

        private void CreateHeap(List<ObjectThuaDat> list)
        {
            heapSize = list.Count - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                XuLyHeap(list, i);
            }
        }

        private void HoanVi(List<ObjectThuaDat> list, int x, int y)
        {
            ObjectThuaDat temp = list[x];
            list[x] = list[y];
            list[y] = temp;
        }

        private void XuLyHeap(List<ObjectThuaDat> list, int viTri)
        {
            int left = 2 * viTri;
            int right = 2 * viTri + 1;
            int largest = viTri;

            //tăng dần
            if (type == 0)
            {
                if (left <= heapSize && list[left].DiaChi.SoNha > list[viTri].DiaChi.SoNha)
                {
                    largest = left;
                }

                if (right <= heapSize && list[right].DiaChi.SoNha > list[largest].DiaChi.SoNha)
                {
                    largest = right;
                }
            }
            //giảm dần
            else
            {
                if (left <= heapSize && list[left].DiaChi.SoNha < list[viTri].DiaChi.SoNha)
                {
                    largest = left;
                }

                if (right <= heapSize && list[right].DiaChi.SoNha < list[largest].DiaChi.SoNha)
                {
                    largest = right;
                }
            }

            if (largest != viTri)
            {
                HoanVi(list, viTri, largest);
                XuLyHeap(list, largest);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type">0 là tăng dần, 1 là giảm dần</param>
        /// <returns></returns>
        public List<ObjectThuaDat> HeapSort(List<ObjectThuaDat> list, int type)
        {
            this.type = type;
            CreateHeap(list);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                HoanVi(list, 0, i);
                heapSize--;
                XuLyHeap(list, 0);
            }
            return list;
        }
    }
}
