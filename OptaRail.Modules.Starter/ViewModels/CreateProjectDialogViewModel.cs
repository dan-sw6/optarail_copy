using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using OptaRail.Domain;
using Prism.Services.Dialogs;

namespace OptaRail.Modules.Starter.ViewModels
{
	public class CreateProjectDialogViewModel : BindableBase, IDialogAware
	{
		private RailDocument _railDocument;



        private DelegateCommand<object> _dialogCommand;

        public DelegateCommand<object> DialogCommand =>
            _dialogCommand ??= new DelegateCommand<ButtonResult>(ExecuteDialogCommand);

        void ExecuteDialogCommand(object parameterName)
        {
            ButtonResult result = parameterName as ButtonResult;
            
            
            if (parameterName == ButtonResult.OK)
            {
                var parametres = new DialogParameters {{"RailDocument", RailDocument}};
                RequestClose?.Invoke(new DialogResult(parameterName,parametres));
            }
			else if (parameterName == ButtonResult.Cancel)
            {
                var parametres = new DialogParameters();
               
                RequestClose?.Invoke(new DialogResult(parameterName, parametres));
            }
        }

		public RailDocument RailDocument
		{
			get { return _railDocument; }
			set { SetProperty(ref _railDocument, value); }
		}   
		public CreateProjectDialogViewModel()
		{
			
		}

		public bool CanCloseDialog()
		{
			return true;
		}  

		public void OnDialogClosed()
		{

		}

		public void OnDialogOpened(IDialogParameters parameters)
		{
			RailDocument = parameters.GetValue<RailDocument>("RailDocument");
		}

		public string Title => "Создание нового проекта";

		public event Action<IDialogResult> RequestClose;
	}
}
