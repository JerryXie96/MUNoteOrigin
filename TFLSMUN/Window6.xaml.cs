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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public string total;
        MainWindow mw1;
        public Window6(MainWindow mw)
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
            string name11 = name1.Text, name21 = name2.Text, totaltime1 = totaltime.Text;
            if (String.IsNullOrEmpty(name11) == true)
                System.Windows.MessageBox.Show("请检查动议人是否输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else if(String.IsNullOrEmpty(name21)==true)
                System.Windows.MessageBox.Show("请检查针对人是否输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else if(String.IsNullOrEmpty(totaltime1)==true)
                System.Windows.MessageBox.Show("请检查总时间是否输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                try
                {
                    int.Parse(totaltime1);
                }
                catch
                {
                    System.Windows.MessageBox.Show("请检查总时间的格式是否正确（阿拉伯数字）", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                total = name11 + "\r\n" + "动议针对" + name21 + "的针对性辩论" + "\r\n" + "总时间" + totaltime1 + "分钟" + "\r\n";
                mw1.log.AppendText(total);
                mw1.log.Select(mw1.log.TextLength, 0);
                mw1.log.ScrollToCaret();
                mw1.log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
                this.Close();
            }
        }
    }
}
