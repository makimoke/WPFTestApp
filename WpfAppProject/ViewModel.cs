using System;
using System.Configuration;
using System.Windows;
using Reactive.Bindings;

namespace WpfAppProject
{
    internal class ViewModel : DependencyObject
    {
        public ReactiveProperty<string> FirstName { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> LastName { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Explanation { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<SexType> Sex { get; set; } = new ReactiveProperty<SexType>();

        //依存関係プロパティ
        public static readonly DependencyProperty DescribeProperty =
            DependencyProperty.Register(
                name: "Describe",
                propertyType: typeof(string),
                ownerType: typeof(ViewModel),
                typeMetadata: new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnDescribeChanged)));

        private static void OnDescribeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine($"OnDescribeChanged:{e.OldValue}=>{e.NewValue}");
        }

        public string Describe
        {
            get => (string)GetValue(DescribeProperty);
            set => SetValue(DescribeProperty, value);
        }

        public void LoadData()
        {
            FirstName.Value = ConfigurationManager.AppSettings["FirstName"];
            LastName.Value = ConfigurationManager.AppSettings["LastName"];
            Explanation.Value = ConfigurationManager.AppSettings["Explanation"];
            var sex = ConfigurationManager.AppSettings["Sex"];
            Sex.Value = sex == null ? SexType.Male : (SexType)Enum.Parse(typeof(SexType), sex);
        }

        public void SaveData()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["FirstName"].Value = FirstName.Value;
            config.AppSettings.Settings["LastName"].Value = LastName.Value;
            config.AppSettings.Settings["Explanation"].Value = Explanation.Value;
            config.AppSettings.Settings["Sex"].Value = Sex.Value.ToString();
            config.Save();
        }
    }
}
