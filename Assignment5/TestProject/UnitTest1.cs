using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp1;

namespace TestProject
{
    [TestClass]
    public class OrderServiceTests
    {
        private OrderService? _orderService;

        [TestInitialize]
        public void Setup()
        {
            _orderService = new OrderService();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddOrder_ShouldThrowException_WhenOrderIdExists()
        {
            var order = new Order { OrderId = "001", Customer = "Alice" };
            _orderService.AddOrder(order);
            _orderService.AddOrder(order); // Should throw exception
        }

        [TestMethod]
        public void RemoveOrder_ShouldRemoveExistingOrder()
        {
            var order = new Order { OrderId = "002", Customer = "Bob" };
            _orderService.AddOrder(order);
            _orderService.RemoveOrder("002");

            var result = _orderService.QueryOrders("002");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void QueryOrders_ShouldReturnSortedOrders()
        {
            var order1 = new Order { OrderId = "003", Customer = "Charlie" };
            order1.OrderDetails.Add(new OrderDetail { ProductName = "Product1", UnitPrice = 10, Quantity = 2 });
            _orderService.AddOrder(order1);

            var order2 = new Order { OrderId = "004", Customer = "David" };
            order2.OrderDetails.Add(new OrderDetail { ProductName = "Product2", UnitPrice = 20, Quantity = 1 });
            _orderService.AddOrder(order2);

            var orders = _orderService.QueryOrders("");
            Assert.AreEqual(2, orders.Count);
            Assert.AreEqual("003", orders[0].OrderId);
        }
    }
}