using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
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
using System.Windows.Threading;

namespace TFLSMUN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        timer1 timer111;
        timer2 timer222;
        public MainWindow()
        {
            InitializeComponent();
            mainspeakinglist.SelectionColor = System.Drawing.Color.Black;
            mainspeakinglist.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
            log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
            System.Windows.MessageBox.Show("本程序为模拟联合国会议记录器 Alpha 6，由小狼在进军和小朵编写，修正了一些已知的bug。", "软件通知", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void deletespeak_Click(object sender, RoutedEventArgs e)
        {
            mainspeakinglist.SelectionColor = System.Drawing.Color.Red;
        }

        private void mainspeakinglist_SelectionChanged(object sender, EventArgs e)
        {
            mainspeakinglist.SelectionColor = System.Drawing.Color.Black;
            mainspeakinglist.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "文本文档|*.txt|所有文件|*.*";
            save.ShowDialog();
            string savelj = save.FileName;
            if (String.IsNullOrEmpty(savelj) == false)
            {
                StreamWriter save1 = new StreamWriter(savelj);
                save1.Write(this.mainspeakinglist.Text.Replace("\n", "\r\n"));
                save1.Close();
            }
        }

        private void mc_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1(this);
            win1.Show();
            win1.Activate();
        }


        private void umc_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2(this);
            win2.Show();
            win2.Activate();
        }

        private void changetime_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3(this);
            win3.Show();
            win3.Activate();
        }

        private void DRorder_Click(object sender, RoutedEventArgs e)
        {
            Window4 win4 = new Window4(this);
            win4.Show();
            win4.Activate();
        }

        private void pausemeeting_Click(object sender, RoutedEventArgs e)
        {
            Window5 win5 = new Window5(this);
            win5.Show();
            win5.Activate();
        }

        private void freedebate_Click(object sender, RoutedEventArgs e)
        {
            Window6 win6 = new Window6(this);
            win6.Show();
            win6.Activate();
        }

        private void stopdebate_Click(object sender, RoutedEventArgs e)
        {
            Window7 win7 = new Window7(this);
            win7.Show();
            win7.Activate();
        }

        private void yqdy_Click(object sender, RoutedEventArgs e)
        {
            Window8 win8 = new Window8(this);
            win8.Show();
            win8.Activate();
        }

        private void ycdy_Click(object sender, RoutedEventArgs e)
        {
            Window9 win9 = new Window9(this);
            win9.Show();
            win9.Activate();
        }

        private void jshy_Click(object sender, RoutedEventArgs e)
        {
            Window10 win10 = new Window10(this);
            win10.Show();
            win10.Activate();
        }

        private void pass_Click(object sender, RoutedEventArgs e)
        {
            log.AppendText("通过\r\n");
            this.log.Select(this.log.TextLength, 0);
            this.log.ScrollToCaret();
            log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
        }

        private void unpass_Click(object sender, RoutedEventArgs e)
        {
            log.AppendText("未通过\r\n");
            this.log.Select(this.log.TextLength, 0);
            this.log.ScrollToCaret();
            log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
        }

        private void savelog_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savelog = new SaveFileDialog();
            savelog.Filter = "文本文档|*.txt|所有文件|*.*";
            savelog.ShowDialog();
            string savelj = savelog.FileName;
            if (String.IsNullOrEmpty(savelj) == false)
            {
                StreamWriter save1 = new StreamWriter(savelj);
                save1.Write(this.log.Text.Replace("\n", "\r\n"));
                save1.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public string Curr_time1
        {
            get
            {
                return time1.Content.ToString();
            }
            set
            {
                time1.Content = value;
            }
        }

        private void timelimit1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(timelimit1.Text) == true)
            {
                timestart1.IsEnabled = false;
            }
            else
            {
                timestart1.IsEnabled = true;
            }
        }

        private void timelimit2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(timelimit2.Text) == true)
            {
                timestart2.IsEnabled = false;
            }
            else
            {
                timestart2.IsEnabled = true;
            }
        }

        public string Curr_time2
        {
            get
            {
                return time2.Content.ToString();
            }
            set
            {
                time2.Content = value;
            }
        }

        private void timestart1_Click(object sender, RoutedEventArgs e)
        {
            string timelimit11 = timelimit1.Text;
            try
            {
                int.Parse(timelimit11);
            }
            catch
            {
                System.Windows.MessageBox.Show("请检查你所输入的数据格式是否正确（阿拉伯数字）", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int m = 0, s = 0;
            int t = int.Parse(timelimit11);
            s = t;
            while (s >= 60)
            {
                m++;
                s -= 60;
            }
            if (timer111 == null)
            {
                timer111 = new timer1(this, 0, m, s+1);
                timer111.timer11.Start();
                timepause1.IsEnabled = true;
            }
            else
            {
                timer111.timer11.Stop();
                timer111 = new timer1(this, 0, m, s+1);
                timer111.timer11.Start();
                timepause1.IsEnabled = true;
            }
            if (timestart1.Content.ToString() == "开始") timestart1.Content = "更改";
        }

        private void timepause1_Click(object sender, RoutedEventArgs e)
        {
            timer111.timer11.Stop();
            continue1.IsEnabled=true;
            timepause1.IsEnabled = false;
        }

        private void continue_Click(object sender, RoutedEventArgs e)
        {
            timer111.timer11.Start();
            continue1.IsEnabled = false;
            timepause1.IsEnabled = true;
        }

        private void timestart2_Click(object sender, RoutedEventArgs e)
        {
            string timelimit21 = timelimit2.Text;
            try
            {
                int.Parse(timelimit21);
            }
            catch
            {
                System.Windows.MessageBox.Show("请检查你所输入的数据格式是否正确（阿拉伯数字）", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int m = 0, s = 0;
            int t = int.Parse(timelimit21);
            s = t;
            while (s >= 60)
            {
                m++;
                s -= 60;
            }
            if (timer222 == null)
            {
                timer222 = new timer2(this, 0, m, s + 1);
                timer222.timer22.Start();
                timepause2.IsEnabled = true;
            }
            else
            {
                timer222.timer22.Stop();
                timer222 = new timer2(this, 0, m, s + 1);
                timer222.timer22.Start();
                timepause2.IsEnabled = true;
            }
            if (timestart2.Content.ToString() == "开始") timestart2.Content = "更改";
        }

        private void timepause2_Click(object sender, RoutedEventArgs e)
        {
            timer222.timer22.Stop();
            continue2.IsEnabled = true;
            timepause2.IsEnabled = false;
        }

        private void continue2_Click(object sender, RoutedEventArgs e)
        {
            timer222.timer22.Start();
            continue2.IsEnabled = false;
            timepause2.IsEnabled = true;
        }

        private void yd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(yd.Text) == false && String.IsNullOrEmpty(sd.Text) == false) count.IsEnabled = true;
            else count.IsEnabled = false;
        }

        private void sd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(yd.Text) == false && String.IsNullOrEmpty(sd.Text) == false) count.IsEnabled = true;
            else count.IsEnabled = false;
        }

        private void count_Click(object sender, RoutedEventArgs e)
        {
            double ydn, sdn;
            try
            {
                ydn = int.Parse(yd.Text);
            }
            catch
            {
                System.Windows.MessageBox.Show("请检查应到人数的格式是否正确（阿拉伯数字）", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            try
            {
                ydn = int.Parse(yd.Text);
                sdn = int.Parse(sd.Text);
            }
            catch
            {
                System.Windows.MessageBox.Show("请检查实到人数的格式是否正确（阿拉伯数字）", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                double wdn = 0;
                double simpledsn = 0, jddsn = 0, p20dsn = 0,sfzydsn=0;
                wdn = ydn - sdn;
                if (wdn < 0)
                {
                    System.Windows.MessageBox.Show("未到人数小于0，请检查数据输入", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                wd.Text = wdn.ToString();
                simpledsn = Math.Floor(sdn / 2 )+ 1;
                simpleds.Text = simpledsn.ToString() ;
                jddsn = Math.Floor(sdn * 2 / 3) + 1;
                jdds.Text = jddsn.ToString();
                p20dsn = Math.Ceiling(sdn * 0.2);
                p20ds.Text = p20dsn.ToString();
                sfzydsn = Math.Ceiling(sdn / 3);
                sfzyds.Text = sfzydsn.ToString();
            }
            catch
            {
                System.Windows.MessageBox.Show("计算错误，请检查您所输入的数据", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void log_SizeChanged(object sender, EventArgs e)
        {
            log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
        }

        private void rd_Click(object sender, RoutedEventArgs e)
        {
            Window11 win11 = new Window11(this);
            win11.Show();
            win11.Activate();
        }

        private void log_SelectionChanged(object sender, EventArgs e)
        {
            log.SelectionFont = new Font("Microsoft YaHei", 20, System.Drawing.FontStyle.Regular);
        }

    }

    public class timer1
    {
        int h = 0, m = 0, s = 0;
        public DispatcherTimer timer11;
        MainWindow mw1;
        public timer1(MainWindow mw,int h1, int m1, int s1)
        {
            mw1 = mw;
            h = h1;
            m = m1;
            s = s1;
            timer11 = new DispatcherTimer();
            timer11.Tick += new EventHandler(timer11_Tick);
            timer11.Interval = new TimeSpan(10000000);
        }

        void timer11_Tick(object sender, EventArgs e)
        {
            if (m != 0 || s != 0)
            {
                if (s == 0)
                {
                    m--;
                    s = 59;
                }
                else
                {
                    s--;
                }
                if (m == 0 && s <= 10) mw1.time1.Foreground = System.Windows.Media.Brushes.Red;
                else mw1.time1.Foreground = System.Windows.Media.Brushes.White;
                if (m == 0 && s == 10) Console.Beep();
                if (m == 0 && s == 0)
                {
                    Console.Beep();
                    timer11.Stop();
                    mw1.time1.Foreground = System.Windows.Media.Brushes.White;
                    mw1.timepause1.IsEnabled = false;
                    mw1.continue1.IsEnabled = false;
                    mw1.timestart1.Content = "开始";
                }
                if (m >= 10 && s >= 10) mw1.Curr_time1 = m.ToString() + ":" + s.ToString();
                else if (m >= 10 && s < 10) mw1.Curr_time1 = m.ToString() + ":" + "0" + s.ToString();
                else if (m < 10 && s >= 10) mw1.Curr_time1 = "0" + m.ToString() + ":" + s.ToString();
                else if (m < 10 && s < 10) mw1.Curr_time1 = "0" + m.ToString() + ":" + "0" + s.ToString();
            }
        }

    }

    public class timer2
    {
        int h = 0, m = 0, s = 0;
        MainWindow mw1;
        public DispatcherTimer timer22;
        public timer2(MainWindow mw, int h1, int m1, int s1)
        {
            mw1 = mw;
            h = h1;
            m = m1;
            s = s1;
            if (timer22 == null)
            {
                timer22 = new DispatcherTimer();
                timer22.Tick += new EventHandler(timer22_Tick);
                timer22.Interval = new TimeSpan(10000000);
            }
            else
            {
                timer22 = null;
                timer22 = new DispatcherTimer();
                timer22.Tick += new EventHandler(timer22_Tick);
                timer22.Interval = new TimeSpan(10000000);
            }
        }

        void timer22_Tick(object sender, EventArgs e)
        {
            if (m != 0 || s != 0)
            {
                if (s == 0)
                {
                    m--;
                    s = 59;
                }
                else
                {
                    s--;
                }
                if (m == 0 && s <= 10) mw1.time2.Foreground = System.Windows.Media.Brushes.Red;
                else mw1.time2.Foreground = System.Windows.Media.Brushes.White;
                if (m == 0 && s == 10) Console.Beep();
                if (m == 0 && s == 0)
                {
                    Console.Beep();
                    timer22.Stop();
                    mw1.time2.Foreground = System.Windows.Media.Brushes.White;
                    mw1.timepause2.IsEnabled = false;
                    mw1.continue2.IsEnabled = false;
                    mw1.timestart2.Content = "开始";
                }
                if (m >= 10 && s >= 10) mw1.Curr_time2 = m.ToString() + ":" + s.ToString();
                else if (m >= 10 && s < 10) mw1.Curr_time2 = m.ToString() + ":" + "0"+ s.ToString();
                else if (m < 10 && s >= 10) mw1.Curr_time2 = "0" + m.ToString() + ":" + s.ToString();
                else if (m < 10 && s < 10) mw1.Curr_time2 = "0" + m.ToString() + ":" + "0"+ s.ToString();
            }
        }

    }

}
