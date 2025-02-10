using MVP_Pro_Practice.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice
{
    public abstract partial class BaseStepsView : UserControl, IStepView
    {
        protected List<StepModel> _steps;
        public List<StepModel> steps;

        public int currentStep = 1;
        public event EventHandler<int> StepIndexChange;

        public virtual string Direction { get; } = "Horizontal";
        public string Type = "default";
        public string Status = "process";


        public BaseStepsView()
        {
            InitializeComponent();
        }

        protected abstract FlowLayoutPanel RenderStep(StepModel step);


        private void nextBtn_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(currentStep + 1);
            StepIndexChange.Invoke(this, currentStep);
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(currentStep - 1);
            StepIndexChange.Invoke(this, currentStep);
        }

        public void ChangeLabelColor(int step)
        {
            if (step >= 1 && step <= flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().Count())
            {
                for (int i = 0; i < _steps.Count; i++)
                {
                    FlowLayoutPanel panel = flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().ToList()[i];
                    panel.Controls.OfType<Label>().ToList().ForEach(x => x.ForeColor = Color.Black);
                }
                FlowLayoutPanel selectedPanel = flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().ToList()[step - 1];
                selectedPanel.Controls.OfType<Label>().ToList().ForEach(x => x.ForeColor = Color.Blue);

                currentStep = step;
            }
        }

        public void InitStepModels()
        {
            flowLayoutPanel1.Width = _steps.Count * 150;
            this.Width = flowLayoutPanel1.Width;

            foreach (StepModel step in _steps)
            {
                FlowLayoutPanel step1FlowOutPanel = RenderStep(step);

                Panel line = new Panel();
                line.Width = 30;
                line.Height = 2;
                line.Margin = new Padding(0, 30, 0, 0);
                line.BackColor = Color.Blue;

                flowLayoutPanel1.Controls.Add(step1FlowOutPanel);
                flowLayoutPanel1.Controls.Add(line);

            }

            flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);
        }

        public void StepListResponse(List<StepModel> steps)
        {
            _steps = steps;
            InitStepModels();
            ChangeLabelColor(1);
        }
    }
}
