using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptaRail.Views;
using Prism.Ioc;
using Prism.Regions;

namespace OptaRail.Core
{
    public class ShellService:IShellService
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;


        public ShellService(IRegionManager  regionManager, IContainerProvider containerProvider )
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
           
        }

        public void ShowShell(string uri)
        {
            var shell = _containerProvider.Resolve<MainWindow>();
            var scopedRegion = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(shell, scopedRegion);
            scopedRegion.RequestNavigate(RegionNames.ContentRegion, uri);
            shell.Show();
        }
    }
}
 