using IOCServiceCollection.Attributes;
using MVP_Pro_Practice.Contracts;
using MVP_Pro_Practice.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Presenter
{
    [Singleton("IStepsPresenter")]
    internal class StepsPresenter : IStepsPresenter
    {
        IStepView stepView;

        private List<StepModel> _steps;
        public List<StepModel> steps { get => _steps; set => _steps = value; }

        public int _currentStep = 1;

        int IStepsPresenter.currentStep { get => _currentStep; set => _currentStep = value; }


        public StepsPresenter(IStepView stepView)
        {
            this.stepView = stepView;
        }

        public void GetStepList()
        {
            this.stepView.StepListResponse(steps);
        }

        public void AssignStepStatus(int stepNum, StatusEnum status = StatusEnum.Finish)
        {
            if (stepNum >= 1 && stepNum <= _steps.Count)
            {
                _steps[stepNum - 1].status = status;
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

        public void Move(int stepNum)
        {
            if (CanMove(stepNum))
            {
                ChangeStepStatus(_currentStep);
            }
        }

        private bool CanMove(int stepNum)
        {
            if (stepNum >= 1 && stepNum <= _steps.Count)
            {
                _currentStep = stepNum;
                return true;
            }
            return false;
        }


        public void FinishAllSteps()
        {
            foreach (StepModel step in steps)
            {
                step.status = StatusEnum.Finish;
            }
        }
    }
}
