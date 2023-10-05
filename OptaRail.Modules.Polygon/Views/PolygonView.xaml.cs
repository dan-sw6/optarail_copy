using System.Windows.Controls;
using OptaRail.Core;
using OptaRail.Modules.Polygon.Menus;

namespace OptaRail.Modules.Polygon.Views
{
    /// <summary>
    /// Interaction logic for PolygonView
    /// </summary>
    [DependentView(RegionNames.RibbonRegion, typeof(PolygonTab))]
    public partial class PolygonView : UserControl
    {
        public PolygonView()
        {
            InitializeComponent();
        }
    }
}
