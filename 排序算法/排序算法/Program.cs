using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 排序算法.算法类;

namespace 排序算法
{
    enum sortType
    {
        SelectionSorter,
        EbullitionSorter
    }
    class Program
    {  
        static void Main(string[] args)
        {
            Console.WriteLine("请选择算法：");
            Console.WriteLine("1.选择排序");
            Console.WriteLine("2.冒泡排序");
            Console.WriteLine("3.高速排序");
            Console.WriteLine("4.插入排序");
            Console.WriteLine("5.希尔排序");
            Console.WriteLine("6.归并排序");
            Console.WriteLine("7.基数排序");
            Console.WriteLine("8.计数排序");
            Console.WriteLine("9.堆排序"); 
            Console.WriteLine("0.退出");
            int type = Convert.ToInt32(Console.ReadLine());
            string typename = "";
            switch(type)
            {
                case 1://选择排序
                    typename = "选择排序";
                    break;
                case 2://冒泡排序
                    typename = "冒泡排序";
                    break;
                case 3://高速排序
                    typename = "高速排序";
                    break;
                case 4://插入排序
                    typename = "插入排序";
                    break;
                case 5://希尔排序
                    typename = "希尔排序";
                    break;
                case 6://归并排序
                    typename = "归并排序";
                    break;
                case 7://基数排序
                    typename = "基数排序";
                    break;
                case 8://计数排序
                    typename = "计数排序";
                    break;
                case 9://堆排序
                    typename = "堆排序";
                    break;
                default:
                    typename = "您未选择算法";
                    break;

            }
            Console.WriteLine("您选择了{0}.{1}:",type,typename);
            int[] arrInt = new int[] { 4, 2, 7, 1, 8, 3, 9, 0, 5, 6 };
            int[] intArray = new int[] { 5, 3, 7, 4, 8, 2, 9, 1, 0, 6 };
            int[] newIntArray = intArray;
            switch (type)
            {
                case 1://选择排序 
                    SelectionSorter selSor = new SelectionSorter();
                    selSor.Sort(arrInt);
                    foreach (int i in arrInt)
                    {
                        Console.WriteLine(i);
                    }
                    Console.ReadKey();
                    break;
                case 2://冒泡排序 
                    EbullitionSorter ebuSor = new EbullitionSorter();
                    ebuSor.Sort(arrInt);
                    foreach (int i in arrInt)
                    {
                        Console.WriteLine(i);
                    }
                    Console.ReadKey();
                    break;
                case 3://高速排序
                    QuickSorter quiSor = new QuickSorter();
                    quiSor.Sort(arrInt, 0, arrInt.Length - 1);
                    foreach (int i in arrInt)
                    {
                        Console.WriteLine(i);
                    }
                    Console.ReadKey();
                    break;
                case 4://插入排序
                    InsertionSorter insSor = new InsertionSorter();
                    insSor.Sort(arrInt);
                    foreach (int i in arrInt)
                    {
                        Console.WriteLine(i);
                    }
                    Console.ReadKey();
                    break;
                case 5://希尔排序
                    ShellSorter sheSor = new ShellSorter();
                    sheSor.Sort(arrInt);
                    foreach (int i in arrInt)
                    {
                        Console.WriteLine(i);
                    }
                    Console.ReadKey();
                    break;
                case 6://归并排序
                    while (true)
                    {
                        Console.WriteLine("请选择：");
                        Console.WriteLine("1.归并排序（非递归）");
                        Console.WriteLine("2.归并排序（递归）");
                        Console.WriteLine("3.归并排序（自然合并）");
                        Console.WriteLine("4.退出");
                        int Arraynum = Convert.ToInt32(Console.ReadLine());
                        switch (Arraynum)
                        {
                            case 4:
                                Environment.Exit(0);
                                break;
                            case 1:
                                Console.WriteLine("Please Input Array Length");
                                int Leng271 = Convert.ToInt32(Console.ReadLine());
                                Function obj1 = new Function(Leng271);

                                Console.WriteLine("The original sequence:");
                                Console.WriteLine(obj1);
                                Console.WriteLine("'MergeSort' Finaly Sorting Result:");
                                obj1.ToMergeSort();
                                Console.WriteLine(obj1);
                                break;
                            case 2:
                                Console.WriteLine("Please Input Array Length");
                                int Leng272 = Convert.ToInt32(Console.ReadLine());
                                Function obj2 = new Function(Leng272);

                                Console.WriteLine("The original sequence:");
                                Console.WriteLine(obj2);
                                Console.WriteLine("'RecursiveMergeSort' Finaly Sorting Result:");
                                obj2.ToRecursiveMergeSort();
                                Console.WriteLine(obj2);
                                break;
                            case 3:
                                Console.WriteLine("Please Input Array Length");
                                int Leng273 = Convert.ToInt32(Console.ReadLine());
                                Function obj3 = new Function(Leng273);

                                Console.WriteLine("The original sequence:");
                                Console.WriteLine(obj3);
                                obj3.ToNaturalMergeSort();
                                Console.WriteLine(); Console.WriteLine();
                                Console.WriteLine("'NaturalMergeSort' Finaly Sorting Result:");
                                Console.WriteLine(obj3);
                                break;
                        }
                    }
                   
                case 7://基数排序
                    RadixSorter rS = new RadixSorter();
                    newIntArray = rS.RadixSort(intArray, intArray.Length);
                    foreach (int i in intArray)
                    {
                        Console.Write(i + " ");
                    }
                    Console.ReadKey();
                    break;
                case 8://计数排序
                 
                    int[] intNewArray = intArray;
                    intNewArray = Counting.CountingSort(intArray, intArray.Length);
                    foreach (int i in intNewArray)
                    {
                        Console.Write(i + " ");
                    }
                    Console.ReadKey();
                    break;
                case 9://堆排序
                    HeapSort.HeapSortFunction(intArray);
                    foreach (int i in intArray)
                    {
                        Console.Write(i + " ");
                    }
                    Console.ReadKey();
                    break;
                default :
                    Environment.Exit(0);
                    break;
            }
           
        }
    }
}
