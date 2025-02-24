using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice.Components
{
    internal class StepsView : AStepsView
    {
        //protected override Size StepSize => new Size(50, 15);

        protected override Font FontSytle => new Font("微軟正黑體", 10f);

        protected override FlowLayoutPanel RenderStep(StepModel step)
        {
            Label step1 = new Label();
            step1.Size = StepSize;
            step1.Text = step.title;
            step1.Font = new Font(FontSytle.FontFamily, 10f);
            step1.TextAlign = ContentAlignment.MiddleCenter;

            Label sbuStep1 = new Label();
            step1.Size = StepSize;
            sbuStep1.Text = step.description;
            sbuStep1.Font = new Font(FontSytle.FontFamily, 8f);
            sbuStep1.TextAlign = ContentAlignment.MiddleCenter;

            FlowLayoutPanel step1FlowOutPanel = new FlowLayoutPanel();
            step1FlowOutPanel.Size = new Size(StepSize.Width + 10, StepSize.Height * 2 + 10);

            step1FlowOutPanel.BorderStyle = BorderStyle.FixedSingle;
            step1FlowOutPanel.Controls.Add(step1);
            step1FlowOutPanel.Controls.Add(sbuStep1);

            return step1FlowOutPanel;
        }
    }
}
