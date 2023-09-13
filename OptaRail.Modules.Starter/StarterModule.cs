using OptaRail.Core;
using OptaRail.Modules.Starter.Menus;
using OptaRail.Modules.Starter.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace OptaRail.Modules.Starter
{
    public class StarterModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public StarterModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.BarRegion, typeof(StarterBar));

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StarterBar, StarterBarViewModel>();
            containerRegistry.RegisterForNavigation<StarterMenu, StarterMenuViewModel>();

        }
    }
}