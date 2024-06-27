using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFShell
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // 获取RegionManager实例
            var regionManager = containerProvider.Resolve<IRegionManager>();
            // 注册Region
            regionManager.RegisterViewWithRegion(MainModuleConst.ContentRegionName, typeof(Views.Regions.DefaultContent));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
