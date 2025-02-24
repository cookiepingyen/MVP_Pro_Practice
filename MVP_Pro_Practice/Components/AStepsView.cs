using MVP_Pro_Practice.Contracts;
using MVP_Pro_Practice.Models.Enum;
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
    public abstract partial class AStepsView : UserControl, IStepView
    {
        protected List<StepModel> _steps;
        public List<StepModel> steps;

        public int currentStep = 1;
        public event EventHandler<int> StepIndexChange;

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


        protected Button NextButton { get; set; }
        protected Button PreviousButton { get; set; }



        public AStepsView()
        {
            InitializeComponent();
        }

        protected abstract FlowLayoutPanel RenderStep(StepModel step);

        public void StepListResponse(List<StepModel> steps)
        {
            _steps = steps;
            InitStepModels();
            ChangeStepStatus(currentStep);
            ChangeLabelColor();
        }

        public void InitStepModels()
        {
            if (Direction == "Horizontal")
            {
                flowLayoutPanel1.Width = _steps.Count * 150;
                this.Width = flowLayoutPanel1.Width;
            }
            else
            {
                flowLayoutPanel1.Width = 120;
                flowLayoutPanel1.Height = _steps.Count * 150;
                this.Height = flowLayoutPanel1.Height;
            }
            foreach (StepModel step in _steps)
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


        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (CanMove(currentStep + 1))
            {
                ChangeStepStatus(currentStep);
                ChangeLabelColor();
            }


            StepIndexChange.Invoke(this, currentStep);
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (CanMove(currentStep - 1))
            {
                ChangeStepStatus(currentStep);
                ChangeLabelColor();
            }

            StepIndexChange.Invoke(this, currentStep);
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            currentStep = _steps.Count;
            foreach (StepModel step in _steps)
            {
                step.status = StatusEnum.Finish;
            }
            ChangeLabelColor();
        }

        public void ChangeLabelColor()
        {
            for (int i = 0; i < _steps.Count; i++)
            {
                Color textColor = GetColorByStatus(_steps[i]);
                FlowLayoutPanel panel = flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>().ToList()[i];
                panel.Controls.OfType<Label>().ToList().ForEach(x => x.ForeColor = textColor);
            }
        }

        public void ChangeStepStatus(int currentStep)
        {
            for (int i = 0; i < _steps.Count; i++)
            {
                if (i < currentStep - 1)
                {
                    _steps[i].status = StatusEnum.Finish;
                }
                else if (i == currentStep - 1)
                {
                    _steps[i].status = StatusEnum.Process;
                }
                else
                {
                    _steps[i].status = StatusEnum.Wait;
                }
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

        public bool CanMove(int stepNum)
        {
            if (stepNum >= 1 && stepNum <= _steps.Count)
            {
                currentStep = stepNum;
                return true;
            }
            return false;
        }

        public void AssignStepStatus(int stepNum, StatusEnum status = StatusEnum.Finish)
        {
            if (stepNum >= 1 && stepNum <= _steps.Count)
            {
                _steps[stepNum - 1].status = status;
                ChangeLabelColor();
            }
        }
    }
}
