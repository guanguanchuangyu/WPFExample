using ImTools;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFModuleCore;
using WPFShell.Views.Regions;

namespace WPFShell.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        private readonly IModuleManager _moduleManager;
        private readonly IRegionManager _regionManager;
        private readonly List<ModuleMeta> moduleInfos;
        public MainWindowViewModel(IModuleManager moduleManager,IRegionManager regionManager)
        {
            // 获取动态加载模块
            moduleManager.LoadModuleCompleted += (s, e) =>
            {
                // 模块加载完成
                Debug.WriteLine($"模块加载完成：{e.ModuleInfo.ModuleName}");
            };
            _moduleManager = moduleManager;
            _regionManager = regionManager;
            moduleInfos = GetModules();
        }

        private List<ModuleMeta>? GetModules()
        {
           //return _moduleManager.Modules.Where(x => x.InitializationMode == InitializationMode.OnDemand).ToList();
           // 通过ModuleInfo获取模块元数据
            return _moduleManager.Modules.Where(x => x.InitializationMode == InitializationMode.OnDemand).Select(x =>
            {
                var moduleMeta = new ModuleMeta
                {
                    ModuleName = x.ModuleName,
                    DisplayName = x.ModuleName,
                    Description = x.ModuleName,
                    Order = 0,
                    DependsOn = new List<string>(),
                    OnDemand = x.InitializationMode == InitializationMode.OnDemand,
                    State = x.State switch
                    {
                        ModuleState.NotStarted => ModuleState.NotStarted,
                        ModuleState.Initializing => ModuleState.Initializing,
                        ModuleState.Initialized => ModuleState.Initialized,
                        _ => ModuleState.NotStarted
                    }
                };
                return moduleMeta;
            }).ToList();
        }

        public List<ModuleMeta> ModuleInfos => moduleInfos;

        public void LoadContent(string modulename,string name)
        {
            // 判断模块是否已经初始化
            if (!_moduleManager.IsModuleInitialized(modulename))
            {
                // 加载模块
                _moduleManager.LoadModule(modulename);
            }
            try
            {
                // 判定view是否存在
                _regionManager.Regions["ContentRegion"].RequestNavigate(name);
            }
            catch (NullReferenceException ex)
            {
                throw;
            }
        }
    }
}
