using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Tools.Controls;

namespace OptaRail.Core.Adapters
{
    public class SyncGroupBarRegionAdapter : RegionAdapterBase<GroupBar>
    {
        public SyncGroupBarRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, GroupBar regionTarget)
        {
            region.Views.CollectionChanged += ((x, y) =>
            {
                switch (y.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    {
                        foreach (GroupBarItem group in y.NewItems)
                        {
                            regionTarget.Items.Add(group);

                            //The WPF XamOutlookBar does not automatically select the first group in it's collection.
                            //So we must manually select the group if it is the first one in the collection, but we don't
                            //want to excute this code every time a new group is added, only if the first group is the current group being added.
                            if (regionTarget.Items[0] == group)
                            {
                                regionTarget.SelectedObject = group;
                            }
                        }

                        break;
                    }
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    {
                        foreach (GroupBarItem group in y.OldItems)
                        {
                            regionTarget.Items.Remove(group);
                        }

                        break;

                    }
                }


            });
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
