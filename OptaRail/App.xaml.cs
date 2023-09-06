using OptaRail.Views;
using Prism.Ioc;
using System.Windows;
using OptaRail.Modules.Primary;
using Prism.Modularity;
using Prism.Regions;
using OptaRail.Core.Adapters;
using Syncfusion.Windows.Tools.Controls;

namespace OptaRail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqUE1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfRF9gSX9Wc0ZrXnlWdg==;Mgo+DSMBPh8sVXJ1S0R+WVpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jT3xQdkRmXHxWd3xcQA==;ORg4AjUWIQA/Gnt2VFhiQlRPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhRdUViXHpdeHxVRWY=;MjQ5ODkzNUAzMjMxMmUzMDJlMzBEZmU3cFJTNFdTbGczSkFqSFhqRi9UaVQyR3NCMDNwRmNOdWcxUGE2TWw0PQ==;MjQ5ODkzNkAzMjMxMmUzMDJlMzBKb2kybnprazJEczdXZzdybjlMbUpyRDlDV2xjemFySXhRd1dxMm0ybXBvPQ==;NRAiBiAaIQQuGjN/V0d+Xk9BfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5VdEZjWHpbc3xdQWNa;MjQ5ODkzOEAzMjMxMmUzMDJlMzBnd1pPZXhGL2h2Zk5tRTMzN0I4cjhMZTFmNmpSVGZnMnVkUDlBemxBMzRFPQ==;MjQ5ODkzOUAzMjMxMmUzMDJlMzBMM2dLcFBlT2h2UlppODJ4aFRvOHVPVHlUZGYvazNIcjVUeFI2blIzUHpnPQ==;Mgo+DSMBMAY9C3t2VFhiQlRPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhRdUViXHpdeH1RQmY=;MjQ5ODk0MUAzMjMxMmUzMDJlMzBtWEZ4UE93dzZnM3FMQ0hybGxja0taRzJSdkM3RlB0NGQzVFJTTzhRU0hNPQ==;MjQ5ODk0MkAzMjMxMmUzMDJlMzBEZy9hVkZFWTdveTZwazBXY1BFMXk4RkxlcVBucUQvakRQcHk2QnJoK0RjPQ==;MjQ5ODk0M0AzMjMxMmUzMDJlMzBnd1pPZXhGL2h2Zk5tRTMzN0I4cjhMZTFmNmpSVGZnMnVkUDlBemxBMzRFPQ==");
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<PrimaryModule>();
        }

        //protected override void OnInitialized()
        //{
        //    var startup = Container.Resolve<StartupWindow>();
        //    var result = startup.ShowDialog();
        //    if (result != null && result.Value)
        //    {
        //        base.OnInitialized(); 

        //    }
        //    else
        //    {
        //        Application.Current.Shutdown();
        //    }
        //}

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(DockingManager), Container.Resolve<DockingManagerRegionAdapter>());
        }
    }
}
