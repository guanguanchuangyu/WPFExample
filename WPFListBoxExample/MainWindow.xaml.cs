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
using WPFListBoxExample.Views;

namespace WPFListBoxExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MenuContents.Add("Menu01", new MainContent() { BgSource = "pack://application:,,,/WPFListBoxExample;component/Resources/Images/1.jpg",Title= "Menu01" });
            MenuContents.Add("Menu02", new MainContent() { BgSource = "pack://application:,,,/WPFListBoxExample;component/Resources/Images/2.jpg",Title= "Menu02" });
            MenuContents.Add("Menu03", new MainContent() { BgSource = "pack://application:,,,/WPFListBoxExample;component/Resources/Images/3.jpg",Title= "Menu03" });
            MenuContents.Add("Menu04", new MainContent() { BgSource = "pack://application:,,,/WPFListBoxExample;component/Resources/Images/4.jpg", Title= "Menu04" });
        }

        Dictionary<string,MainContent> MenuContents = new Dictionary<string,MainContent>();

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ListBox listbox = sender as ListBox;
            if (listbox != null && listbox.SelectedItem != null)
            {
                ListBoxItem listBoxItem = listbox.SelectedItem as ListBoxItem;
                if (listBoxItem!= null)
                {
                    var menukey = listBoxItem.Content.ToString();
                    if (MenuContents.TryGetValue(menukey, out MainContent main))
                    {
                        MainCont.Content = main;
                    }
                }
            }
        }
    }
}