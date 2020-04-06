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
        // 2
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

        //3
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
                int r;
                try
                {
                    r = Convert.ToInt32(num[1]);
                }
                catch
                {
                    return -1;
                }
                Console.WriteLine(l + " " + r);
                if (SumOfNum(l) == SumOfNum(r))
                    return i;
                i++;
            }
            return -1;
        }

        //4
        public static string Concat(string s1, string s2)
        {
            string result = s1 + " " + s2;
            result = new string(result.Distinct().ToArray());

            return result;
        }

        //5
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
            //1
            Console.WriteLine();
            Console.WriteLine("1 >");
            Console.WriteLine();
            Console.WriteLine("...");


            Console.WriteLine();
            Console.WriteLine("2 >");
            Console.WriteLine();

            //2
            int[] int_array = int_RandomArray();
            ConsoleArray_int(int_array);
            Console.WriteLine(RecurMaxFinder(int_array));

            Console.WriteLine();
            Console.WriteLine("3 >");
            Console.WriteLine();

            //3
            double[] fl_arr = { 0, 1, 2, 3};
            Console.WriteLine(fl_arr[2]);
            ConsoleArray_double(fl_arr);

            Console.WriteLine(EqualSum(fl_arr));
            
            Console.WriteLine();
            Console.WriteLine("4 >");
            Console.WriteLine();
            //4
            Console.WriteLine(Concat("hello", "world!"));

            Console.WriteLine();
            Console.WriteLine("5 >");
            Console.WriteLine();
            //5
            Console.WriteLine(FindNextBiggerNumber(17654320));

            Console.WriteLine();
            Console.WriteLine("6 >");
            Console.WriteLine();
            //6
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
