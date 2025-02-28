using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Program
{
    //1. 输出指定数字的所有素数因子
    public static void PrimeFactors(int n)
    {
        List<int> factors = new();

        //处理因子2
        while (n % 2 == 0)
        {
            factors.Add(2);
            n /= 2;
        }

        //处理奇数因子
        for(int divisor = 3; divisor * divisor <= n; divisor += 2)
        {
            while(n % divisor == 0)
            {
                factors.Add(divisor);
                n /= divisor;
            }
        }

        //处理自身
        if (n > 1)
        {
            factors.Add(n);
        }

        Console.Write(n + " 的素数因子有：");
        foreach(var factor in factors)
        {
            Console.Write(factor + " ");
        }
        Console.WriteLine();
    }

    //2. 求整数数组的最大值、最小值、平均值、和
    public static void ArrayStatistics(int[] nums)
    {
        int max =nums.Max();
        int min = nums.Min();
        double average = nums.Average();
        int sum = nums.Sum();

        Console.WriteLine($"最大值：{max} 最小值：{min} 平均值：{average} 和：{sum}");
    }

    //3. 埃氏筛法求2-100的素数
    public static void SieveOfEratorsthenese(int limit)
    {
        bool[] isPrime = new bool[limit + 1];
        for(int i = 2; i <= limit; i++)
        {
            isPrime[i] = true;
        }

        for(int i = 2; i * i <= limit; i++)
        {
            if (isPrime[i])
            {
                for(int j = i * i; j <= limit; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        Console.Write($"2-{limit}之间的素数有：");
        for(int i = 2; i <= limit; i++)
        {
            if (isPrime[i])
            {
                Console.Write(i+" ");
            }
        }
        Console.WriteLine();
    }

    //4. 判断给定矩阵是否是托普利茨矩阵
    public static void IsToeplitzMatrix(int[,] matrix)
    {
        int rows=matrix.GetLength(0);
        int cols=matrix.GetLength(1);

        for(int i = 0; i < rows - 1; i++)
        {
            for(int j=0;j<cols - 1; j++)
            {
                if (matrix[i,j] != matrix[i + 1, j + 1])
                {
                    Console.WriteLine("否");
                    return;
                }
            }
        }

        Console.WriteLine("是");
    }

    //主函数
    public static void Main(string[] args)
    {
        bool isNumberValid = false;
        while (!isNumberValid)
        {
            Console.Write("请输入问题编号（1、2、3、4）,5为退出：");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.Write("1. 输出指定数字的所有素数因子:");
                    int num = int.Parse(Console.ReadLine());
                    PrimeFactors(num);
                    isNumberValid = false;
                    break;
                case 2:
                    Console.WriteLine("2. 求整数数组的最大值、最小值、平均值、和:");
                    Console.Write("数组长度：");
                    int len = int.Parse(Console.ReadLine());
                    int[] numbers = new int[len];
                    for(int i = 0; i < len; i++)
                    {
                        Console.Write($"输入第{i + 1}个数字：");
                        numbers[i]= int.Parse(Console.ReadLine()); 
                    }
                    ArrayStatistics(numbers);
                    isNumberValid = false;
                    break;
                case 3:
                    Console.WriteLine("3. 埃氏筛法求2-100的素数");
                    SieveOfEratorsthenese(100);
                    isNumberValid = false;
                    break;
                case 4:
                    Console.WriteLine("4. 判断给定矩阵是否是托普利茨矩阵:");
                    int[,] matrix =
                    {
                        {1,2,3,4 },
                        {5,1,2,3 },
                        {9,5,1,2 }
                    };
                    IsToeplitzMatrix(matrix);
                    isNumberValid = false;
                    break;
                case 5:
                    isNumberValid = true;
                    break;
                default:
                    Console.WriteLine("输入题号无效！重新输入。。。");
                    isNumberValid = false;
                    break;
            }
        }
    }
}
