using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows.Grasp;
using RM.Friendly.WPFStandardControls;

namespace UnitTestProject
{
    public class TestDriver
    {
        public WindowControl MainWindow { get; private set; }
        public IWPFDependencyObjectCollection<DependencyObject> LogicalTree { get; }

        public WPFGrid grdMain { get; private set; }
        public WPFTextBox tbExplanation { get; private set; }
        public WPFTextBox tbLastName { get; private set; }
        public WPFTextBox tbFirstName { get; private set; }


        public TestDriver(WindowControl w)
        {
            MainWindow = w;
            LogicalTree = w.LogicalTree();

            tbExplanation = new WPFTextBox(LogicalTree.ByBinding("Explanation.Value").Single());
            tbLastName = new WPFTextBox(LogicalTree.ByBinding("LastName.Value").Single());
            tbFirstName = new WPFTextBox(LogicalTree.ByBinding("FirstName.Value").Single());
            grdMain = new WPFGrid(LogicalTree.ByType<Grid>().Single());


            PrintAllControlls<Button>();
        }

        public WPFButtonBase GetButton(string buttonCaption)
        {
            var btn = LogicalTree.ByType<Button>().ByContentText<Button>(buttonCaption).Single();
            if (btn == null) return null;
            return new WPFButtonBase(btn);
        }

        public WPFButtonBase GetRadioButton(string buttonCaption)
        {
            var btn = LogicalTree.ByType<RadioButton>().ByContentText<RadioButton>(buttonCaption).Single();
            if (btn == null) return null;
            return new WPFButtonBase(btn);
        }

        public void PrintAllControlls<T>() where T : DependencyObject
        {
            int index = 0;
            foreach(var obj in LogicalTree.ByType<T>().ToArray())
            {
                Console.WriteLine($"{index}:obj={obj} Type={obj.GetType()}");
                index++;
            }
        }

    }
}
