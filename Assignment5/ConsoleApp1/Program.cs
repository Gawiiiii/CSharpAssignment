using System;
using System.Collections.Generic;
using System.Linq;
public class Order
{
    public string OrderId { get; set; }
    public string Customer { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    // 计算订单总金额
    public decimal TotalAmount
    {
        get
        {
            decimal total = 0;
            foreach (var detail in OrderDetails)
            {
                total += detail.TotalPrice;
            }
            return total;
        }
    }

    // 重写Equals方法，避免订单重复
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var otherOrder = (Order)obj;
        return OrderId == otherOrder.OrderId; // 以OrderId为唯一标识
    }

    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }//重写Equals函数时一般也需要重写该函数，因为自带的排序算法依赖哈希比较

    public override string ToString()
    {
        return $"OrderId: {OrderId}, Customer: {Customer}, TotalAmount: {TotalAmount:C}";
    }
}

public class OrderDetail
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    // 计算单个商品的总价
    public decimal TotalPrice => UnitPrice * Quantity;

    // 重写Equals方法，确保每个订单明细唯一
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var otherDetail = (OrderDetail)obj;
        return ProductName == otherDetail.ProductName && UnitPrice == otherDetail.UnitPrice;
    }

    public override int GetHashCode()
    {
        return (ProductName + UnitPrice).GetHashCode();
    }

    public override string ToString()
    {
        return $"{ProductName} - {UnitPrice:C} x {Quantity} = {TotalPrice:C}";
    }
}

public class OrderService
{
    private List<Order> _orders = new List<Order>();

    // 添加订单
    public void AddOrder(Order order)
    {
        if (!_orders.Contains(order))
        {
            _orders.Add(order);
        }
        else
        {
            throw new InvalidOperationException("Order with the same OrderId already exists.");
        }
    }

    // 删除订单
    public void RemoveOrder(string orderId)
    {
        var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
        {
            throw new InvalidOperationException("Order not found.");
        }
        _orders.Remove(order);
    }

    // 修改订单
    public void UpdateOrder(string orderId, Order updatedOrder)
    {
        var existingOrder = _orders.FirstOrDefault(o => o.OrderId == orderId);
        if (existingOrder == null)
        {
            throw new InvalidOperationException("Order not found.");
        }

        existingOrder.Customer = updatedOrder.Customer;
        existingOrder.OrderDetails = updatedOrder.OrderDetails;
    }

    // 查询订单
    public List<Order> QueryOrders(string searchKey)
    {
        var result = _orders.Where(o =>
            o.OrderId.Contains(searchKey) ||
            o.Customer.Contains(searchKey) ||
            o.OrderDetails.Any(d => d.ProductName.Contains(searchKey))
        )
        .OrderBy(o => o.TotalAmount)
        .ToList();

        return result;
    }

    // 根据Lambda表达式排序，传参是一个委托，接受Order返回一个可用于排序的关键字，后面根据该关键字进行排序
    public void SortOrders<T>(Func<Order, T> orderBy)
    {
        _orders = _orders.OrderBy(orderBy).ToList();
    }

    // 显示所有订单
    public void DisplayOrders()
    {
        foreach (var order in _orders)
        {
            Console.WriteLine(order.ToString());
            foreach (var detail in order.OrderDetails)
            {
                Console.WriteLine("\t" + detail.ToString());
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        OrderService orderService = new OrderService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Order Management System");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Remove Order");
            Console.WriteLine("3. Update Order");
            Console.WriteLine("4. Query Orders");
            Console.WriteLine("5. Display All Orders");
            Console.WriteLine("6. Sort Orders");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddOrder(orderService);
                        break;
                    case "2":
                        RemoveOrder(orderService);
                        break;
                    case "3":
                        UpdateOrder(orderService);
                        break;
                    case "4":
                        QueryOrders(orderService);
                        break;
                    case "5":
                        orderService.DisplayOrders();
                        break;
                    case "6":
                        SortOrders(orderService);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void AddOrder(OrderService orderService)
    {
        Console.Write("Enter Order ID: ");
        string orderId = Console.ReadLine();
        Console.Write("Enter Customer Name: ");
        string customer = Console.ReadLine();

        Order order = new Order { OrderId = orderId, Customer = customer };

        Console.Write("How many items in the order? ");
        int itemCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < itemCount; i++)
        {
            Console.Write($"Enter Product Name for item {i + 1}: ");
            string productName = Console.ReadLine();
            Console.Write($"Enter Unit Price for {productName}: ");
            decimal unitPrice = decimal.Parse(Console.ReadLine());
            Console.Write($"Enter Quantity for {productName}: ");
            int quantity = int.Parse(Console.ReadLine());

            OrderDetail detail = new OrderDetail { ProductName = productName, UnitPrice = unitPrice, Quantity = quantity };
            order.OrderDetails.Add(detail);
        }

        orderService.AddOrder(order);
    }

    static void RemoveOrder(OrderService orderService)
    {
        Console.Write("Enter Order ID to remove: ");
        string orderId = Console.ReadLine();
        orderService.RemoveOrder(orderId);
        Console.WriteLine("Order removed successfully.");
    }

    static void UpdateOrder(OrderService orderService)
    {
        Console.Write("Enter Order ID to update: ");
        string orderId = Console.ReadLine();

        Console.Write("Enter new Customer Name: ");
        string customer = Console.ReadLine();

        Order updatedOrder = new Order { OrderId = orderId, Customer = customer };

        Console.Write("How many items in the updated order? ");
        int itemCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < itemCount; i++)
        {
            Console.Write($"Enter Product Name for item {i + 1}: ");
            string productName = Console.ReadLine();
            Console.Write($"Enter Unit Price for {productName}: ");
            decimal unitPrice = decimal.Parse(Console.ReadLine());
            Console.Write($"Enter Quantity for {productName}: ");
            int quantity = int.Parse(Console.ReadLine());

            OrderDetail detail = new OrderDetail { ProductName = productName, UnitPrice = unitPrice, Quantity = quantity };
            updatedOrder.OrderDetails.Add(detail);
        }

        orderService.UpdateOrder(orderId, updatedOrder);
        Console.WriteLine("Order updated successfully.");
    }

    static void QueryOrders(OrderService orderService)
    {
        Console.Write("Enter search keyword (Order ID, Customer, or Product Name): ");
        string searchKey = Console.ReadLine();
        var orders = orderService.QueryOrders(searchKey);
        foreach (var order in orders)
        {
            Console.WriteLine(order.ToString());
            foreach (var detail in order.OrderDetails)
            {
                Console.WriteLine("\t" + detail.ToString());
            }
        }
    }

    static void SortOrders(OrderService orderService)
    {
        Console.Write("Enter sorting criteria (1 for OrderId, 2 for TotalAmount): ");
        int sortBy = int.Parse(Console.ReadLine());

        if (sortBy == 1)
        {
            orderService.SortOrders(o => o.OrderId);
        }
        else if (sortBy == 2)
        {
            orderService.SortOrders(o => o.TotalAmount);
        }

        Console.WriteLine("Orders sorted successfully.");
    }
}

