using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFModuleB.Views;

namespace WPFModuleB
{
    [Module(ModuleName = "ModuleB", OnDemand = true)]
    // 显示名称
    // 模块描述
    // 模块加载顺序
    // 模块依赖
    public class ModuleB : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ModuleBContent>(nameof(ModuleBContent));
        }
    }
}
