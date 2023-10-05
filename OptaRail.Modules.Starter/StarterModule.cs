using OptaRail.Core;
using OptaRail.Modules.Starter.Menus;
using OptaRail.Modules.Starter.ViewModels;
using OptaRail.Modules.Starter.Views;
using OptaRail.Services.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace OptaRail.Modules.Starter
{
    public class StarterModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IRailProjectService _railProjectService;

        public StarterModule(IRegionManager regionManager,  IRailProjectService railProjectService)
        {
            _regionManager = regionManager;
            _railProjectService = railProjectService;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.BarRegion, typeof(StarterBarView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(StarterContentView));


        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StarterBarView, StarterBarViewModel>();
            containerRegistry.RegisterForNavigation<StarterMenu, StarterMenuViewModel>();
            
    

        }
    }
}