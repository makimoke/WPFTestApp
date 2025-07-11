using System.Windows;

namespace WpfAppProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new ViewModel();
            DataContext = _viewModel;

            _viewModel.LoadData();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            //書き込み処理
            _viewModel.SaveData();

            System.Console.WriteLine($"MessageBox.Show this={this}");
            MessageBox.Show(this,"設定を保存しました");
        }
    }
}