using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法.算法类
{
    public class Counting
    {
        /// <summary>
        /// 计数排序。

        /// 要求:
        ///     arrayToSort的元素必须大于等于0。或者经过一定的转换使其元素在
        ///     大于等于0范围内。比如有例如以下序列(-1,-8,10,11),那么依据最小值8,
        ///     将各个数字加8转化为(7,0,18,19),然后进行计数排序。结果为(0,7,18,19),
        ///     然后再将结果个数字减8即为(-8,-1,10,11)
        /// </summary>
        /// <param name="arrayToSort">要排序的数组</param>
        /// <param name="maxValue">数组的最大值加一</param>
        /// <returns>计数排序后的结果</returns>
        public static int[] CountingSort(int[] arrayToSort, int k)
        {
            // 排序后的结果存储
            int[] sortedArray = new int[arrayToSort.Length];
            // 计数数组
            int[] countingArray = new int[k];
            // 计数数组初始化
            for (int i = 0; i < countingArray.Length; i++)
            {
                countingArray[i] = 0;
            }

            // 单个元素计数(经过该步骤countingArray[i]的含义为数字i的个数为countingArray[i])
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                countingArray[arrayToSort[i]] = countingArray[arrayToSort[i]] + 1;
            }
            // 计算小于等于某数的个数(经过该步骤countingArray[i]的含义为小于等于数字i的元素个数为countingArray[i])
            for (int i = 1; i < countingArray.Length; i++)
            {
                countingArray[i] += countingArray[i - 1];
            }

            // 得到排序后的结果
            for (int i = 0; i < sortedArray.Length; i++)
            {
                int numIndex = countingArray[arrayToSort[i]] - 1;
                sortedArray[numIndex] = arrayToSort[i];
                countingArray[arrayToSort[i]] = countingArray[arrayToSort[i]] - 1;
            }

            return sortedArray;
        }
    }
}
