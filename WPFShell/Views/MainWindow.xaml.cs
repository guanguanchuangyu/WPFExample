using Prism.Modularity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFModuleCore;
using WPFShell.ViewModels;

namespace WPFShell.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MainWindowViewModel _viewModel;
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             ListBox listBox = sender as ListBox;
            if (listBox != null) { 
                var selectedItem = listBox.SelectedItem as ModuleMeta;
                if (selectedItem != null)
                {
                    _viewModel.LoadContent(selectedItem.ModuleName, $"{selectedItem.ModuleName}Content");
                }
            }
        }
    }
}