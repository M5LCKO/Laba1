using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Collections.ObjectModel;


namespace Laba_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ColumnChart.DataContext = valueList;
            ColumnChart1.DataContext = valueList1;
        }
        ObservableCollection<KeyValuePair<string, int>> valueList = new ObservableCollection<KeyValuePair<string, int>>();
        ObservableCollection<KeyValuePair<string, int>> valueList1 = new ObservableCollection<KeyValuePair<string, int>>();
        void Gen(ArrayList myAL)
        {
            
            try
            {
                valueList.Clear();
                valueList1.Clear();
                    int itemCount = Convert.ToInt32(tbN.Text);
               
                if (itemCount > 0)
                {
                    Random rnd1 = new Random();
                    int number;
                    int index;
                    lbMain.Items.Clear();
                    lbMain.Items.Add("Исходный массив");
                    for (index = 1; index <= itemCount; index++)
                    {
                        number = -100 + rnd1.Next(200);
                        myAL.Add(number);
                        lbMain.Items.Add(number);
                    }
                    for (index = 0; index < itemCount; index++)
                    {
                        int num = (int)myAL[index];
                        valueList.Add(new KeyValuePair<string,int>("",num));
                    }
                }
                else { MessageBox.Show("Вы забыли указать число или вы указали 0, либо число меньше нуля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch(FormatException) { MessageBox.Show("Вы забыли указать число или вы указали 0, либо число меньше нуля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            //Стулов Денис 3В 120871

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            Gen(myAL);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                myAL.Sort();
                lbMain.Items.Add("Отсортированный массив");
                foreach (int elem in myAL)
                {
                    lbMain.Items.Add(elem);
                }
                for (int i = 0; i < itemCount; i++)
                {
                    int num = (int)myAL[i];
                    valueList1.Add(new KeyValuePair<string, int>("", num));
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871

            Microsoft.Win32.SaveFileDialog myDialog = new Microsoft.Win32.SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbMain.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int count = 0;
                for (int i = 1; i < itemCount - 1; i++)
                {
                    if (((int)myAL[i] > (int)myAL[i - 1]) && ((int)myAL[i] > (int)myAL[i + 1]))
                        count++;
                }
                
                lbMain.Items.Add(String.Format("Количество чисел, которые больше своих соседей {0}", count));
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int buf = 0;
                for (int i = 0; i < itemCount; i++)
                {
                    if (((int)myAL[i] > 25) && (buf == 0))
                    {
                        buf++;
                        lbMain.Items.Add(String.Format("Число больше 25  находится на {0}позиции", i + 1));
                    }
                }
                if (buf == 0) lbMain.Items.Add("Чисел больше 25 нет");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0") && (tbN.Text != "1"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int sum = 0;
                for (int i = 0; i < itemCount; i++)
                {
                    if ((int)myAL[i] > (int)myAL[1])
                    {
                        sum += (i + 1);
                    }

                }
                lbMain.Items.Add(String.Format("Сумма элементов числа которых больше 2го элемента равна {0}", sum));
            }
            else lbMain.Items.Add(String.Format("Вы ввели колличество элементов меньше 2х"));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int buf = 0;
                Window1 k = new Window1();
                k.ShowDialog();
                for (int i = 0; i < itemCount; i++)
                {
                    if (((int)myAL[i] > k.k) && (buf == 0))
                    {
                        buf++;
                        lbMain.Items.Add(String.Format("Число больше {0} находится на {1} позиции", k.k, i + 1));
                    }
                }
                if(buf==0)
                { lbMain.Items.Add(String.Format("Чисел больше {0} нет", k.k)); }
            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int sum = 0;
                Window2 num = new Window2();
                num.ShowDialog();
                while((itemCount<num.num)&&(num.num != 0))
                {
                    Window2 p = new Window2();
                    p.ShowDialog();
                    num.num = p.num;
                }
                for (int i = 0; i < itemCount; i++)
                {
                    if ((int)myAL[i] > (int)myAL[num.num-1])
                    {
                        sum += (i + 1);
                    }

                }
                lbMain.Items.Add(String.Format("Сумма элементов числа которых больше {0}го элемента равна {1}", num.num, sum));
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int count = 0;
                int itemCount = Convert.ToInt32(tbN.Text);
                for (int i = 1; i < itemCount - 1; i++)
                    if (((int)myAL[i] > (int)myAL[i - 1]) && ((int)myAL[i] > (int)myAL[i + 1]))
                    {
                        lbMain.SelectedItems.Add(lbMain.Items[i+1]);
                        count++;
                    }
                lbMain.Items.Add(String.Format("Готово {0}",count));
            }

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int count = 0;
                for (int i = 1; i < itemCount-1; i++)
                {
                    if (((int)myAL[i] > (int)myAL[i - 1]) && ((int)myAL[i] > (int)myAL[i + 1]))
                        count++;
                }
                if (((int)myAL[0] > (int)myAL[itemCount-1]) && ((int)myAL[0] > (int)myAL[1]))
                    count++;
                if (((int)myAL[itemCount-1] > (int)myAL[itemCount - 2]) && ((int)myAL[itemCount-1] > (int)myAL[0]))
                    count++;
                lbMain.Items.Add(String.Format("Количество чисел, которые больше своих соседей {0}", count));
              //k
            }
        }
    }
}
