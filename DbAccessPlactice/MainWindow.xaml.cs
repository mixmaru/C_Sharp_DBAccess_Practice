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
        public ICommand UpdateCommand { get; set; }

        private 社員Model 社員model = new 社員Model();

        private int 指定部門番号 = 10;

        public MainWindowViewModel()
        {
            this.reflesh社員viewModels();
            this.UpdateCommand = this.CreateCommand(this.UpdateExecute, this.CanUpdateExecute);
        }

        private void reflesh社員viewModels()
        {
            this.社員viewModels = this.Crate社員ViewModelsBy部門番号(this.指定部門番号);
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
                    性別ID = 1,
                };
                //コンボボックス用プロパティのセット
                obj.性別List = 性別Model.性別取得entityList;
                retList.Add(obj);
            }
            return retList;
        }

        private void UpdateExecute(object paramater)
        {
            //入力文字列でデータを更新する
            //更新用Listを作成する
            var updateDataList = new List<社員更新用entity>();
            foreach (var data in this.社員viewModels)
            {
                var obj = new 社員更新用entity()
                {
                    社員番号 = data.社員番号,
                    氏名 = data.氏名,
                    給与 = data.給与,
                    入社日 = data.入社日,
                    部門番号 = data.部門番号,
                };
                updateDataList.Add(obj);
            }
            //Modelへ更新を依頼する
            this.社員model.Update(updateDataList);
            //データ表示を更新する
            this.reflesh社員viewModels();
        }

        private bool CanUpdateExecute(object paramater)
        {
            return true;
        }
    }

    public class 社員ViewModel : ViewModelBase
    {
        private int? _社員番号;
        public int? 社員番号
        {
            get
            {
                return this._社員番号;
            }
            set
            {
                this._社員番号 = value;
                this.RaisePropertyChanged("社員番号");
            }
        }

        private string _氏名;
        public string 氏名
        {
            get
            {
                return this._氏名;
            }
            set
            {
                this._氏名 = value;
                this.RaisePropertyChanged("氏名");
            }
        }

        private decimal? _給与;
        public decimal? 給与
        {
            get
            {
                return this._給与;
            }
            set
            {
                this._給与 = value;
                this.RaisePropertyChanged("給与");
            }
        }

        private DateTime? _入社日;
        public DateTime? 入社日
        {
            get
            {
                return this._入社日;
            }
            set
            {
                this._入社日 = value;
                this.RaisePropertyChanged("入社日");
            }
        }

        private int _部門番号;
        public int 部門番号
        {
            get
            {
                return this._部門番号;
            }
            set
            {
                this._部門番号 = value;
                this.RaisePropertyChanged("_部門番号");
            }
        }

        private int _性別ID;
        public int 性別ID
        {
            get { return this._性別ID; }
            set
            {
                this._性別ID = value;
                this.RaisePropertyChanged("性別ID");

                //このタイミングでコンボボックスを変更してみる
                var list = new List<性別取得Entity>();
                list.Add(new 性別取得Entity()
                {
                    ID = 3,
                    name = "お釜",
                });
                list.Add(new 性別取得Entity()
                {
                    ID = 4,
                    name = "アナコンダ",
                });
                this.性別List = list;
            }
        }

        private List<性別取得Entity> _性別List;
        public List<性別取得Entity> 性別List
        {
            get { return this._性別List; }
            set
            {
                this._性別List = value;

                this.RaisePropertyChanged("性別List");
            }
        }
    }
}
