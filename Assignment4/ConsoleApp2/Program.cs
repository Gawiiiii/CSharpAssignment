using System;
using System.Threading;

public class Clock
{
    public event Action? Tick;
    public event Action? Alarm;

    private int alarmHour;
    private int alarmMinute;
    private int alarmSecond;

    public Clock(int hour, int minute, int second)
    {
        this.alarmHour = hour;
        this.alarmMinute = minute;
        this.alarmSecond = second;
    }

    public void start()
    {
        while(true)
        {
            Tick?.Invoke();
            DateTime now= DateTime.Now;
            if(now.Hour == alarmHour && now.Minute == alarmMinute && now.Second == alarmSecond)
            {
                Alarm?.Invoke();
            }
            Thread.Sleep(1000);
        }
    }
}

public class Progrm
{
    public static void Main(string[] args)
    {
        Console.WriteLine("闹钟程序启动......");

        DateTime now = DateTime.Now;
        int alarmHour = now.Hour, alarmMinute = now.Minute, alarmSecond = now.Second;
        if(alarmSecond + 30 >= 60)
        {
            alarmSecond = (alarmSecond + 30) % 60;
            if(alarmMinute + 1 >= 60)
            {
                alarmMinute = (alarmMinute + 1) % 60;
                alarmHour += 1;
            }
            else
            {
                alarmMinute += 1;
            }
        }
        else
        {
            alarmSecond += 30;
        }

        Console.WriteLine($"当前时间：{now:HH:mm:ss}");
        Console.WriteLine($"闹钟设定在：{alarmHour:D2}:{alarmMinute:D2}:{alarmSecond:D2}");
        Clock clock=new Clock(alarmHour, alarmMinute, alarmSecond);
        clock.Tick += () =>
        {
            Console.WriteLine($"滴答... 当前时间：{DateTime.Now:HH:mm:ss}");
        };
        clock.Alarm += () =>
        {
            Console.WriteLine("！！！闹钟响了！该起床啦！！！");
        };
        clock.start();
    }
}