using OptaRail.Views;
using Prism.Ioc;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Prism.Modularity;
using Prism.Regions;
using OptaRail.Core.Adapters;
using OptaRail.Modules.Starter;
using Syncfusion.Windows.Tools.Controls;
using OptaRail.Core.Behaviors;
using OptaRail.Infrastructure.Interfaces;
using OptaRail.Services;
using OptaRail.Services.Interfaces;
using OptaRail.SQLiteDataAccess;
using OptaRail.SQLiteDataAccess.Context;
using OptaRail.SQLiteDataAccess.Repositories;
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
            SfSkinManager.ApplyStylesOnApplication = true;

        }

        protected override Window CreateShell()
        {

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IUnitOfWork, UnitOfWork>();
            containerRegistry.RegisterSingleton<IRailDocumentRepository, RailDocumentRepository>();
            containerRegistry.RegisterSingleton<IRailDocumentService, RailDocumentService>();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlite("Data Source=..\\\\..\\\\sqlite.db").Options;
            containerRegistry.Register<AppDbContext>(() => new AppDbContext(options));




        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<StarterModule>();
        }

        protected override void OnInitialized()
        {

            base.OnInitialized();
            //var startup = Container.Resolve<StartupWindow>();
            //var result = startup.ShowDialog();
            //if (result != null && result.Value)
            //{
            //    base.OnInitialized();

            //}
            //else
            //{
            //    Application.Current.Shutdown();
            //}
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
