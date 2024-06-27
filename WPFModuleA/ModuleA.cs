using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFModuleA.Views;
using WPFModuleCore.Attributes;

namespace WPFModuleA
{
    [Module(ModuleName ="ModuleA",OnDemand = true)]
    [ModuleMetadata(DisplayName ="模块一",Description ="用于加载设备类型一",Level = WPFModuleCore.Entities.ModuleLevel.Core,Order =2)]
    public class ModuleA : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ModuleAContent>(nameof(ModuleAContent));
        }
    }
}
