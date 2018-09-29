using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFLSMUN
{
    /// <summary>
    /// Interaction logic for Window10.xaml
    /// </summary>
    public partial class Window10 : Window
    {
        public string total;
        MainWindow mw1;
        public Window10(MainWindow mw)
        {
            InitializeComponent();
            mw1 = mw;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            string name1 = name.Text;
            if (String.IsNullOrEmpty(name1) == true)
                System.Windows.MessageBox.Show("请检查动议人是否输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                total = name1 + "\r\n" + "动议 结束会议" + "\r\n";
                mw1.log.AppendText(total);
                mw1.log.Select(mw1.log.TextLength, 0);
                mw1.log.ScrollToCaret();
                mw1.log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
                this.Close();
            }
        }
    }
}
