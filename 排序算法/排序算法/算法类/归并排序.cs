using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法.算法类
{
    public class Function
    {
        private int Groups;
        private int CopyGroups;
        private int mergerows;
        private int[] Array27;
        private static Random ran = new Random();
        public Function(int length)
        {
            Array27 = new int[length];
            for (int i = 0; i < length; i++)
                Array27[i] = ran.Next(1, 100);
        }
        //选择
        public void ToMergeSort()
        {
            MergeSort(Array27);
        }
        public void ToRecursiveMergeSort()
        {
            RecursiveMergeSort(Array27, 0, Array27.Length - 1);
        }
        public void ToNaturalMergeSort()
        {
            NaturalMergeSort(Array27);
        }

        /// <summary>
        /// 归并排序(递归）
        ///    核心思想：（分治）
        ///           将待排序元素（递归直至元素个数为１）分成左右两个大小大致同样的2个子集合。然后。
        ///           分别对2个子集合进行排序，终于将排好序的子集合合并成为所要求的排好序的集合．  
        /// 核心算法时间复杂度：   
        ///           T(n)=O(nlogn)
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void RecursiveMergeSort(int[] Array, int left, int right)
        {
            int middle = (left + right) / 2;

            if (left < right)
            {
                //对前半部分递归拆分
                RecursiveMergeSort(Array, left, middle);
                //对后半部分递归拆分
                RecursiveMergeSort(Array, middle + 1, right);
                MergeOne(Array, left, middle, right);
            }
        }
        public void MergeOne(int[] Array, int left, int middle, int right)
        {
            int leftindex = left;
            int rightindex = middle + 1;
            //动态暂时二维数组存放切割为两个小Array的数组排列顺序后的数据
            int[] merge = new int[right + 1];
            int index = 0;
            //对两个小数组合并排序
            while (leftindex <= middle && rightindex <= right)
                merge[index++] = (Array[leftindex] - Array[rightindex]) >= 0 ? Array[rightindex++] : Array[leftindex++];
            //有一側子数列遍历完后，将另外一側子数列剩下的数依次放入暂存数组中（有序）
            if (leftindex <= middle)
            {
                for (int i = leftindex; i <= middle; i++)
                    merge[index++] = Array[i];
            }
            if (rightindex <= right)
            {
                for (int i = rightindex; i <= right; i++)
                    merge[index++] = Array[i];
            }
            //将有序的数列 写入目标数组 ，即原来把Array数组分为两个小Array数组后又一次有序组合起来(覆盖原数组）
            index = 0;
            for (int i = left; i <= right; i++)
                Array[i] = merge[index++];
        }

        /// <summary>
        /// 归并排序(非递归）
        ///     核心思想：（分治）
        ///           对n个数的数列每相邻两个元素排序。组成n/2个或（n+1)/2个子数组，单个的不比了直接进入下一轮。
        ///     然后对每一个相邻的子数组再排序，以此类推最后得到排好序的数列 
        ///  forexample：  59 35 54 28 52 
        ///   排序And分：  35 59. 28 54. 52
        ///   排序And分：  28 35 54 59. 52
        ///        结果：  28 35 52 54 59
        /// 核心算法时间复杂度：   
        ///           T(n)=O(nlogn)
        /// </summary>
        /// <param name="Array"></param>
        public void MergeSort(int[] Array)
        {
            //index固定的数组
            int[] merge = new int[Array.Length];
            int P = 0;
            while (true)
            {
                int index = 0;
                //子数组元素的个数
                int ENumb = (int)Math.Pow(2, P);
                //一个子数组中的元素个数与数组的一半元素个数比較大小
                //最糟糕的情况最右边的数组仅仅有一个元素
                if (ENumb < Array.Length)
                {
                    while (true)
                    {
                        int TorFAndrightindex = index;
                        //最后一个子数组的第一个元素的index与数组index相比較
                        if (TorFAndrightindex <= Array.Length - 1)
                            MergeTwo(Array, merge, index, ENumb);
                        else
                            break;
                        index += 2 * ENumb;
                    }
                }
                else
                    break;
                P++;
            }
        }
        public void MergeTwo(int[] Array, int[] merge, int index, int ENumb)
        {
            //换分两个子数组的index(千万不能用middle = (right + left) / 2划分）
            // 1
            int left = index;
            int middle = left + ENumb - 1;
            //（奇数时）
            //排除middleindex越界
            if (middle >= Array.Length)
            {
                middle = index;
            }
            //同步化merge数组的index
            int mergeindex = index;
            // 2
            int right;
            int middleTwo = (index + ENumb - 1) + 1;
            right = index + ENumb + ENumb - 1;
            //排除最后一个子数组的index越界.
            if (right >= Array.Length - 1)
            {
                right = Array.Length - 1;
            }
            //排序两个子数组并拷贝到merge数组
            while (left <= middle && middleTwo <= right)
            {
                merge[mergeindex++] = Array[left] >= Array[middleTwo] ? Array[middleTwo++] : Array[left++];
            }
            //两个子数组中当中一个比較完了（Array[middleTwo++] 或Array[left++]）。
            //把当中一个数组中剩下的元素复制进merge数组。
            if (left <= middle)
            {
                //排除空元素.
                while (left <= middle && mergeindex < merge.Length)
                    merge[mergeindex++] = Array[left++];
            }
            if (middleTwo <= right)
            {
                while (middleTwo <= right)
                    merge[mergeindex++] = Array[middleTwo++];
            }
            //推断是否合并至最后一个子数组了
            if (right + 1 >= Array.Length)
                Copy(Array, merge);
        }

        /// <summary>
        /// 自然归并排序:
        ///      对于初始给定的数组,通常存在多个长度大于1的已自然排好序的子数组段.
        /// 比如,若数组a中元素为{4,8,3,7,1,5,6,2},则自然排好序的子数组段
        /// 有{4,8},{3,7},{1,5,6},{2}.
        /// 用一次对数组a的线性扫描就足以找出全部这些排好序的子数组段.
        /// 然后将相邻的排好序的子数组段两两合并,
        /// 构成更大的排好序的子数组段({3,4,7,8},{1,2,5,6}).
        /// 继续合并相邻排好序的子数组段,直至整个数组已排好序.
        /// 核心算法时间复杂度：
        ///        T(n)=○(n);
        /// </summary>
        public void NaturalMergeSort(int[] Array)
        {
            //得到自然划分后的数组的index组（每行为一个自然子数组）
            int[,] PointsSymbol = LinearPoints(Array);
            //子数组仅仅有一个。
            if (PointsSymbol[0, 1] == Array.Length - 1)
                return;
            //多个(至少两个子数组）...
            else
                //能够堆栈调用吗？
                NaturalMerge(Array, PointsSymbol);

        }
        public void NaturalMerge(int[] Array, int[,] PointsSymbol)
        {
            int left;
            int right;
            int leftend;
            int rightend;

            mergerows = GNumberTwo(Groups);
            CopyGroups = Groups;
            //固定状态
            int[] TempArray = new int[Array.Length];
            //循环取每一个自然子数组的index
            while (true)
            {
                // int Temprow = 1;
                //仅仅记录合并后的子数组(”《应该为》“动态的）  
                int[,] TempPointsSymbol = new int[mergerows, 2];

                int row = 0;
                do
                {
                    //最重要的推断：最后(一组子数组)是否可配对
                    if (row != CopyGroups - 1)
                    { //以上条件也能够含有(& 和&&的差别)短路运算
                        //參考:http://msdn.microsoft.com/zh-cn/library/2a723cdk(VS.80).aspx
                        left = PointsSymbol[row, 0];
                        leftend = PointsSymbol[row, 1];
                        right = PointsSymbol[row + 1, 0];
                        rightend = PointsSymbol[row + 1, 1];
                        MergeThree(Array, TempArray, left, leftend, right, rightend);
                        MergePointSymbol(PointsSymbol, TempPointsSymbol, row);
                    }
                    else
                    {
                        ////默认剩下的单独一个子数组已经虚拟合并。然后Copy进TempArray。
                        int TempRow = PointsSymbol[row, 0];
                        int TempCol = PointsSymbol[row, 1];
                        while (TempRow <= TempCol)
                            TempArray[TempRow] = Array[TempRow++];
                        //TempPointSymbol完整同步
                        TempPointsSymbol[row / 2, 0] = PointsSymbol[row, 0];
                        TempPointsSymbol[row / 2, 1] = PointsSymbol[row, 1];
                        break;//又一次開始新一轮循环。
                    }
                    row += 2;
                    // Temprow++;
                    //合并到仅仅有一个子数组时结束循环
                    if (TempPointsSymbol[0, 1] == Array.Length - 1)
                        break;
                }//推断别进入越界循环(能够进孤单循环）这里指的是PointsSymbol的子数组个数
                while (row <= CopyGroups - 1);
                //
                Copy(Array, TempArray);
                //更新子数组index，row为跳出循环的条件（最后单个子数组或下一个越界的第一个）
                UpdatePointSymbol(PointsSymbol, TempPointsSymbol, row);
                //改变TempPointsSymbol的行数（合并后子数组数）
                mergerows = GNumber(mergerows);
                CopyGroups = GNumberTwo(CopyGroups);
                //合并到仅仅有一个子数组时结束循环
                if (PointsSymbol[0, 1] == Array.Length - 1)
                    break;
            }
            //输出
        }
        public int GNumber(int Value)
        {
            if (Value % 2 == 0)
                Value /= 2;
            else
                Value -= 1;

            return Value;
        }
        public int GNumberTwo(int Value)
        {
            if (Value % 2 == 0)
                mergerows = Value / 2;
            else
                mergerows = Value / 2 + 1;
            return mergerows;
        }
        public void MergeThree(int[] Array, int[] Temp, int left, int leftend, int right, int rightend)
        {
            //合并语句
            int index = left;
            while (left <= leftend && right <= rightend)
                Temp[index++] = Array[left] >= Array[right] ? Array[right++] : Array[left++];
            while (left <= leftend)
                Temp[index++] = Array[left++];
            while (right <= rightend)
                Temp[index++] = Array[right++];
        }
        public void MergePointSymbol(int[,] PointsSymbol, int[,] TempPointsSymbol, int row)
        {
            int rowindex = row / 2;
            TempPointsSymbol[rowindex, 0] = PointsSymbol[row, 0];
            TempPointsSymbol[rowindex, 1] = PointsSymbol[row + 1, 1];
        }
        public void UpdatePointSymbol(int[,] PointsSymbol, int[,] TempPointsSymbol, int rows)
        {
            int row = 0;
            //if (mergerows % 2 == 0)
            //{
            for (; row < TempPointsSymbol.GetLength(0); row++)
            {
                for (int col = 0; col < 2; col++)
                    PointsSymbol[row, col] = TempPointsSymbol[row, col];
            }
            //后面的清零
            for (; row < PointsSymbol.GetLength(0); row++)
            {
                for (int col2 = 0; col2 < 2; col2++)
                    PointsSymbol[row, col2] = 0;
            }
            //}
            ////补剩下的index组，
            //else
            //{
            //    for (int row2 = 0; row2 < TempPointsSymbol.GetLength(0); row2++)
            //    {
            //        for (int col3 = 0; col3 < 2; col3++)
            //            PointsSymbol[row2, col3] = TempPointsSymbol[row2, col3];
            //    }
            //    //最后一个子数组的index仅仅有一个。

            //    int row3 = TempPointsSymbol.GetLength(0);
            //    PointsSymbol[row3, 0] = PointsSymbol[rows, 0];
            //    PointsSymbol[row3, 1] = PointsSymbol[rows, 1];
            //    //后面的清零
            //    for (int row4 = row3 + 1; row4 < PointsSymbol.GetLength(0); row4++)
            //    {
            //        for (int col4 = 0; col4 < 2; col4++)
            //            PointsSymbol[row4, col4] = 0;
            //    }
            //}

        }
        public int[,] LinearPoints(int[] Array)
        {
            Groups = 1;
            int StartPoint = 0;
            int row = 0;
            int col = 0;
            //最糟糕的情况就是有Array.Length行。
            int[,] PointsSet = new int[Array.Length, 2];
            //线性扫描Array，划分数组
            //初始前index=0
            PointsSet[row, col] = 0;
            do
            {
                //推断升序子数组终于的index开关
                bool Judge = false;
                //从Array第二个数推断是否要结束或者是否是升序子数组.
                while (++StartPoint < Array.Length && Array[StartPoint] < Array[StartPoint - 1])
                {
                    //打开第一个升序子数组结束的index开关
                    Judge = true;
                    //又一次開始第二个升序子数组的前index
                    PointsSet[row, col + 1] = StartPoint - 1;
                    //计算子数组个数
                    Groups++;
                    //换行记录自然子数组的index
                    row++;
                    break;
                    //--StartPoint;
                }
                //升序子数组结束index
                if (Judge)
                    PointsSet[row, col] = StartPoint;
                //else
                //    --StartPoint;
            } while (StartPoint < Array.Length);
            //终于index=StartPoint - 1，可是糟糕情况下还有剩余若干行为： 0,0 ...
            PointsSet[row, col + 1] = StartPoint - 1;
            //调用展示方法           
            DisplaySubarray(Array, PointsSet, Groups);
            return PointsSet;
        }
        public void DisplaySubarray(int[] Array, int[,] PointsSet, int Groups)
        {
            Console.WriteLine("Subarray is {0}:", Groups);
            //展示子数组的前后index
            for (int r = 0; r < Groups; r++)
            {
                for (int c = 0; c < PointsSet.GetLength(1); c++)
                {
                    Console.Write(PointsSet[r, c]);
                    if (c < PointsSet.GetLength(1) - 1)
                        Console.Write(",");
                }
                Console.Write("\t\t");
            }
            Console.WriteLine();
            //展示分出的子数组
            for (int v = 0; v < Groups; v++)
            {
                int i = 1;
                for (int r = PointsSet[v, 0]; r <= PointsSet[v, 1]; r++)
                {
                    Console.Write(Array[r] + " ");
                    i++;
                }
                if (i <= 3)
                    Console.Write("\t\t");
                else
                    Console.Write("\t");
                if (PointsSet[v, 1] == Array.Length)
                    break;
            }
        }

        public void Copy(int[] Array, int[] merge)
        {
            //一部分排好序的元素替换掉原来Array中的元素
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = merge[i];
            }
        }
        //输出
        public override string ToString()
        {
            string temporary = string.Empty;

            foreach (var element in Array27)
                temporary += element + " ";

            temporary += "\n";
            return temporary;
        }
    }
}
