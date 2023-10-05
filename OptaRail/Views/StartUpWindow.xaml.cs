using System.Windows;
using OptaRail.Core.Interfaces;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;

namespace OptaRail.Views
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : ChromelessWindow
    {
        public StartUpWindow()
        {
            SfSkinManager.ApplyStylesOnApplication = true;

            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindow vm)
            {
                vm.Close += () =>
                {
                    DialogResult = true;
                    this.Close();
                   
                };
            }
        }
    }
}
