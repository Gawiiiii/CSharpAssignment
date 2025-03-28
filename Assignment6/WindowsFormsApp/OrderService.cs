using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// OrderService.cs
public class OrderService
{
    private List<Order> orders = new List<Order>();

    public List<Order> GetAllOrders() => orders;

    public void AddOrder(Order order) => orders.Add(order);

    public void RemoveOrder(string orderId)
    {
        var target = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (target != null) orders.Remove(target);
    }

    public void UpdateOrder(Order newOrder)
    {
        var index = orders.FindIndex(o => o.OrderId == newOrder.OrderId);
        if (index >= 0)
        {
            orders[index] = newOrder;
        }
    }

    public List<Order> QueryOrders(string keyword)
    {
        return orders
            .Where(o => o.OrderId.Contains(keyword) || o.Customer.Contains(keyword))
            .ToList();
    }
}

