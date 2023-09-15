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
        private string _description;
        private string _id;

        public RailDocument(string title, string description, string id)
        {
            _title = title;
            _description = description;
            _id = id;
        }

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
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }


    }
}
