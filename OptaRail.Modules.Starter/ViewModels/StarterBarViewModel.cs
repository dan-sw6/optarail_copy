using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OptaRail.Core;
using OptaRail.Domain;
using OptaRail.Services.Interfaces;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace OptaRail.Modules.Starter.ViewModels
{
    public class StarterBarViewModel : BindableBase
    {
        
        IRailDocumentService _railDocumentService;
       
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        private ObservableCollection<RailDocument> _railDocuments;

        private DelegateCommand _creatProjectCommand;

        public DelegateCommand CreateProjectCommand =>
            _creatProjectCommand ?? (_creatProjectCommand = new DelegateCommand(ExecuteCreateProject));

        void ExecuteCreateProject()
        {
            var p = new DialogParameters();
            p.Add("RailDocument", new RailDocument());

            _dialogService.ShowDialog("CreateProjectDialog", p, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    var addDoc = result.Parameters.GetValue<RailDocument>("RailDocument");
                    _railDocumentService.AddRailDocument(addDoc);

                }
            });

        }

        public ObservableCollection<RailDocument> RailDocuments
        {
            get { return _railDocuments; }
            set { SetProperty(ref _railDocuments, value); }
        }
        public StarterBarViewModel(IRailDocumentService railDocumentService, IRegionManager regionManager, IDialogService dialogService)
        {
            _railDocumentService = railDocumentService;
            _regionManager = regionManager;
            _dialogService = dialogService;
            RailDocuments = new ObservableCollection<RailDocument>(_railDocumentService.GetRailDocuments());
            
        }




    }
}
