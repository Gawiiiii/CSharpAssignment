using System;

class Calculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("欢迎使用计算器！");
        Console.Write("请输入第一个数字：");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("请输入运算符（+、-、*、/）：");
        char ch = Console.ReadKey().KeyChar;
        Console.WriteLine();
        Console.Write("请输入第二个数字：");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double res = 0;
        bool isValid = true;

        switch (ch)
        {
            case '+':
                res = num1 + num2;
                break;
            case '-':
                res = num1 - num2;
                break;
            case '*':
                res = num1 * num2;
                break;
            case '/':
                if(num2==0)
                {
                    Console.WriteLine("除数不能为0！");
                    isValid = false;
                }
                else
                {
                    res = num1 / num2;
                }
                break;
            default:
                Console.WriteLine("运算符不合要求！");
                isValid = false;
                break;
        }
        if (isValid)
        {
            Console.WriteLine($"计算结果：{num1} {ch} {num2} = {res}");
        }
        Console.ReadKey();
    }
}