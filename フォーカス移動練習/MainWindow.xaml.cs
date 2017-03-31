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

namespace フォーカス移動練習
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combo = new List<string>()
            {
                "aa",
                "b",
                "c",
                "d",
            };
            this.DataContext = combo;

            // Enter キーでフォーカス移動する
            this.KeyDown += (sender, e) =>
            {
                var keys = Keyboard.Modifiers;
                var focus = FocusManager.GetFocusedElement(this);
                if (e.Key != Key.Enter) { return; }

                FocusNavigationDirection direction;
                if (Keyboard.Modifiers == ModifierKeys.Shift) {
                    direction = FocusNavigationDirection.Previous;
                }else {
                    direction = FocusNavigationDirection.Next;
                }
                FrameworkElement element = (FrameworkElement)FocusManager.GetFocusedElement(this);
                if (element != null) {
                    element.MoveFocus(new TraversalRequest(direction));
                }
            };

            //ラジオボタンでエンターキー送りをブロックする
            this.rbC1.KeyDown += (sender, e) => {
                if (e.Key == Key.Enter) {
                    e.Handled = true;
                }
            };
        }

        private List<string> combo;
    }
}
