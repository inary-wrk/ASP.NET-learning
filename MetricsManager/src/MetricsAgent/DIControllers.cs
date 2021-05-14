using MetricsAgent.Controllers;
using StrongInject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MetricsAgent
//{
//    [Register(typeof(CPUController), Scope.InstancePerResolution)]
//    [Register(typeof(DotNetController), Scope.InstancePerResolution)]
//    [Register(typeof(HardDriveController), Scope.InstancePerResolution)]
//    [Register(typeof(NetworkController), Scope.InstancePerResolution)]
//    [Register(typeof(RAMController), Scope.InstancePerResolution)]
//    public partial class DIControllers : IContainer<CPUController>,
//                                         IContainer<DotNetController>,
//                                         IContainer<HardDriveController>,
//                                         IContainer<NetworkController>,
//                                         IContainer<RAMController>
//    {


//    }
//}

//services.AddControllers().ResolveControllersThroughServiceProvider();
//services.AddTransientServiceUsingContainer<DIControllers, CPUController>();
//services.AddTransientServiceUsingContainer<DIControllers, DotNetController>();
//services.AddTransientServiceUsingContainer<DIControllers, HardDriveController>();
//services.AddTransientServiceUsingContainer<DIControllers, NetworkController>();
//services.AddTransientServiceUsingContainer<DIControllers, RAMController>();