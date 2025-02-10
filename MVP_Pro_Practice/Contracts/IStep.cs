﻿using System;
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

    interface IStepsPresenter
    {
        void GetStepList();
    }
}
