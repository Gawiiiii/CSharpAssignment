using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblCustomer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();

            // lblOrderId
            this.lblOrderId.Location = new System.Drawing.Point(20, 20);
            this.lblOrderId.Size = new System.Drawing.Size(60, 23);
            this.lblOrderId.Text = "订单号";

            // txtOrderId
            this.txtOrderId.Location = new System.Drawing.Point(90, 20);
            this.txtOrderId.Size = new System.Drawing.Size(200, 23);

            // lblCustomer
            this.lblCustomer.Location = new System.Drawing.Point(20, 60);
            this.lblCustomer.Size = new System.Drawing.Size(60, 23);
            this.lblCustomer.Text = "客户";

            // txtCustomer
            this.txtCustomer.Location = new System.Drawing.Point(90, 60);
            this.txtCustomer.Size = new System.Drawing.Size(200, 23);

            // dgvDetails
            this.dgvDetails.Location = new System.Drawing.Point(20, 100);
            this.dgvDetails.Size = new System.Drawing.Size(460, 200);
            this.dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(290, 320);
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.Text = "确定";
            this.btnOK.DialogResult = DialogResult.OK;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(400, 320);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Text = "取消";
            this.btnCancel.DialogResult = DialogResult.Cancel;

            // OrderEditForm
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Text = "订单编辑";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
