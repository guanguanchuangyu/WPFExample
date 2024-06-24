using System.Diagnostics;
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

namespace WPFSelectedRange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += Window_Loaded;
        }

        // 当前选中初始状态
        private bool currentState;
        // 选中范围起始索引
        private int startIndex=int.MinValue,endIndex=int.MaxValue;
        // 临时选中项字典
        Dictionary<int,BoxItemViewModel> tempSelectItems = new Dictionary<int, BoxItemViewModel>();
        // 鼠标键下事件
        private void UniformGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tempSelectItems.Clear();
            // 容器获取ContentPresenter上下文
            if (e.Source is ContentPresenter content)
            {
                if (content.Content is BoxItemViewModel vm)
                {
                    vm.IsSelected = !vm.IsSelected;
                    currentState = vm.IsSelected;
                    Debug.WriteLine($"容器键下,当前所在项:{vm.Name}:{currentState}");
                    // 获取当前索引
                    startIndex = mainWindowViewModel.BoxItemViewModels.IndexOf(vm);
                }
            }
        }
        // 鼠标键起事件
        private void UniformGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 容器获取ContentPresenter上下文
            if (e.Source is ContentPresenter content)
            {
                if (content.Content is BoxItemViewModel vm)
                {
                    Debug.WriteLine($"容器键起,当前所在项:{vm.Name}");
                    // 获取当前索引
                    endIndex = mainWindowViewModel.BoxItemViewModels.IndexOf(vm);
                    foreach (var item in tempSelectItems)
                    {
                        item.Value.IsSelected = currentState;
                    }
                }
            }

            // 选中范围
            Debug.WriteLine($"起始索引:{startIndex}|终止索引:{endIndex}");

        }
        // 鼠标移动事件
        private void UniformGrid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            // 容器获取ContentPresenter上下文
            if (e.LeftButton == MouseButtonState.Pressed && e.Source is ContentPresenter content)
            {
                if (content.Content is BoxItemViewModel vm)
                {
                    Debug.WriteLine($"容器移动,当前所在项:{vm.Name}");
                    // 获取当前索引
                    endIndex = mainWindowViewModel.BoxItemViewModels.IndexOf(vm);
                    // 移动时，动态缓存临时项
                    // 如果临时项多余目标移动项，则清除多余项
                    if (tempSelectItems.Count() != 0 && Math.Abs(startIndex - endIndex) < tempSelectItems.Count())
                    {
                        // 顺序生成选中项索引集合
                        int[] containerids = Enumerable.Range(Math.Min(startIndex, endIndex), Math.Abs(startIndex - endIndex)).ToArray();
                        // 清除多余项
                        int[] removeids = tempSelectItems.Keys.Except(containerids).ToArray();
                        foreach (var item in removeids)
                        {
                            if (item != startIndex || item != endIndex)
                            {
                                tempSelectItems[item].IsSelected = !currentState;
                                tempSelectItems.Remove(item);
                            }
                        }
                    }
                    // 起始索引与终止索引不相等咋进行选中项操作
                    if (startIndex != endIndex)
                    {
                        int index = startIndex - endIndex;
                        // 选中范围起始索引与终止索引是否顺序操作
                        int start = startIndex < endIndex ? startIndex : endIndex;
                        int end = startIndex < endIndex ? endIndex : startIndex;
                        // 遍历设置选中项状态为当前状态
                        for (int i = start; i <= end; i++)
                        {
                            mainWindowViewModel.BoxItemViewModels[i].IsSelected = currentState;
                            // 并判定项是否临时项中，不在则添加
                            if (!tempSelectItems.ContainsKey(i))
                            {
                                tempSelectItems.Add(i, mainWindowViewModel.BoxItemViewModels[i]);
                            }
                        }
                    }
                }
            }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel = DataContext as MainWindowViewModel;
        }
    }
}