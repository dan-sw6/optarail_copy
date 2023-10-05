using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using OptaRail.Core;
using Prism.Regions;

namespace OptaRail.Modules.InitProject.ViewModels
{
    public class MainTabViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Полигон";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public MainTabViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        private DelegateCommand<string> _navigateCommand;

        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(string uri)
        {
            _regionManager.RequestNavigate(RegionNames.MainRegion, uri);
        }

     
    }
}
