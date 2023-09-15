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

namespace OptaRail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF1cXGFCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWXZfcHRTRGldUEx1XkQ=");

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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqUE1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfRF9gSX9Wc0ZrXnlWdg==;Mgo+DSMBPh8sVXJ1S0R+WVpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jT3xQdkRmXHxWd3xcQA==;ORg4AjUWIQA/Gnt2VFhiQlRPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhRdUViXHpdeHxVRWY=;MjQ5ODkzNUAzMjMxMmUzMDJlMzBEZmU3cFJTNFdTbGczSkFqSFhqRi9UaVQyR3NCMDNwRmNOdWcxUGE2TWw0PQ==;MjQ5ODkzNkAzMjMxMmUzMDJlMzBKb2kybnprazJEczdXZzdybjlMbUpyRDlDV2xjemFySXhRd1dxMm0ybXBvPQ==;NRAiBiAaIQQuGjN/V0d+Xk9BfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5VdEZjWHpbc3xdQWNa;MjQ5ODkzOEAzMjMxMmUzMDJlMzBnd1pPZXhGL2h2Zk5tRTMzN0I4cjhMZTFmNmpSVGZnMnVkUDlBemxBMzRFPQ==;MjQ5ODkzOUAzMjMxMmUzMDJlMzBMM2dLcFBlT2h2UlppODJ4aFRvOHVPVHlUZGYvazNIcjVUeFI2blIzUHpnPQ==;Mgo+DSMBMAY9C3t2VFhiQlRPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhRdUViXHpdeH1RQmY=;MjQ5ODk0MUAzMjMxMmUzMDJlMzBtWEZ4UE93dzZnM3FMQ0hybGxja0taRzJSdkM3RlB0NGQzVFJTTzhRU0hNPQ==;MjQ5ODk0MkAzMjMxMmUzMDJlMzBEZy9hVkZFWTdveTZwazBXY1BFMXk4RkxlcVBucUQvakRQcHk2QnJoK0RjPQ==;MjQ5ODk0M0AzMjMxMmUzMDJlMzBnd1pPZXhGL2h2Zk5tRTMzN0I4cjhMZTFmNmpSVGZnMnVkUDlBemxBMzRFPQ==");

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
