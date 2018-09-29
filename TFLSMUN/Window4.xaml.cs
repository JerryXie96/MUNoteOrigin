﻿using System;
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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public string total;
        MainWindow mw1;
        public Window4(MainWindow mw)
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
            string name1 = name.Text, yxh1 = yxh.Text,xghxh1=xghxh.Text;
            if (String.IsNullOrEmpty(name1) == true)
                System.Windows.MessageBox.Show("请检查动议人是否输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else if(String.IsNullOrEmpty(yxh1)==true)
                System.Windows.MessageBox.Show("请检查原序号是否输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else if(String.IsNullOrEmpty(xghxh1)==true)
                System.Windows.MessageBox.Show("请检查修改后序号是否输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                total = name1 + "\r\n" + "动议更改决议草案投票顺序" + "将原" + yxh1 + "更改至" + xghxh1 + "\r\n";
                mw1.log.AppendText(total);
                mw1.log.Select(mw1.log.TextLength, 0);
                mw1.log.ScrollToCaret();
                mw1.log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
                this.Close();
            }
        }
    }
}
