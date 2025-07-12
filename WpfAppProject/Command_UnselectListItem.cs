using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppProject
{
    //memo:使ってないけど、一応保存
    public class Command_UnselectListItem : ICommand
    {
        // 以下、ICommand用のプロパティ
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter)
        {
        }
    }
}
