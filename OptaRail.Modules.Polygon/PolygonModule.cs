using OptaRail.Modules.Polygon.ViewModels;
using OptaRail.Modules.Polygon.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace OptaRail.Modules.Polygon
{
    public class PolygonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PolygonView, PolygonViewModel>();
            containerRegistry.RegisterForNavigation<StencilView, StencilViewModel>();
        }
    }
}