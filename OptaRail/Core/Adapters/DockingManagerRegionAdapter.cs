using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OptaRail.Core.Behaviors;
using Prism.Regions;
using Syncfusion.Windows.Tools.Controls;

namespace OptaRail.Core.Adapters
{
    public class DockingManagerRegionAdapter : RegionAdapterBase<DockingManager>
    {
        public DockingManagerRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {

            regionTarget.WindowClosing += (sender, e) =>
            {
                if (e.TargetItem is ContentControl item)
                {
                    region.Remove(item);;
                };
            };
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        if (!regionTarget.Children.Contains(element))
                        {
                            regionTarget.BeginInit();
                            regionTarget.Children.Add(element);
                            regionTarget.EndInit();
                        }
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement element in e.OldItems)
                    {
                        if (regionTarget.Children.Contains(element))
                        {
                            regionTarget.BeginInit();
                            regionTarget.Children.Remove(element);
                            regionTarget.EndInit();
                        }
                    }
                }
            };
        }

        protected override void AttachBehaviors(IRegion region, DockingManager regionTarget)
        {
            base.AttachBehaviors(region, regionTarget);
            if (!region.Behaviors.ContainsKey(DockingManagerRegionActiveAwareBehavior.BehaviorKey))
                region.Behaviors.Add(DockingManagerRegionActiveAwareBehavior.BehaviorKey, new DockingManagerRegionActiveAwareBehavior { HostControl = regionTarget });
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
