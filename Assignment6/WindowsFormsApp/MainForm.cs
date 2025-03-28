using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private OrderService _orderService = new OrderService();
        private BindingSource orderBindingSource = new BindingSource();
        private BindingSource detailBindingSource = new BindingSource();

        public MainForm()
        {
            InitializeComponent();

            orderBindingSource.DataSource = _orderService.GetAllOrders();
            detailBindingSource.DataSource = orderBindingSource;
            detailBindingSource.DataMember = "OrderDetails";

            dgvOrders.DataSource = orderBindingSource;
            dgvDetails.DataSource = detailBindingSource;

            btnQuery.Click += (s, e) =>
            {
                orderBindingSource.DataSource = _orderService.QueryOrders(txtSearch.Text.Trim());
            };

            btnAdd.Click += (s, e) =>
            {
                var editForm = new OrderEditForm();
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _orderService.AddOrder(editForm.EditedOrder);
                    orderBindingSource.DataSource = _orderService.GetAllOrders();
                }
            };

            btnEdit.Click += (s, e) =>
            {
                if (orderBindingSource.Current is Order order)
                {
                    var editForm = new OrderEditForm(order);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        _orderService.UpdateOrder(editForm.EditedOrder);
                        orderBindingSource.DataSource = _orderService.GetAllOrders();
                    }
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (orderBindingSource.Current is Order order)
                {
                    _orderService.RemoveOrder(order.OrderId);
                    orderBindingSource.DataSource = _orderService.GetAllOrders();
                }
            };
        }
    }
}


