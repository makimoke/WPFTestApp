using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WpfAppProject
{
    public class SelectorSelectAllAction : TriggerAction<DependencyObject>
    {
        /// <summary>
        /// When executing
        /// </summary>
        protected override void Invoke(object parameter)
        {
            if (TargetSelector == null)
            {
                return;
            }

            //ターゲットがListBoxの場合
            if (TargetSelector is ListBox)
            {
                //すべて選択の場合
                //((ListBox)TargetSelector).SelectAll();
                //すべて選択解除の場合
                ((ListBox)TargetSelector).UnselectAll();
                ((ListBox)TargetSelector).UpdateLayout();
                ((ListBox)TargetSelector).Focus();

            }
            //ターゲットがDataGridの場合
            else if (TargetSelector is DataGrid)
            {
                //すべて選択の場合
                //((DataGrid)TargetSelector).SelectAll();
                //すべて選択解除の場合
                ((DataGrid)TargetSelector).UnselectAll();
                ((DataGrid)TargetSelector).UpdateLayout();
                ((DataGrid)TargetSelector).Focus();
            }
        }

        #region TargetSelector property
        public static readonly DependencyProperty TargetSelectorProperty =
            DependencyProperty.Register("TargetSelector", typeof(Selector), typeof(SelectorSelectAllAction), new PropertyMetadata(null));

        //すべて選択・選択解除を行うターゲット
        public Selector TargetSelector
        {
            get { return (Selector)this.GetValue(TargetSelectorProperty); }
            set { this.SetValue(TargetSelectorProperty, value); }
        }
        #endregion
    }
}
