using System;
//链表节点
public class Node<T>
{
    public Node<T> Next { get; set; }
    public T Data { get; set; }
    public Node(T t)
    {
        Next = null;
        Data = t;
    }
}

//泛型链表类
public class GenericList<T>
{
    private Node<T> head;
    private Node<T> tail;
    public GenericList()
    {
        tail = head = null;
    }
    public Node<T> Head
    {
        get => head;
    }
    public void Add(T t)
    {
        Node<T> n=new Node<T>(t);   
        if(tail==null)
        {
            head = tail = n;
        }
        else
        {
            tail.Next = n;
            tail = n;
        }
    }

    public void forEach(Action<T> action)
    {
        Node<T> current = head;
        while(current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        GenericList<int> intlist = new GenericList<int>();
        Console.Write("创建GenericList<int>：");
        for(int i = 0; i < 10; i++)
        {
            int cur = Random.Shared.Next(0,100001);
            intlist.Add(cur);
            Console.Write($"{cur}");
            if(i<9)
            {
                Console.Write(", ");
            }
            else
            {
                Console.WriteLine();
            }
        }
        //打印链表元素
        intlist.forEach(item=>Console.Write($"{item} "));
        Console.WriteLine();

        //求最大值
        int mx = int.MinValue;
        intlist.forEach(item =>
        {
            if (item > mx) mx = item;
        });
        Console.WriteLine($"最大值：{mx}");

        //求最小值
        int mi=int.MaxValue;
        intlist.forEach(item =>
        {
            if (item < mi) mi = item;
        });
        Console.WriteLine($"最小值：{mi}");

        //求和
        int sum = 0;
        intlist.forEach(item => sum += item);
        Console.WriteLine($"和：{sum}");

        Console.Read();
    }
}