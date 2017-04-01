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

namespace DataGrid練習 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }

    public class MainViewModel {
        public MainViewModel() {
            SexTypeValues = Enum.GetValues(typeof(SexType));
            People = new ObservableCollection<Person>() {
                    new Person() {
                        Name = "佐藤",
                        Age = 20,
                        Sex = SexType.Man,
                        Address = "四天王寺夕陽丘",
                    },
                    new Person() {
                        Name = "岡本",
                        Age = 25,
                        Sex = SexType.Woman,
                        Address = "東京都",
                    },
                    new Person() {
                        Name = "ミッツマングローブ",
                        Age = 40,
                        Sex = SexType.Middle,
                        Address = "千葉県",
                        Numbers = new List<int>() {
                            1,2,3
                        },
                    },
            };

            Nums = new [] {
                1,2,3
            };
        }
        public ObservableCollection<Person> People { get; set; }
        public object SexTypeValues { get; set; }
        public int[] Nums { get; set; }
    }

    public class Person {
        public string Name { get; set; }
        public uint Age { get; set; }
        public string Address { get; set; }
        private SexType _Sex;
        public SexType Sex {
            get { return _Sex; }
            set {
                _Sex = value;
            }
        }
        public List<int> Numbers { get; set; }
    }

    public enum SexType {
        Man,
        Woman,
        Middle,
    }
}
