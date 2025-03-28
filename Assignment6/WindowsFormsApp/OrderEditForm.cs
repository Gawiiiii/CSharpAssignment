using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OrderEditForm : Form
    {
        private BindingSource detailBindingSource = new BindingSource();
        public Order EditedOrder { get; private set; }

        public OrderEditForm(Order order = null)
        {
            InitializeComponent();

            if (order == null)
            {
                EditedOrder = new Order();
            }
            else
            {
                // 深拷贝，防止修改原始数据
                EditedOrder = new Order
                {
                    OrderId = order.OrderId,
                    Customer = order.Customer,
                    OrderDetails = order.OrderDetails
                        .Select(d => new OrderDetail
                        {
                            ProductName = d.ProductName,
                            Quantity = d.Quantity,
                            UnitPrice = d.UnitPrice
                        }).ToList()
                };
            }

            txtOrderId.Text = EditedOrder.OrderId;
            txtCustomer.Text = EditedOrder.Customer;

            detailBindingSource.DataSource = EditedOrder.OrderDetails;
            dgvDetails.DataSource = detailBindingSource;

            btnOK.Click += (s, e) =>
            {
                EditedOrder.OrderId = txtOrderId.Text.Trim();
                EditedOrder.Customer = txtCustomer.Text.Trim();
                this.DialogResult = DialogResult.OK;
            };
        }
    }
}
