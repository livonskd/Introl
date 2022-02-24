using Introl.Theming;
using System.Windows;

namespace Introl.Demo.Views
{
    public partial class MainWindow : Window
    {
        private bool _isDark;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void ThemeChanging_OnClick(object sender, RoutedEventArgs e)
        {
            _isDark = !_isDark;

            Application.Current.Resources.SetTheme(_isDark ? BaseTheme.Dark : BaseTheme.Light);
        }
    }
}
