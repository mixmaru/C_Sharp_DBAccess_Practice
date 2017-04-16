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

namespace ユーザーコントロール練習 {
    /// <summary>
    /// 数値のみ許可TextBlock.xaml の相互作用ロジック
    /// </summary>
    public partial class 数値のみ許可TextBlock : UserControl, INotifyPropertyChanged {
        public 数値のみ許可TextBlock() {
            InitializeComponent();
            this.TextBlock.Text = Value.ToString();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(数値のみ許可TextBlock), new PropertyMetadata(0));

        public event PropertyChangedEventHandler PropertyChanged;

        public int Value {
            get {
                return (int)GetValue(ValueProperty);
            }
            set {
                //数値でなければ無視する?


                SetValue(ValueProperty, value);
                if(this.PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }

        private void TextBlock_LostFocus(object sender, RoutedEventArgs e) {
            int res;
            if (int.TryParse(this.TextBlock.Text, out res)) {
                Value = int.Parse(this.TextBlock.Text);
            }else {
                this.TextBlock.Text = Value.ToString();
            }
        }
    }
}
