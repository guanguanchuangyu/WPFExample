using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFImageExplorer.Models;

namespace WPFImageExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_selected_Click(object sender, RoutedEventArgs e)
        {
            string folder = @"E:\Life\Backgorunds";
            DateTime startdate = DateTime.Parse("2015/01/01");
            DateTime enddate = DateTime.Parse("2022/02/01");

            System.IO.FileInfo[] files = new System.IO.DirectoryInfo(folder).GetFiles("*.jpg").Where(x => x.LastWriteTime >= startdate && x.LastWriteTime <= enddate).OrderBy(x => x.LastWriteTime).Take(100).ToArray();
            int count = files.Length;
            ImageCollection images = new ImageCollection();
            for (int i = 0; i < count; i++)
            {
                images.Add(new ImageObject(files[i]));
            }
            ImageLst.ItemsSource = images;
        }

        private void ImageLst_Selected(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;
            if (listbox != null)
            {
                // 默认选中项触发-1结束执行
                if (listbox.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    var img = listbox.SelectedItem as ImageObject;
                    if (img != null)
                    {
                        if (File.Exists(img.Path))
                        {
                            ImageViewer.ImageSource = BitmapFrame.Create(new Uri(img.Path, UriKind.Absolute));
                            FileInfo fileInfo = new FileInfo(img.Path);
                            DrawerLeft.IsOpen = true;
                        }
                    }
                    // 设置选中项为-1
                    listbox.SelectedIndex = -1;
                }
            }
            e.Handled = false;
        }

        private void btn_nomal_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
             if (radioButton != null)
            {
                string tag = radioButton.Tag?.ToString();
                if (string.IsNullOrEmpty(tag))
                {
                    return;
                }

                string strkey = $"ListBox.{tag}";
                //var stylekey = ImageLst.FindResource(strkey);
                //if (stylekey != null)
                //{
                //    return;
                //}
                var keystyle = FindResource(strkey) as Style;
                if (keystyle != null) {
                    ImageLst.Style = keystyle;
                }
            }
        }
    }
}
