using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法.算法类
{
    public class ShellSorter
    {
        public void Sort(int[] arr)
        {
            int inc;
            for (inc = 1; inc <= arr.Length / 9; inc = 3 * inc + 1) ;
            for (; inc > 0; inc /= 3)
            {
                for (int i = inc + 1; i <= arr.Length; i += inc)
                {
                    int t = arr[i - 1];
                    int j = i;
                    while ((j > inc) && (arr[j - inc - 1] > t))
                    {
                        arr[j - 1] = arr[j - inc - 1]; // 交换数据
                        j -= inc;
                    }
                    arr[j - 1] = t;
                }
            }
        }
    }
}
