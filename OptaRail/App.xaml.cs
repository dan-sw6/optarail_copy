using OptaRail.Views;
using Prism.Ioc;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using OptaRail.Core;
using Prism.Modularity;
using Prism.Regions;
using OptaRail.Core.Adapters;
using OptaRail.Modules.Starter;
using Syncfusion.Windows.Tools.Controls;
using OptaRail.Core.Behaviors;
using OptaRail.Dialogs;
using OptaRail.Infrastructure.Interfaces;
using OptaRail.Modules.InitProject;
using OptaRail.Modules.Polygon;
using OptaRail.Services;
using OptaRail.Services.Interfaces;
using OptaRail.SQLiteDataAccess;
using OptaRail.SQLiteDataAccess.Context;
using OptaRail.SQLiteDataAccess.Repositories;
using OptaRail.ViewModels;
using Syncfusion.SfSkinManager;

namespace OptaRail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjcwNzg2N0AzMjMzMmUzMDJlMzBjVk1DaVAwQ21EOE1IK2UwMFdLV1Q3REd6SzNxZkFuSjdKeklGTzRXeDZJPQ==\r\n");
         

        }

        protected override Window CreateShell()
        {

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IUnitOfWork, UnitOfWork>();
            containerRegistry.RegisterSingleton<IRailProjectRepository, RailProjectRepository>();
            containerRegistry.RegisterSingleton<IRailProjectService, RailProjectService>();
            containerRegistry.RegisterSingleton<IShellService, ShellService>();
            containerRegistry.RegisterForNavigation<StartUpWindow, StartUpWindowViewModel>();
            containerRegistry.RegisterDialog<CreateProjectDialog, CreateProjectDialogViewModel>();
            containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>();
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlite("Data Source=..\\\\..\\\\sqlite.db").Options;
            containerRegistry.Register<AppDbContext>(() => new AppDbContext(options));

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) 
        {
            moduleCatalog.AddModule<InitProjectModule>();
            moduleCatalog.AddModule<PolygonModule>();
        }

        protected override void OnInitialized()
        {
            var startup = Container.Resolve<StartUpWindow>();
            var result = startup.ShowDialog();
            if (result != null && result.Value)
            {
                    base.OnInitialized();

            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(DockingManager), Container.Resolve<DockingManagerRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(GroupBar), Container.Resolve<SyncGroupBarRegionAdapter>());

        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);
            regionBehaviors.AddIfMissing(DependentViewRegionBehavior.BehaviorKey, typeof(DependentViewRegionBehavior));


        }
    }
}
