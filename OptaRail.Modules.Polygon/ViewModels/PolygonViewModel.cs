using Prism.Mvvm;

namespace OptaRail.Modules.Polygon.ViewModels
{
    public class PolygonViewModel : BindableBase
    {

        private string _title = "ПЕС";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public PolygonViewModel()
        {

        }

   
    }
}
