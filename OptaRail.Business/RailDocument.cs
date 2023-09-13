using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace OptaRail.Domain
{
    public class RailDocument:BindableBase
    {
        private string _title;
        private string _desctiption;
        private string _id;

        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

    
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string Description
        {
            get { return _desctiption; }
            set { SetProperty(ref _desctiption, value); }
        }


    }
}
