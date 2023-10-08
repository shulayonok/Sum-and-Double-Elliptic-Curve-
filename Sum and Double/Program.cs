using System;

namespace Sum_and_Double
{
    class Program
    {
        static int[] Enter_1()
        {
            Console.Write("x:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y:");
            int y = Convert.ToInt32(Console.ReadLine());
            int[] Arr = { x, y };
            return Arr;
        }
        static int[] Enter_2()
        {
            Console.Write("a:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("mod:");
            int mod = Convert.ToInt32(Console.ReadLine());
            int[] Arr = { a, b, mod };
            return Arr;
        }
        static int Inverse(int num, int mod)
        {
            int c = 0;
            while ((num*c) % mod != 1 && c < mod)
            {
                c++;
            }
            return c;
        }
        static int Negative(int num, int mod)
        {
            num = Math.Abs(num);
            int del = -(num / mod) - 1;
            return -num - mod * del;
        }
        static int[] Sum(int[] a1, int[] a2, int[] a3)
        {
            int k = (a2[0] - a1[0]) > 0 ? ((a2[1] - a1[1]) * Inverse(a2[0] - a1[0], a3[2])) : ((-(a2[1] - a1[1])) * Inverse(-(a2[0] - a1[0]), a3[2]));
            k = k < 0 ? (Negative(k, a3[2]) % a3[2]) : (k % a3[2]);
            int x = (k * k - a1[0] - a2[0]);
            x = x < 0 ? (Negative(x, a3[2]) % a3[2]) : (x % a3[2]);
            int y = (k * (a1[0] - x) - a1[1]);
            y = y < 0 ? (Negative(y, a3[2]) % a3[2]) : (y % a3[2]);
            int[] answer = { x, y };
            return answer;
        }
        static int[] Double(int[] a, int[] A)
        {
            int k = (3 * a[0] * a[0] + A[0]) * Inverse(2 * a[1], A[2]);
            k = k < 0 ? (Negative(k, A[2]) % A[2]) : (k % A[2]);
            int x = (k * k - 2 * a[0]);
            x = x < 0 ? (Negative(x, A[2]) % A[2]) : (x % A[2]);
            int y = (k * (a[0] - x) - a[1]);
            y = y < 0 ? (Negative(y, A[2]) % A[2]) : (y % A[2]);
            int[] answer = { x, y };
            return answer;
        }
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.Write("Выберите вариант (1 - суммирование, 2 - удвоение): ");
                int choice;
                string ch = Console.ReadLine();
                if (Int32.TryParse(ch, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Первая точка");
                            int[] arr1 = Enter_1();
                            Console.WriteLine("Вторая точка");
                            int[] arr2 = Enter_1();
                            Console.WriteLine("Общее уравнение эллиптической кривой");
                            int[] arr3 = Enter_2();
                            Console.WriteLine("Сумма: " + "(" + Sum(arr1, arr2, arr3)[0].ToString() + ", " + Sum(arr1, arr2, arr3)[1].ToString() + ")");
                            flag = false;
                            break;
                        case 2:
                            Console.WriteLine("Точка");
                            int[] arr = Enter_1();
                            Console.WriteLine("Общее уравнение эллиптической кривой");
                            int[] ARR = Enter_2();
                            Console.WriteLine("Удвоение: "+ "(" + Double(arr, ARR)[0].ToString() + ", " + Double(arr, ARR)[1].ToString() + ")");
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Что - то пошло не так... Попробуйте ещё раз.");
                            break;
                    }
                }
                else
                    Console.WriteLine("Некорректный ввод... Попробуйте ещё раз.");                  
            }
        }
    }
}
