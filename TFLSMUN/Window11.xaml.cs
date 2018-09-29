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
    /// Interaction logic for Window11.xaml
    /// </summary>
    public partial class Window11 : Window
    {
        MainWindow mw1;
        public Window11(MainWindow mw)
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
            if (rd1.IsChecked == false && rd2.IsChecked == false && rd3.IsChecked == false && rd4.IsChecked == false)
            {
                System.Windows.MessageBox.Show("请检查是否选择选项", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (rd1.IsChecked == true)
            {
                mw1.log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
                mw1.log.AppendText("让渡给主席\r\n");
            }
            if (rd2.IsChecked == true)
            {
                if (String.IsNullOrEmpty(name.Text) == true)
                {
                    System.Windows.MessageBox.Show("请检查代表名是否输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                mw1.log.AppendText("让渡给" + "代表" + name.Text + "\r\n");
            }
            if (rd3.IsChecked == true)
            {
                mw1.log.AppendText("让渡给问题\r\n");
            }
            if (rd4.IsChecked == true)
            {
                mw1.log.AppendText("让渡给评论\r\n");
            }
            mw1.log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
            this.Close();
        }

        private void rd1_Checked(object sender, RoutedEventArgs e)
        {
            label1.IsEnabled = true;
            rd2.IsChecked = false;
            rd3.IsChecked = false;
            rd4.IsChecked = false;
            label2.IsEnabled = false;
            label3.IsEnabled = false;
            label4.IsEnabled = false;
            label5.IsEnabled = false;
            name.IsEnabled = false;
        }

        private void rd2_Checked(object sender, RoutedEventArgs e)
        {
            label1.IsEnabled = false;
            rd1.IsChecked = false;
            rd3.IsChecked = false;
            rd4.IsChecked = false;
            label2.IsEnabled = true;
            label3.IsEnabled = true;
            label4.IsEnabled = false;
            label5.IsEnabled = false;
            name.IsEnabled = true;
        }

        private void rd3_Checked(object sender, RoutedEventArgs e)
        {
            label1.IsEnabled = false;
            rd2.IsChecked = false;
            rd1.IsChecked = false;
            rd4.IsChecked = false;
            label2.IsEnabled = false;
            label3.IsEnabled = false;
            label4.IsEnabled = true;
            label5.IsEnabled = false;
            name.IsEnabled = false;
        }

        private void rd4_Checked(object sender, RoutedEventArgs e)
        {
            label1.IsEnabled = false;
            rd2.IsChecked = false;
            rd3.IsChecked = false;
            rd1.IsChecked = false;
            label2.IsEnabled = false;
            label3.IsEnabled = false;
            label4.IsEnabled = false;
            label5.IsEnabled = true;
            name.IsEnabled = false;
        }

    }
}
