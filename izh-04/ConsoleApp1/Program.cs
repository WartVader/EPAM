using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class Program
    {
        public static void ConsoleArray_int(int[] array)
        {
            int i = 0;
            while (i < array.Length)
            {
                Console.Write(array[i]);
                
                i++;
                if(i < array.Length)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
        public static void ConsoleArray_fl(float[] array)
        {
            int i = 0;
            while (i < array.Length)
            {
                Console.Write(array[i]);

                i++;
                if (i < array.Length)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }

        public static void ConsoleArray_double(double[] array)
        {
            int i = 0;
            while (i < array.Length)
            {
                Console.Write(array[i]);

                i++;
                if (i < array.Length)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }

        public static int[] int_RandomArray(int length = 5, int min = -10, int max = 10)
        {
            int[] array = new int[length];
            int i = 0;

            Random rand = new Random();
            while (i < length)
            {
                array[i] = rand.Next(min, max + 1);
                i++;
            }
            return array;
        }

        // 1
        public static int RecurMaxFinder(int[] arr, int i_max = 0, int i = 1) //i_max - индекс максимального числа
        {
            if (i <= arr.Length - 1)
            {
                if (arr[i_max] >= arr[i])
                {
                    return RecurMaxFinder(arr, i_max, i + 1);
                }
                else if (arr[i_max] < arr[i])
                {
                    return RecurMaxFinder(arr, i, i + 1);
                }
            }
            return arr[i_max];
        }

        //2
        public static int SumOfNum(int nums)
        {
            int sum = 0, div = 1, len = nums.ToString().Length;
            while(div.ToString().Length != len)
            {
                div *= 10;
            }
            while (len != 0)
            {
                sum += nums / div;
                nums -= (nums / div) * div;
                div /= 10;
                len--;
            }
            return sum;
        }

        public static int EqualSum(double[] arr)
        {
            int i = 0;
            while (i < arr.Length)
            {
                string[] num = arr[i].ToString().Split('.', ',');
                int l = Convert.ToInt32(num[0]);
                int r = Convert.ToInt32(num[1]);
                Console.WriteLine(l + " " + r);
                if (SumOfNum(l) == SumOfNum(r))
                    return i;
                i++;
            }
            return -1;
        }

        //3
        public static string Concat(string s1, string s2)
        {
            string result = s1 + " " + s2;
            result = new string(result.Distinct().ToArray());

            return result;
        }

        //4
        public static void Sort(ref int[] nums, int from = 0) //обычная сортировка пузырьковым методом, from - от куда будет сортировка
        {
            int buf = 0;
            for (int write = from; write < nums.Length; write++)
            {
                for (int sort = from; sort < nums.Length - 1; sort++)
                {
                    if (nums[sort] > nums[sort + 1])
                    {
                        buf = nums[sort + 1];
                        nums[sort + 1] = nums[sort];
                        nums[sort] = buf;
                    }
                }
            }

        }
        //5
        public static int FindNextBiggerNumber(int num)
        {
            int[] nums = num.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
            int length = nums.Length;
            string num_s = num.ToString();

            int result = 0;

            if (length == 1)
            {
                return -1;
            }
            int i = length - 1;
            while (i > 0)
            {
                if (nums[i] < nums[i - 1])
                {
                    i--;
                }
                else
                {
                    int min = 10, max = -1;
                    int j = length - 1, zero_index = -1, min_index = -1;
                    while (j >= i)
                    {
                        if (nums[j] < min && nums[i - 1] < nums[j] && nums[j] != 0)
                        {
                            min = nums[j];
                            min_index = j;
                        }
                        else if(nums[j] == 0)
                        {
                            zero_index = j;
                        }
                        if(nums[j] > max && nums[j] != 0)
                        {

                        }
                        j--;
                    }
                    if(min != 10)
                    {
                        nums[min_index] = nums[i - 1];
                        nums[i - 1] = min;
                    }
                    else
                    {
                        int buf = nums[i - 1];
                        nums[i - 1] = nums[i];
                        nums[i] = buf;
                    }
                    break;
                }
            }
            if(i != 0)
            {
                Sort(ref nums, i);
                i = length - 1;
                int inc = 1;
                while (i >= 0)
                {
                    result += nums[i--] * inc;
                    inc *= 10;
                }
                if (result == num)
                {
                    return -1;
                }
                return result;
            }

            return -1;
        }

        //6
        public static List<int> FilterDigit(int filter, int[] array)
        {
            int i = 0;
            
            List<int> filterArr = new List<int>();

            while (i < array.Length)
            {
                if(array[i].ToString().IndexOf(filter.ToString()) != -1)
                {
                    filterArr.Add(array[i]);
                }
                i++;
            }
            return filterArr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("1 >");
            Console.WriteLine();

            //1
            int[] int_array = int_RandomArray();
            ConsoleArray_int(int_array);
            Console.WriteLine(RecurMaxFinder(int_array));

            Console.WriteLine();
            Console.WriteLine("2 >");
            Console.WriteLine();

            //2
            double[] fl_arr = { 49.2, 35.36, 38.94, 45.37, 44.16, 35.41, 21.61, 27.89, 28.58, 34.82, 28.17, 9.27, 5.41, 37.19, 30.55, 29.23, 37.3, 15.71, 21.33, 13.25, 18.05, 13.61, 30.12, 23.14, 10.89, 26.24, 10.04, 15.75, 38.75, 4.01, 15.17, 23.89, 5.22, 43.34, 37.06, 3.04, 47.04, 40.42, 31, 15.31, 10.22, 40.34, 36.42, 4.05, 28.47, 29.61, 16.67, 5.99, 28.92, 43.35, 7.33, 46.36, 14.77, 4.66, 3.26, 25.13, 32.78, 6.94, 22.42, 18.88, 4.15, 38.17, 21.95, 33.69, 8.03, 16.45, 19.66, 19.92, 22, 45.47, 8.33, 43.63, 40.46, 32.27, 43.01, 37.07, 39.08, 42.76, 32.63, 35.82, 38.75, 17.93, 7.82, 29.3, 33.04, 33.17, 37.29, 26.2, 43.23, 31.5, 11.73, 42.44, 6.11, 2.81, 1.43, 21.72, 38.86, 16.75, 26.05, 36.74, 18.63, 20, 8.48, 45.89, 38.02, 33.4, 0.01};
            Console.WriteLine(fl_arr[2]);
            ConsoleArray_double(fl_arr);

            Console.WriteLine(EqualSum(fl_arr));
            Console.WriteLine(fl_arr[EqualSum(fl_arr)]);
            Console.WriteLine();
            Console.WriteLine("3 >");
            Console.WriteLine();
            //3
            Console.WriteLine(Concat("hello", "world!"));

            Console.WriteLine();
            Console.WriteLine("4 >");
            Console.WriteLine();
            //4
            Console.WriteLine(FindNextBiggerNumber(17654320));

            Console.WriteLine();
            Console.WriteLine("5 (6) >");
            Console.WriteLine();
            //5 (6)???
            int[] arr = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            var a1 = FilterDigit(7, arr);
            var a2 = FilterDigit(7, arr);
            
            Console.WriteLine(a1.SequenceEqual(a2));
            ConsoleArray_int(a1.ToArray());
            ConsoleArray_int(a2.ToArray());

            Console.ReadKey();
        }
    }
}
