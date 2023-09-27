using OptaRail.Domain;
using OptaRail.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OptaRail.ViewModels
{
    public class StartUpWindowViewModel : BindableBase
    {
        private readonly IRailDocumentService _railDocumentService;
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private ObservableCollection<RailDocument> _railDocuments;
        private string _title = "OptaRail";

        private RailDocument _selectedRailDocument;

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
        public StartUpWindowViewModel(IRailDocumentService railDocumentService, IRegionManager regionManager, IDialogService dialogService)
        {
            _railDocumentService = railDocumentService;
            _regionManager = regionManager;
            _dialogService = dialogService;
            UpdateRailDoc();
        }

        void UpdateRailDoc()
        {
            RailDocuments = new ObservableCollection<RailDocument>(_railDocumentService.GetRailDocuments());
            RaisePropertyChanged("RailDocuments");


        }
        private DelegateCommand _creatProjectCommand;


        public DelegateCommand CreateProjectCommand =>
            _creatProjectCommand ?? (_creatProjectCommand = new DelegateCommand(ExecuteCreateProject));
        void ExecuteCreateProject()
        {
            var p = new DialogParameters {{"RailDocument", new RailDocument{Developer = Environment.UserName, AddInfo = "Создан " + DateTime.Now}}};

            _dialogService.ShowDialog("CreateProjectDialog", p, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    var addDoc = result.Parameters.GetValue<RailDocument>("RailDocument");
                    _railDocumentService.AddRailDocument(addDoc);
                    UpdateRailDoc();
                }
            });

        }
    }
}
