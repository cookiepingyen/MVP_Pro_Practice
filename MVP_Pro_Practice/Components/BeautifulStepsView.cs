using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice.Components
{
    internal class BeautifulStepsView : AStepsView
    {
        protected override Font FontSytle => new Font("微軟正黑體", 10f);

        public BeautifulStepsView()
        {
            Direction = "Vertical";
        }

        protected override FlowLayoutPanel RenderStep(StepModel step)
        {
            Label step1 = new Label();
            step1.AutoSize = true; // 自動調整大小
            step1.Text = step.title;
            step1.Font = new Font(FontSytle.FontFamily, 10f, FontStyle.Bold); // 標題加粗
            step1.TextAlign = ContentAlignment.MiddleCenter;
            step1.Margin = new Padding(5, 5, 5, 2); // 增加間距
            step1.ForeColor = Color.White; // 文字顏色
            step1.BackColor = Color.FromArgb(70, 130, 180); // 設定背景色（柔和藍色）
            step1.Padding = new Padding(8); // 內邊距

            Label sbuStep1 = new Label();
            sbuStep1.AutoSize = true;
            sbuStep1.Text = step.description;
            sbuStep1.Font = new Font(FontSytle.FontFamily, 8f, FontStyle.Regular);
            sbuStep1.TextAlign = ContentAlignment.MiddleCenter;
            sbuStep1.Margin = new Padding(5, 2, 5, 5);
            sbuStep1.ForeColor = Color.Black;
            sbuStep1.Padding = new Padding(6);

            FlowLayoutPanel step1FlowOutPanel = new FlowLayoutPanel();
            step1FlowOutPanel.AutoSize = true; // 自動適應內容大小
            step1FlowOutPanel.Padding = new Padding(10);
            step1FlowOutPanel.Margin = new Padding(10);
            step1FlowOutPanel.FlowDirection = FlowDirection.TopDown; // 讓標題和描述垂直排列
            step1FlowOutPanel.BorderStyle = BorderStyle.FixedSingle;
            step1FlowOutPanel.BackColor = Color.WhiteSmoke; // 背景色讓 UI 更柔和

            // 圓角邊框（需要在 Panel 上加載 Paint 事件）
            step1FlowOutPanel.Paint += (sender, e) =>
            {
                Control panel = (Control)sender;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 15;
                    Rectangle bounds = panel.ClientRectangle;
                    path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                    path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                    path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(Color.Gray, 2))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            step1FlowOutPanel.Controls.Add(step1);
            step1FlowOutPanel.Controls.Add(sbuStep1);

            return step1FlowOutPanel;
        }

    }
}
