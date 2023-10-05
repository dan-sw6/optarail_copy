using OptaRail.Core;
using OptaRail.Modules.InitProject.Menus;
using OptaRail.Modules.InitProject.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace OptaRail.Modules.InitProject
{
    public class InitProjectModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public InitProjectModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }


        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(MainTab));
            _regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(MasterDataTab));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainTab,MainTabViewModel>();
            containerRegistry.RegisterForNavigation<MasterDataTab, MasterDataTabViewModel>();

        }
    }
}