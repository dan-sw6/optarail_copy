using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace OptaRail.Domain
{
    public class RwSection:BindableBase
    {
        private string _title;

        public RwSection(string title)
        {
            _title = title;
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
