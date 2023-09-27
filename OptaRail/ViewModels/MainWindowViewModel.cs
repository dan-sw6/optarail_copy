using OptaRail.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace OptaRail.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IShellService _shellService;

        private string _title = "OptaRail";


        private DelegateCommand<string> _openShellCommand;

        private DelegateCommand<string> _navigateCommand;

        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(string viewName)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, viewName);
        }

        public DelegateCommand<string> OpenShellCommand =>
            _openShellCommand ?? (_openShellCommand = new DelegateCommand<string>(ExecuteOpenShellCommand));


        void ExecuteOpenShellCommand(string viewName)
        {
            
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager, IShellService shellService)
        {
            _regionManager = regionManager;
            _shellService = shellService;
        }
    }
}
 