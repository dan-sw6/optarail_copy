using OptaRail.Domain;
using OptaRail.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OptaRail.Core;
using OptaRail.Core.Dialogs;
using OptaRail.Core.Events;
using OptaRail.Core.Interfaces;
using Prism.Events;
using Syncfusion.Windows.Tools.Controls;

namespace OptaRail.ViewModels
{
    public class StartUpWindowViewModel : BindableBase, ICloseWindow
    {

        #region Fields
        private readonly IRailProjectService _railProjectService;
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;
        private ObservableCollection<RailDocument> _railDocuments;
        private string _title = "OptaRail";

        private RailDocument _selectedRailDocument;


        #endregion

        #region Properties
        public RailDocument SelectedRailDocument
        {
            get { return _selectedRailDocument; }
            set { SetProperty(ref _selectedRailDocument, value); }
        }


        public ObservableCollection<RailDocument> RailDocuments
        {
            get { return _railDocuments; }
            set { SetProperty(ref _railDocuments, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public Action Close { get; set; }
        #endregion


        #region DelegateCommands
        private DelegateCommand<RailDocument> _deleteRailDocumentCommand;

        public DelegateCommand<RailDocument> DeleteRailDocumentCommand =>
            _deleteRailDocumentCommand ?? (_deleteRailDocumentCommand = new DelegateCommand<RailDocument>(ExecuteDeleteRailDocumentCommand));

        void ExecuteDeleteRailDocumentCommand(RailDocument parameterName)
        {
            _dialogService.ShowMessageDialog("Удалить проект " + parameterName.ProjectName + "?", r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    _railProjectService.DeleteRailDocument(parameterName);
                    UpdateRailDoc();
                }
            });
        }


        private DelegateCommand _createProjectCommand;


        public DelegateCommand CreateProjectCommand =>
            _createProjectCommand ?? (_createProjectCommand = new DelegateCommand(ExecuteCreateProject));
        void ExecuteCreateProject()
        {
            var p = new DialogParameters { { "RailDocument", new RailDocument { Developer = Environment.UserName, AddInfo = "Создан " + DateTime.Now } } };

            _dialogService.ShowDialog("CreateProjectDialog", p, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    var addDoc = result.Parameters.GetValue<RailDocument>("RailDocument");
                    _railProjectService.AddRailDocument(addDoc);
                    UpdateRailDoc();
                }
            });

        }

        private DelegateCommand _openProjectCommand;

        public DelegateCommand OpenProjectCommand =>
            _openProjectCommand ?? (_openProjectCommand = new DelegateCommand(ExecuteOpenProjectCommand));

        void ExecuteOpenProjectCommand()
        {
           
            _eventAggregator.GetEvent<RailProjectIdEvent>().Publish(SelectedRailDocument.Id);
            Close?.Invoke();
           
        }

        #endregion



        public StartUpWindowViewModel(IRailProjectService railProjectService, IRegionManager regionManager, IDialogService dialogService, IEventAggregator eventAggregator)
        {
            _railProjectService = railProjectService;
            _regionManager = regionManager;
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
            UpdateRailDoc();
        }

        void UpdateRailDoc()
        {
            RailDocuments = new ObservableCollection<RailDocument>(_railProjectService.GetRailDocuments());
            RaisePropertyChanged("RailDocuments");


        }

        
    }
}
