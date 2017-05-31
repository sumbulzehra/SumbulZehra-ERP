namespace WindowsFormsApplication1
{
    partial class myconnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.conn = new System.Data.OleDb.OleDbConnection();
            this.SuspendLayout();
            // 
            // conn
            // 
            this.conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Khalid Sahab\\Downloads\\ER" +
    "P\\ERP\\PC_DB.accdb\"";
            // 
            // myconnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "myconnection";
            this.Text = "myconnection";
            this.Load += new System.EventHandler(this.myconnection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Data.OleDb.OleDbConnection conn;

    }
}