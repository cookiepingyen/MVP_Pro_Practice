﻿using MVP_Pro_Practice.Components;

namespace MVP_Pro_Practice
{
    partial class Form1
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.stepComponent1 = new MVP_Pro_Practice.Components.StepsView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stepComponent1
            // 
            this.stepComponent1.Direction = "Horizontal";
            this.stepComponent1.Location = new System.Drawing.Point(5, 12);
            this.stepComponent1.Name = "stepComponent1";
            this.stepComponent1.Size = new System.Drawing.Size(827, 315);
            this.stepComponent1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 630);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stepComponent1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private StepsView stepComponent1;
        private System.Windows.Forms.Button button1;
    }
}

