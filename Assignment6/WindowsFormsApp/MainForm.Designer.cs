using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Size = new System.Drawing.Size(200, 23);

            // btnQuery
            this.btnQuery.Location = new System.Drawing.Point(230, 18);
            this.btnQuery.Size = new System.Drawing.Size(80, 27);
            this.btnQuery.Text = "查询";

            // dgvOrders
            this.dgvOrders.Location = new System.Drawing.Point(20, 60);
            this.dgvOrders.Size = new System.Drawing.Size(740, 200);
            this.dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // dgvDetails
            this.dgvDetails.Location = new System.Drawing.Point(20, 270);
            this.dgvDetails.Size = new System.Drawing.Size(740, 150);
            this.dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 430);
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Text = "添加";

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(110, 430);
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.Text = "修改";

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(200, 430);
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.Text = "删除";

            // MainForm
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Text = "订单管理系统";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
