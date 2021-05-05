using StrongInject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent
{
    [Register(typeof(Controllers.CPUController), Scope.InstancePerResolution)]
    public partial class DIContainer: IContainer<Controllers.CPUController>
    {
    }
}
