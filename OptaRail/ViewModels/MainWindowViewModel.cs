using OptaRail.Core;
using OptaRail.Core.Events;
using OptaRail.Domain;
using OptaRail.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace OptaRail.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IShellService _shellService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRailProjectService _railProjectService;
        

        private string _title = "OptaRail";

        private RailDocument _currentProject;


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

        public MainWindowViewModel(IRegionManager regionManager, IShellService shellService, IEventAggregator eventAggregator, IRailProjectService railProjectService)
        {
            _regionManager = regionManager;
            _shellService = shellService;
            _eventAggregator = eventAggregator;
            _railProjectService = railProjectService;
            _eventAggregator.GetEvent<RailProjectIdEvent>().Subscribe(GetRailProject);
        }

        private void GetRailProject(int id)
        {
           _currentProject = _railProjectService.GetRailDocumentById(id);
           Title = _currentProject.Title;
        }

    }
}
 