using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Order.cs
public class Order
{
    public string OrderId { get; set; }
    public string Customer { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

