using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OptaRail.Modules.InitProject.ViewModels
{
    public class MasterDataTabViewModel : BindableBase
    {
        private string _title = "НСИ";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public MasterDataTabViewModel()
        {

        }
    }
}
