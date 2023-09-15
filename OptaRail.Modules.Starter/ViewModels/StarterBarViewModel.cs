using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OptaRail.Domain;
using OptaRail.Services.Interfaces;

namespace OptaRail.Modules.Starter.ViewModels
{
    public class StarterBarViewModel : BindableBase
    {
        
        IRailDocumentService _railDocumentService;

        private ObservableCollection<RailDocument> _railDocuments;

        public ObservableCollection<RailDocument> RailDocuments
        {
            get { return _railDocuments; }
            set { SetProperty(ref _railDocuments, value); }
        }
        public StarterBarViewModel(IRailDocumentService railDocumentService)
        {
            _railDocumentService = railDocumentService;
            RailDocuments = new ObservableCollection<RailDocument>(_railDocumentService.GetRailDocuments());
        }


    }
}
