using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace WpfAppProject
{
    public class PersonInfo
    {
        public int no { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public string seibetu { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
    }
    class MyListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private double clientWidth;
        public double ClientWidth
        {
            get
            {
                return clientWidth;
            }
            set
            {
                clientWidth = value;
                NotifyPropertyChanged();
            }
        }

        private double clientHeight;
        public double ClientHeight
        {
            get
            {
                return clientHeight;
            }
            set
            {
                clientHeight = value;
                NotifyPropertyChanged();
            }
        }

        private List<PersonInfo> personDatas = new List<PersonInfo>();
        public List<PersonInfo> PersonDatas
        {
            get
            {
                return personDatas;
            }
        }
        public PersonInfo PersonDataAdd
        {
            set
            {
                PersonInfo data = value;
                data.no = personDatas.Count + 1;
                personDatas.Add(data);
                NotifyPropertyChanged();
            }
        }
    }
}
