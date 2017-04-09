using System;
using System.Collections.Generic;
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

namespace コンボボックスバグ調査 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

        }
    }

    public class ViewModel {

        public ViewModel() {
            PersonList = new List<Person>();
            var counter = 0;
            for (var i = 0; i < 5; i++) {
                PersonList.Add(new Person() {
                    Id = counter++,
                    Name = "孫悟空"+i,
                });
                PersonList.Add(new Person() {
                    Id = counter++,
                    Name = "ヤムチャ"+i,
                });
                PersonList.Add(new Person() {
                    Id = counter++,
                    Name = "ウーロン"+i,
                });
                PersonList.Add(new Person() {
                    Id = counter++,
                    Name = "プーアル"+i,
                });
            }

            技名List = new List<string>();
            技名List.Add("かめはめ波");
            技名List.Add("どどんぱ");
            技名List.Add("真観光殺法");
            技名List.Add("太陽兼");
            技名List.Add("残像兼");
        }

        public List<Person> PersonList { get; set; }
        public List<string> 技名List { get; set; }
    }

    public class Person {
        public int Id { get; set; }
        public string Name { set; get; }
    }
}
