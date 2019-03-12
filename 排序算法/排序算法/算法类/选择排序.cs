using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法.算法类
{
    public class SelectionSorter
    {
        private int min;
        public void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                int t = arr[min];
                arr[min] = arr[i];
                arr[i] = t;
            }
        }
    }
}
