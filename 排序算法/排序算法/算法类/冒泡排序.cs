﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法.算法类
{
    public class EbullitionSorter
    {
        public void Sort(int[] arr)
        {
            int i, j, temp;
            bool done = false;
            j = 1;
            while ((j < arr.Length) && (!done))  // 推断长度
            {
                done = true;
                for (i = 0; i < arr.Length - j; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        done = false;
                        temp = arr[i];
                        arr[i] = arr[i + 1]; // 交换数据
                        arr[i + 1] = temp;
                    }
                }
                j++;
            }
        }
    }
}
