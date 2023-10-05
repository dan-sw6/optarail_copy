using Prism.Regions.Behaviors;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Automation;

namespace OptaRail.Core.Behaviors
{
    public class DockingManagerRegionActiveAwareBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        public const string BehaviorKey = "DockingManagerRegionActiveAwareBehavior";

        DependencyObject _hostControl;

        public DependencyObject HostControl
        {
            get { return _hostControl; }
            set { _hostControl = value as DockingManager; }
        }

        protected override void OnAttach()
        {
            ((HostControl as DockingManager).DocContainer as DocumentContainer).AddTabDocumentAtLast = true;
            ((HostControl as DockingManager).DocContainer as DocumentContainer).ActiveDocumentChanged +=
                DocumentRegionActiveAwareBehavior_ActiveDocumentChanged;
            ((HostControl as DockingManager).DocContainer as DocumentContainer).DocumentClosing += DockingManagerRegionActiveAwareBehavior_DocumentClosing;
        }

        private void DockingManagerRegionActiveAwareBehavior_DocumentClosing(object sender, CancelingRoutedEventArgs e)
        {
            if (e.OriginalSource is ContentControl item)
            {
                Region.Remove(item);
            }
        }

        private void DocumentRegionActiveAwareBehavior_ActiveDocumentChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                var item = e.OldValue;

                //are we dealing with a ContentPane directly
                if (Region.Views.Contains(item) && Region.ActiveViews.Contains(item))
                {
                    Region.Deactivate(item);
                }
                else
                {
                    //now check to see if we have any views that were injected
                    var contentControl = item as ContentControl;
                    if (contentControl != null)
                    {
                        var injectedView = contentControl.Content;
                        if (Region.Views.Contains(injectedView) && Region.ActiveViews.Contains(injectedView))
                            Region.Deactivate(injectedView);
                    }
                }
            }

            if (e.NewValue != null)
            {
                var item = e.NewValue;

                //are we dealing with a ContentPane directly
                if (Region.Views.Contains(item) && !this.Region.ActiveViews.Contains(item))
                {
                    Region.Activate(item);
                }
                else
                {
                    //now check to see if we have any views that were injected
                    var contentControl = item as ContentControl;
                    if (contentControl != null)
                    {
                        var injectedView = contentControl.Content;
                        if (Region.Views.Contains(injectedView) && !this.Region.ActiveViews.Contains(injectedView))
                            Region.Activate(injectedView);
                    }
                }
            }

        }
    }
}
