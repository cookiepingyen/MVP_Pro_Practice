using IOCServiceCollection.Attributes;
using MVP_Pro_Practice.Contracts;
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

        public StepsPresenter(IStepView stepView)
        {
            this.stepView = stepView;
        }

        public void GetStepList()
        {
            this.stepView.StepListResponse(steps);
        }
    }
}
