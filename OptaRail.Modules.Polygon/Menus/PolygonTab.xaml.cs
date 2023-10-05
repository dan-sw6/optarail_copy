using OptaRail.Core;
using Syncfusion.Windows.Tools.Controls;

namespace OptaRail.Modules.Polygon.Menus
{
    /// <summary>
    /// Interaction logic for HomeTab
    /// </summary>
    public partial class PolygonTab : RibbonTab, ISupportDataContext
    {

        public PolygonTab()
        {
            InitializeComponent();
            Loaded += PolygonTab_Loaded;
        }

        private void PolygonTab_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (e.OriginalSource is RibbonTab rt)
            {
                rt.IsChecked = true;
            };
        }
    }
}
