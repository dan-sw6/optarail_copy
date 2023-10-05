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
        private string? _title;
        private string? _addInfo;

        private string? _projectName;


        private string? _cipher;

        private string? _developer;

        public string? Developer
        {
            get { return _developer; }
            set { SetProperty(ref _developer, value); }
        }


        public RailDocument()
        {

        }
        public RailDocument(string title, string addInfo)
        {
            _title = title;
            _addInfo = addInfo;
         
        }

   
        public string? Cipher
        {
            get { return _cipher; }
            set { SetProperty(ref _cipher, value); }
        }
        public string? ProjectName
        {
            get { return _projectName; }
            set { SetProperty(ref _projectName, value); }
        }
        public int Id { get; set; }
        
    
        public string? Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string? AddInfo
        {
            get { return _addInfo; }
            set { SetProperty(ref _addInfo, value); }
        }


    }
}
