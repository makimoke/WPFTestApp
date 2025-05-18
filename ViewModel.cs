using System.Configuration;
using System.Windows;
using Reactive.Bindings;

namespace WPFTestApp
{
    internal class ViewModel
    {
        public ReactiveProperty<string> FirstName { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> LastName { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Explanation { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<SexType> Sex { get; set; } = new ReactiveProperty<SexType>();

        public void LoadData()
        {
            FirstName.Value = ConfigurationManager.AppSettings["FirstName"];
            LastName.Value = ConfigurationManager.AppSettings["LastName"];
            Explanation.Value = ConfigurationManager.AppSettings["Explanation"];
            var sex = ConfigurationManager.AppSettings["Sex"];
            Sex.Value = (SexType)Enum.Parse(typeof(SexType), sex);
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
