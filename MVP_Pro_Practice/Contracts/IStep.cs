using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Contracts
{
    interface IStepView
    {
        void StepListResponse(List<StepModel> steps);
    }

    public interface IStepsPresenter
    {
        List<StepModel> steps { get; set; }
        int currentStep { get; set; }

        void GetStepList();

        void ChangeStepStatus(int currentStep);

        void FinishAllSteps();
        void Move(int stepNum);
    }
}
