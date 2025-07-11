using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using RM.Friendly.WPFStandardControls;
using Codeer.Friendly.Dynamic;
using System.Threading.Tasks;
using System.Windows;
//using Codeer.Friendly.Windows.KeyMouse;
//using RM.Friendly.WPFStandardControls;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// テストパラメータを使用するためのプロパティ宣言
        /// http://neue.cc/2011/02/23_304.html
        /// </summary>
        public TestContext TestContext { get; set; }

        private WindowsAppFriend _app;
        private TestDriver _drv;

        [TestInitialize]
        public void TestInitialize()
        {
            // Execute target process and attach
            //var path = System.IO.Path.GetFullPath(@"..\..\..\WpfAppProject\\bin\Debug\WpfAppProject.exe");
            var path = System.IO.Path.GetFullPath(@"WpfAppProject.exe");
            Console.WriteLine("path="+path);
            _app = new WindowsAppFriend(Process.Start(path));
            var w = _app.IdentifyFromTypeFullName("WpfAppProject.MainWindow");
            _drv = new TestDriver(w);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // SoftwareKeyboardTestAppの終了
            Process process = Process.GetProcessById(_app.ProcessId);
            _app.Dispose();
            process.CloseMainWindow();
        }

        // 保存テスト
        [TestMethod, Timeout(5000)]
        public void TestSave()
        {
            // テキスト入力
            _drv.tbFirstName.EmulateChangeText("苗字");
            _drv.tbLastName.EmulateChangeText("名前");
            _drv.tbExplanation.EmulateChangeText("せつめい");

            var rbFemale = _drv.GetRadioButton("女");
            rbFemale.EmulateClick();

            var async = new Async();
            var btnSave = _drv.GetButton("保存");
            btnSave.EmulateClick(async);

            //var mainWindow = new WindowControl(_app);

            //モーダルダイアログが表示されるのを確実に待ち合わせる
            var dlg = _drv.MainWindow.WaitForNextModal();
            //var dlg = mainWindow.WaitForNextModal();

            //ダイアログ上のボタンを押す、dlgからしか取れません。
            var buttonOK = new WPFButtonBase(dlg.Dynamic()._buttonOK);
            buttonOK.EmulateClick();

            async.WaitForCompletion();
        }
    }
}
