using OptaRail.Core;
using OptaRail.Modules.Starter.Menus;
using OptaRail.Modules.Starter.ViewModels;
using OptaRail.Services.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace OptaRail.Modules.Starter
{
    public class StarterModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IRailDocumentService _railDocumentService;

        public StarterModule(IRegionManager regionManager,  IRailDocumentService railDocumentService)
        {
            _regionManager = regionManager;
            _railDocumentService = railDocumentService;
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