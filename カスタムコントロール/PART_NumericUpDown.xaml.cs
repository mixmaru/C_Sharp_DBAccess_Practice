using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace カスタムコントロール {
    /// <summary>
    /// PART_NumericUpDown.xaml の相互作用ロジック
    /// </summary>
    public partial class PART_NumericUpDown : UserControl,INotifyPropertyChanged {
        public PART_NumericUpDown() {
            InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "value",
            typeof(int),
            typeof(NumericUpDown),
            new PropertyMetadata(0)
            );

        public int Value {
            get { return (int)GetValue(ValueProperty); }
            set {
                SetValue(ValueProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RepeatButton_Click(object sender, RoutedEventArgs e) {
            this.Value++;
        }

        private void RepeatButton_Click_1(object sender, RoutedEventArgs e) {
            this.Value--;
        }
    }
}
