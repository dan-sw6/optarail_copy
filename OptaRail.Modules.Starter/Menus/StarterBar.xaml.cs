using System.Windows.Controls;
using OptaRail.Core;
using OptaRail.Modules.Starter.Menus;
using Syncfusion.Windows.Tools.Controls;

namespace OptaRail.Modules.Starter.Menus
{
    /// <summary>
    /// Interaction logic for PrismUserControl1
    /// </summary>
    [DependentView(RegionNames.MenuRegion, typeof(StarterMenu))]
    public partial class StarterBar : GroupBarItem 
    {
        public StarterBar()
        {
            InitializeComponent();
        }
    }
}
