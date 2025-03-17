using IOCServiceCollection;
using MVP_Pro_Practice.Contracts;
using MVP_Pro_Practice.Models.Enum;
using MVP_Pro_Practice.Presenter;
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
    // AStepsView stepview = new StepsView
    public abstract partial class AStepsView : UserControl, IStepView
    {
        protected IStepsPresenter _stepsPresenter;

        public event EventHandler<int> StepIndexChange;

        protected Button NextButton { get; set; }
        protected Button PreviousButton { get; set; }

        public AStepsView(PresenterFactory presenterFactory)
        {
            InitializeComponent();
            _stepsPresenter = presenterFactory.Create<IStepsPresenter, IStepView>(this);
        }

        protected abstract FlowLayoutPanel RenderStep(StepModel step);

        public void StepListResponse(List<StepModel> steps)
        {
            _stepsPresenter.steps = steps;
            InitStepModels();
            _stepsPresenter.ChangeStepStatus(_stepsPresenter.currentStep);
            ChangeLabelColor(_stepsPresenter.steps);
        }

        private void ButtonDirection_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StepClickDirection direction = (StepClickDirection)button.Tag;
            int stepNum = direction == StepClickDirection.Next ? _stepsPresenter.currentStep + 1 : _stepsPresenter.currentStep - 1;
            if (_stepsPresenter.CanMove(stepNum))
            {
                _stepsPresenter.ChangeStepStatus(_stepsPresenter.currentStep);
                ChangeLabelColor(_stepsPresenter.steps);
            }

            StepIndexChange.Invoke(this, _stepsPresenter.currentStep);
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            _stepsPresenter.FinishAllSteps();
            ChangeLabelColor(_stepsPresenter.steps);
        }

    }
}
