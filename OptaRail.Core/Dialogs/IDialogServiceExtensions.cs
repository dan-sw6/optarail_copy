using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services.Dialogs;

namespace OptaRail.Core.Dialogs
{
    public static class IDialogServiceExtensions
    {
        public static void ShowMessageDialog(this IDialogService dialogService, string message,
            Action<IDialogResult> callBack)
        {
            var p = new DialogParameters {{"message", message}};

            dialogService.ShowDialog("MessageDialog", p, callBack);
        }
    }
}
