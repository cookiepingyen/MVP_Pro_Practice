using IOCServiceCollection;
using IOCServiceCollection.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Pro_Practice.Components.Pagy
{
    [Transient]
    internal class BasePaginationView : APaginationView
    {
        public BasePaginationView(PresenterFactory presenterFactory) : base(presenterFactory)
        {
        }
    }
}
