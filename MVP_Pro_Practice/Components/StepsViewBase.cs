using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice.Components
{
    internal class StepsViewBase : BaseStepsView
    {
        protected override FlowLayoutPanel RenderStep(StepModel step)
        {
            Label step1 = new Label();
            step1.Width = 100;
            step1.Height = 30;
            step1.Text = step.title;
            step1.Font = new Font("微軟正黑體", 10f);
            step1.TextAlign = ContentAlignment.MiddleCenter;

            Label sbuStep1 = new Label();
            sbuStep1.Width = 100;
            sbuStep1.Height = 30;
            sbuStep1.Text = step.description;
            sbuStep1.Font = new Font("微軟正黑體", 8f);
            sbuStep1.TextAlign = ContentAlignment.MiddleCenter;

            FlowLayoutPanel step1FlowOutPanel = new FlowLayoutPanel();

            step1FlowOutPanel.Width = 110;
            step1FlowOutPanel.Height = 70;
            step1FlowOutPanel.BorderStyle = BorderStyle.FixedSingle;
            step1FlowOutPanel.Controls.Add(step1);
            step1FlowOutPanel.Controls.Add(sbuStep1);

            return step1FlowOutPanel;
        }
    }
}
