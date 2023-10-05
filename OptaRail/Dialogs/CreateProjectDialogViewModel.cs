using System;
using OptaRail.Domain;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace OptaRail.Dialogs
{
	public class CreateProjectDialogViewModel : BindableBase, IDialogAware
	{
		private RailDocument _railDocument;



		private DelegateCommand<object> _dialogCommand;

		public DelegateCommand<object> DialogCommand =>
			_dialogCommand ??= new DelegateCommand<object>(ExecuteDialogCommand);

		void ExecuteDialogCommand(object parameterName)
		{
			ButtonResult result = (ButtonResult) parameterName;
			 
			
			if (result == ButtonResult.OK)
			{
				var parametres = new DialogParameters {{"RailDocument", RailDocument}};
				RequestClose?.Invoke(new DialogResult(result, parametres));
			}
			else if (result == ButtonResult.Cancel)
			{
				var parametres = new DialogParameters();
			   
				RequestClose?.Invoke(new DialogResult(result, parametres));

			}
		}

		public RailDocument RailDocument
		{
			get { return _railDocument; }
			set { SetProperty(ref _railDocument, value); }
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
