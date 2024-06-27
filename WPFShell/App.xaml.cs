using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using WPFShell.ViewModels;
using WPFShell.Views;

namespace WPFShell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
           return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册服务
            containerRegistry.RegisterSingleton<MainWindow>();
            containerRegistry.RegisterSingleton<MainWindowViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // 注册模块
            moduleCatalog.AddModule<MainModule>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // 实例化模块集合
            string moduledir = @"./Modules";
            var modules = new List<IModuleCatalogItem>();
            if (!Directory.Exists(moduledir))
            {
                Directory.CreateDirectory(moduledir);
            }
            // 获取当前目录下的模块
            foreach (var dir in Directory.GetDirectories(moduledir))
            {
                // 获取模块对应实现类
                var dirCategorylog = new DirectoryModuleCatalog
                {
                    ModulePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), dir)
                };
                // 初始化模块
                dirCategorylog.Initialize();
                // 添加到模型集合
                modules.AddRange(dirCategorylog.Items);
            }
            // 创建模块类型实例
            var catalog = new ModuleCatalog();
            foreach (var module in modules)
            {
                catalog.Items.Add(module);
            }

            return catalog;
        }
    }

}
