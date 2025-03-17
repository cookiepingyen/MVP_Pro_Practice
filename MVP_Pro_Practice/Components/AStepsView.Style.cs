using MVP_Pro_Practice.Contracts;
using MVP_Pro_Practice.Models.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice
{
    partial class AStepsView
    {
        public virtual string Direction { get; set; } = "Horizontal";
        protected virtual Color WaitColor { get { return Color.Gray; } }
        protected virtual Color ProcessColor { get { return Color.Navy; } }
        protected virtual Color ErrorColor { get { return Color.Red; } }
        protected virtual Color FinishColor { get { return Color.Green; } }
        protected virtual Color PanelColor { get { return Color.Blue; } }
        protected virtual Font FontSytle { get; }
        protected virtual Size StepSize { get { return new Size(100, 30); } }
        protected virtual int ConnectorWidth { get { return 20; } }
        protected virtual int ConnectorHeight { get { return 2; } }



        public void InitStepModels()
        {
            List<StepModel> steps = _stepsPresenter.steps;

            if (Direction == "Horizontal")
            {
                flowLayoutPanel1.Width = steps.Count * 150;
                this.Width = flowLayoutPanel1.Width;
            }
            else
            {
                flowLayoutPanel1.Width = 120;
                flowLayoutPanel1.Height = steps.Count * 150;
                this.Height = flowLayoutPanel1.Height;
            }
            foreach (StepModel step in steps)
            {
                FlowLayoutPanel step1FlowOutPanel = RenderStep(step);

                Panel line = new Panel();
                if (Direction == "Horizontal")
                {
                    line.Width = 30;
                    line.Height = 2;
                    line.Margin = new Padding(0, 35, 0, 0);
                }
                else
                {
                    line.Width = 2;
                    line.Height = 30;
                    line.Margin = new Padding(55, 0, 0, 0);
                }

                line.BackColor = PanelColor;
                flowLayoutPanel1.Controls.Add(step1FlowOutPanel);
                flowLayoutPanel1.Controls.Add(line);
            }

            flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);

        }

        public void ChangeLabelColor(List<StepModel> steps)
        {
            for (int i = 0; i < steps.Count; i++)
            {
                Color textColor = GetColorByStatus(steps[i]);
                FlowLayoutPanel panel = flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().ToList()[i];
                panel.Controls.OfType<Label>().ToList().ForEach(x => x.ForeColor = textColor);
            }
        }
        public Color GetColorByStatus(StepModel step)
        {
            switch (step.status)
            {
                case StatusEnum.Finish:
                    return FinishColor;
                case StatusEnum.Process:
                    return ProcessColor;
                case StatusEnum.Wait:
                    return WaitColor;
                case StatusEnum.Error:
                    return ErrorColor;
            }

            return Color.Black;
        }
    }
}
