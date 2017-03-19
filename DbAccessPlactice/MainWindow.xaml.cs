using DbAccessPlactice.Common;
using DbAccessPlactice.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DbAccessPlactice
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<社員ViewModel> 社員viewModels { get; set; }

        private 社員Model 社員model = new 社員Model();

        public MainWindowViewModel()
        {
            this.社員viewModels = this.Crate社員ViewModelsBy部門番号(10);
        }

        private ObservableCollection<社員ViewModel> Crate社員ViewModelsBy部門番号(int 部門番号)
        {
            var retList = new ObservableCollection<社員ViewModel>();
            foreach (var data in this.社員model.get社員ListBy部門番号(部門番号))
            {
                var obj = new 社員ViewModel()
                {
                    入社日 = data.入社日,
                    氏名 = data.氏名,
                    社員番号 = data.社員番号,
                    給与 = data.給与,
                    部門番号 = data.部門番号,
                };
                retList.Add(obj);
            }
            return retList;
        }
    }

    public class 社員ViewModel : ViewModelBase
    {
        public int 社員番号 { get; set; }
        public string 氏名 { get; set; }
        public decimal? 給与 { get; set; }
        public DateTime? 入社日 { get; set; }
        public int 部門番号 { get; set; }
    }
}
