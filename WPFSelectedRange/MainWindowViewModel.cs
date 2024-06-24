using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSelectedRange
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            BoxItemViewModels = new List<BoxItemViewModel>();
            for (int i = 0; i < 6; i++)
            {
                BoxItemViewModels.Add(new BoxItemViewModel() { Name = "Item" + i,ImagePath=@$"\Resources\Images\{i+1}.png" });
            }
        }

        // BoxItemViewModel集合
        private List<BoxItemViewModel> _boxItemViewModels;
        public List<BoxItemViewModel> BoxItemViewModels
        {
            get { return _boxItemViewModels; }
            set
            {
                if (_boxItemViewModels != value)
                {
                    _boxItemViewModels = value;
                }
            }
        }
    }
}
