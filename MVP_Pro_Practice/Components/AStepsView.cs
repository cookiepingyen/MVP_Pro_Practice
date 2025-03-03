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
        public List<StepModel> _steps;

        public int currentStep = 1;
        public event EventHandler<int> StepIndexChange;

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

        private void ButtonDirection_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StepClickDirection direction = (StepClickDirection)button.Tag;
            int stepNum = direction == StepClickDirection.Next ? currentStep + 1 : currentStep - 1;
            if (CanMove(stepNum))
            {
                ChangeStepStatus(currentStep);
                ChangeLabelColor();
            }

            StepIndexChange.Invoke(this, currentStep);
        }


        private void FinishBtn_Click(object sender, EventArgs e)
        {
            currentStep = _steps.Count;
            foreach (StepModel step in _steps)
            {
                step.status = StatusEnum.Finish;
            }
            ChangeLabelColor();
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
