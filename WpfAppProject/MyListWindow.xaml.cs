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
using System.Windows.Shapes;
using System.Globalization;

namespace WpfAppProject
{
    /// <summary>
    /// MyListWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MyListWindow : Window
    {
        private MyListViewModel _viewModel;

        public MyListWindow()
        {
            // XAMLでStaticResourceとしてInvertBooleanConverterを使用するために、リソースとして追加します。
            this.Resources.Add("InvertBooleanConverter", new InvertBooleanConverter());


            InitializeComponent();


            _viewModel = new MyListViewModel();

            DataContext = _viewModel;

            var person1 = new PersonInfo();
            person1.name = "東京太郎";
            person1.birthday = "19XX/01/01";
            person1.seibetu = "男";
            person1.address = "東京都XX区YY 〇-〇-〇";
            person1.phone = "090-XXXX-YYYY";
            person1.mail = "hoge@hoge.com";

            var person2 = new PersonInfo();
            person2.name = "大阪花子";
            person2.birthday = "20XX/02/02";
            person2.seibetu = "女";
            person2.address = "大阪府XX市YY 〇-〇-〇";
            person2.phone = "080-XXXX-YYYY";
            person2.mail = "sample@sample.com";

            var person3 = new PersonInfo();
            person3.name = "北海道次郎";
            person3.birthday = "20XX/02/02";
            person3.seibetu = "男";
            person3.address = "沖縄県XX市YY 〇-〇-〇";
            person3.phone = "080-XXXX-YYYY";
            person3.mail = "hogo@hogo.com";

            _viewModel.PersonDataAdd = person1;
            _viewModel.PersonDataAdd = person2;
            _viewModel.PersonDataAdd = person3;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            FrameworkElement frameworkElement = Content as FrameworkElement;
            _viewModel.ClientWidth = frameworkElement.ActualWidth;
            _viewModel.ClientHeight = frameworkElement.ActualHeight;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyListView.UnselectAll();
        }

        public class InvertBooleanConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool booleanValue)
                {
                    return !booleanValue;
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

    }
}
