using OptaRail.Core;
using System.Windows.Controls;
using OptaRail.Modules.Starter.Menus;

namespace OptaRail.Modules.Starter.Views
{
    /// <summary>
    /// Interaction logic for PrismUserControl1
    /// </summary>

    [DependentView(RegionNames.MenuRegion, typeof(StarterMenu))]
    public partial class StarterBarView : UserControl
    {
        public StarterBarView()
        {
            InitializeComponent();
        }
    }
}
