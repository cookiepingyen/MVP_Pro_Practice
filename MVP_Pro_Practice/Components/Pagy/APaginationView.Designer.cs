namespace MVP_Pro_Practice.Components.Pagy
{
    partial class APaginationView
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRight = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // labelLeft
            // 
            this.labelLeft.AutoSize = true;
            this.labelLeft.Location = new System.Drawing.Point(32, 23);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(23, 15);
            this.labelLeft.TabIndex = 0;
            this.labelLeft.Text = "<<";
            // 
            // labelRight
            // 
            this.labelRight.AutoSize = true;
            this.labelRight.Location = new System.Drawing.Point(544, 23);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(23, 15);
            this.labelRight.TabIndex = 1;
            this.labelRight.Text = ">>";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(66, 14);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(472, 37);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // IPagination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelRight);
            this.Controls.Add(this.labelLeft);
            this.Name = "IPagination";
            this.Size = new System.Drawing.Size(626, 67);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label labelRight;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
