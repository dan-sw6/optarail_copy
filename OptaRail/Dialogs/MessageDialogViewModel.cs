using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptaRail.Domain;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace OptaRail.Dialogs
{
    public class MessageDialogViewModel:BindableBase, IDialogAware
    {
        public string Title { get; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
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
            Message = parameters.GetValue<string>("message");

        }

        public event Action<IDialogResult> RequestClose;

        private DelegateCommand<object> _dialogCommand;

        public DelegateCommand<object> DialogCommand =>
            _dialogCommand ??= new DelegateCommand<object>(ExecuteDialogCommand);

        void ExecuteDialogCommand(object parameterName)
        {
            ButtonResult result = (ButtonResult)parameterName;
            var parametres = new DialogParameters {{"result", result}};
            RequestClose?.Invoke(new DialogResult(result, parametres));
    
        }
    }
}
