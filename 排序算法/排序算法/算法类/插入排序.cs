using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法.算法类
{
    public class InsertionSorter
    {
        public void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int t = arr[i];
                int j = i;
                while ((j > 0) && (arr[j - 1] > t))
                {
                    arr[j] = arr[j - 1]; // 交换顺序
                    --j;
                }
                arr[j] = t;
            }
        }
    }
}
