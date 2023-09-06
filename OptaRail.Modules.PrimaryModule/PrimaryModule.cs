
using OptaRail.Modules.Primary.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace OptaRail.Modules.Primary
{
    public class PrimaryModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}