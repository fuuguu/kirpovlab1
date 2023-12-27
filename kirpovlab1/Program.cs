using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int a = 24;
        int b = 36;

        Thread thread1 = new Thread(() =>
        {
            int gcd = CalculateGCD(a, b);
            Console.WriteLine("Наибольший общий делитель: " + gcd);
        });

        Thread thread2 = new Thread(() =>
        {
            int gcd = CalculateGCD(a, b);
            int p = a / gcd;
            int q = b / gcd;
            Console.WriteLine("Сокращенная дробь: " + p + "/" + q);
        });
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }

    static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}