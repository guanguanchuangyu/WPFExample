using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Prism.DryIoc;

using HandyControl.Data;
using HandyControl.Themes;
using HandyControl.Tools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using CommonServiceLocator;
//using Prism.Unity;
//using Unity.Microsoft.DependencyInjection;
//using Unity.ServiceLocation;
//using Unity;
using Microsoft.Extensions.Logging;
using Prism.Ioc;
using Prism.Modularity;
using System.Net.Http;
using System.Windows;
using G2CyHome.Wpf.Datas.Logger;
using Prism.DryIoc;
using Example;
using System.Configuration;
//using DryIoc.Microsoft.DependencyInjection.Extension;
namespace WPFListBoxExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public const string ContentRegion = nameof(ContentRegion);

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region Unity使用IServiceCollection
            //IServiceCollection serviceCollection = new ServiceCollection();
            //serviceCollection.AddLogging(logging =>
            //{
            //    logging.ClearProviders();
            //    //logging.SetMinimumLevel(LogLevel.Information);
            //    //logging.AddConsole();
            //    logging.AddLog4Net();
            //});
            //serviceCollection.BuildServiceProvider();

            //Container.GetContainer().AddExtension(new Diagnostic()).BuildServiceProvider(serviceCollection);

            //var unitvserviceLocator = new UnityServiceLocator(Container.GetContainer());

            //ServiceLocator.SetLocatorProvider(() => unitvserviceLocator); 
            #endregion
        }


        #region DryIoc使用ServiceCollection
        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollection = new ServiceCollection();
            // 添加日志配置
            serviceCollection.AddLogging(configure =>
            {
                configure.ClearProviders();
                configure.AddLog4Net();
            });
            // 添加系统配置
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            // 上下文服务配置 
            //serviceCollection.Configure();

            Rules rules = Rules.Default
                .WithConcreteTypeDynamicRegistrations(null, Reuse.Transient)
                .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments), overrideRegistrationMade: false)
                .WithFuncAndLazyWithoutRegistration()
                .WithTrackingDisposableTransients()
                //.WithoutFastExpressionCompiler()
                .WithFactorySelector(Rules.SelectLastRegisteredFactory());
            IContainer container = new Container(rules);
            container.WithDependencyInjectionAdapter(serviceCollection);
            return new DryIocContainerExtension(container);
        }
        #endregion

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<PrjtAuthorizationModule>();
            //moduleCatalog.AddModule<FlyControlModule>();
            //Container.Resolve<IRegionManager>().RegisterViewWithRegion(ContentRegion, typeof(ContentView));
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
