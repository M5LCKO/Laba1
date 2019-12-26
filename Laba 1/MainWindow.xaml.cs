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
        //ObservableCollection<KeyValuePair<string, int>> valueList1 = new ObservableCollection<KeyValuePair<string, int>>();
        ObservableCollection<KeyValuePair<string, double>> valueList1 = new ObservableCollection<KeyValuePair<string, double>>();
        ArrayList Gen(ArrayList myAL)
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
                    valueList.Clear();
                    valueList1.Clear();
                    for (index = 0; index < itemCount; index++)
                    {
                        int num = (int)myAL[index];
                        valueList.Add(new KeyValuePair<string, int>("", num));
                    }
                    return myAL;
                }
                else { MessageBox.Show("Вы забыли указать число или вы указали 0, либо число меньше нуля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return myAL; }
            }
            catch (FormatException) { MessageBox.Show("Вы забыли указать число или вы указали 0, либо число меньше нуля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); tbN.Text = ""; return myAL; }
            //Стулов Денис 3В 120871

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                myAL.Sort();
                lbMain.Items.Add("Отсортированный массив");
                foreach (int elem in myAL)
                {
                    lbMain.Items.Add(elem);
                    valueList1.Add(new KeyValuePair<string, double>("", elem));
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
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
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
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
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
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
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
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
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
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
                if (buf == 0)
                { lbMain.Items.Add(String.Format("Чисел больше {0} нет", k.k)); }
            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int sum = 0;
                Window2 num = new Window2();
                num.ShowDialog();
                while ((itemCount < num.num) && (num.num != 0))
                {
                    Window2 p = new Window2();
                    p.ShowDialog();
                    num.num = p.num;
                }
                for (int i = 0; i < itemCount; i++)
                {
                    if ((int)myAL[i] > (int)myAL[num.num - 1])
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
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int count = 0;
                int itemCount = Convert.ToInt32(tbN.Text);
                for (int i = 1; i < itemCount - 1; i++)
                    if (((int)myAL[i] > (int)myAL[i - 1]) && ((int)myAL[i] > (int)myAL[i + 1]))
                    {
                        lbMain.SelectedItems.Add(lbMain.Items[i + 1]);
                        count++;
                    }
                lbMain.Items.Add(String.Format("Готово {0}", count));
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
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int count = 0;
                for (int i = 1; i < itemCount - 1; i++)
                {
                    if (((int)myAL[i] > (int)myAL[i - 1]) && ((int)myAL[i] > (int)myAL[i + 1]))
                        count -= -1;
                }
                if (((int)myAL[0] > (int)myAL[itemCount - 1]) && ((int)myAL[0] > (int)myAL[1]))
                    count -= -1;
                if (((int)myAL[itemCount - 1] > (int)myAL[itemCount - 2]) && ((int)myAL[itemCount - 1] > (int)myAL[0]))
                    count -= -1;
                lbMain.Items.Add(String.Format("Количество чисел, которые больше своих соседей {0}", count));
                //k
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                int min = 10000;
                int min_in = -1;
                double count = 0;
                for (int i = 0; i < itemCount; i++)
                {
                    count += (int)myAL[i];
                }
                count /= itemCount;
                lbMain.Items.Add(String.Format("Среднее занчение элементов массива {0}", count));
                for (int k = 0; k < itemCount; k++)
                {
                    if (((int)myAL[k] > count) && ((min > (int)myAL[k])))
                    {
                        min = (int)myAL[k];
                        min_in = k + 1;
                    }
                }
                if (min_in == -1)
                { lbMain.Items.Add(String.Format("нет элементов больше среднего арефметического ")); }
                lbMain.Items.Add(String.Format("число находится на позиции {0}", min_in));

            }

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                double count = 0;
                for (int i = 0; i < itemCount; i++)
                {
                    count += (int)myAL[i];
                }
                count /= itemCount;
                lbMain.Items.Add(String.Format("Среднее занчение элементов массива {0}", count));
                for (int k = 0; k < itemCount; k++)
                {
                    myAL[k] = Math.Abs(count - (int)myAL[k]);
                }
                lbMain.Items.Add("отклонение от среднего арефметического");
                foreach (double elem in myAL)
                {
                    lbMain.Items.Add(elem);
                }
                for (int l = 0; l < itemCount; l++)
                {
                    double num = (double)myAL[l];
                    valueList1.Add(new KeyValuePair<string, double>("", num));
                }

            }
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                double count = 0;
                double count1 = 0;
                for (int i = 0; i < itemCount; i++)
                {
                    count += (int)myAL[i];
                }
                count /= itemCount;
                lbMain.Items.Add(String.Format("Среднее занчение элементов массива {0}", count));
                for (int k = 0; k < itemCount; k++)
                {
                    count1 += Math.Abs(count - (int)myAL[k]);
                }
                count1 /= itemCount;
                lbMain.Items.Add(String.Format("Среднее занчение всех отклонений от среднего арефметического {0}", count1));
                for (int k = 0; k < itemCount; k++)
                {
                    myAL[k] = Convert.ToDouble(myAL[k]);
                    if (Math.Abs(count - (double)myAL[k]) > count1 / 2)
                        myAL[k] = count;
                }
                foreach (double elem in myAL)
                {
                    lbMain.Items.Add(elem);
                }
                valueList1.Clear();
                foreach (double elem in myAL)
                {
                    valueList1.Add(new KeyValuePair<string, double>("", elem));
                }
            }
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                double count = 0;
                double count1 = 0;
                for (int i = 0; i < itemCount; i++)
                {
                    count += (int)myAL[i];
                }
                count /= itemCount;
                lbMain.Items.Add(String.Format("Среднее занчение элементов массива {0}", count));
                for (int k = 0; k < itemCount; k++)
                {
                    count1 += Math.Abs(count - (int)myAL[k]);
                }
                count1 /= itemCount;
                lbMain.Items.Add(String.Format("Среднее занчение всех отклонений от среднего арефметического {0}", count1));
                Window1 l = new Window1();
                l.Label1.Content = "Введите %";
                l.ShowDialog();
                for (int k = 0; k < itemCount; k++)
                {
                    myAL[k] = Convert.ToDouble(myAL[k]);
                    if (Math.Abs(count - (double)myAL[k]) > count1 * l.k / 100)
                        myAL[k] = count;
                }
                foreach (double elem in myAL)
                {
                    lbMain.Items.Add(elem);
                }
                valueList1.Clear();
                foreach (double elem in myAL)
                {
                    valueList1.Add(new KeyValuePair<string, double>("", elem));
                }
            }

        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            myAL = Gen(myAL);
            if ((tbN.Text != "") && (tbN.Text != "0"))
            {
                int itemCount = Convert.ToInt32(tbN.Text);
                double count = 0;
                double count1 = 0;
                for (int i = 0; i < itemCount; i++)
                {
                    count += (int)myAL[i];
                }
                count /= itemCount;
                lbMain.Items.Add(String.Format("Среднее занчение элементов массива {0}", count));
                for (int k = 0; k < itemCount; k++)
                {
                    count1 += Math.Abs(count - (int)myAL[k]);
                }
                count1 /= itemCount;
                lbMain.Items.Add(String.Format("Среднее занчение всех отклонений от среднего арефметического {0}", count1));
                Window1 l = new Window1();
                l.Label1.Content = "Введите %";
                l.ShowDialog();
                Window1 j = new Window1();
                j.Label1.Content = "Введите коэфициент";
                j.ShowDialog();
                for (int k = 0; k < itemCount; k++)
                {
                    myAL[k] = Convert.ToDouble(myAL[k]);
                    if (Math.Abs(count - (double)myAL[k]) > count1 * l.k / 100)
                        myAL[k] = (double)myAL[k] * j.k;
                }
                foreach (double elem in myAL)
                {
                    lbMain.Items.Add(elem);
                }
                valueList1.Clear();
                foreach (double elem in myAL)
                {
                    valueList1.Add(new KeyValuePair<string, double>("", elem));
                }
            }
            }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            {
                ArrayList myAL = new ArrayList();
                valueList.Clear();
                valueList1.Clear();
                myAL = Gen(myAL);
                Window1 g = new Window1();
                g.Label1.Content = "Введите количество итераций";
                g.ShowDialog();
                Window1 l = new Window1();
                l.Label1.Content = "Введите %";
                l.ShowDialog();
                Window1 j = new Window1();
                j.Label1.Content = "Введите коэфициент";//k
                j.ShowDialog();
                for (int h = 0; h < g.k; h++)
                {
                    if ((tbN.Text != "") && (tbN.Text != "0"))
                    {
                        int itemCount = Convert.ToInt32(tbN.Text);
                        double count = 0;
                        double count1 = 0;
                        for (int i = 0; i < itemCount; i++)
                        {
                            count += Convert.ToDouble(myAL[i]);
                        }
                        count /= itemCount;
                        lbMain.Items.Add(String.Format("Среднее занчение элементов массива {0}", count));
                        for (int k = 0; k < itemCount; k++)
                        {
                            count1 += Math.Abs(count - Convert.ToDouble(myAL[k]));
                        }
                        count1 /= itemCount;
                        lbMain.Items.Add(String.Format("Среднее занчение всех отклонений от среднего арефметического {0}", count1));
                        for (int k = 0; k < itemCount; k++)
                        {
                            myAL[k] = Convert.ToDouble(myAL[k]);
                            if (Math.Abs(count - (double)myAL[k]) > count1 * l.k / 100)
                                myAL[k] = (double)myAL[k] * j.k;
                        }
                        foreach (double elem in myAL)
                        {
                            lbMain.Items.Add(elem);
                        }

                    }
                }
                valueList1.Clear();
                foreach (double elem in myAL)
                {
                    valueList1.Add(new KeyValuePair<string, double>("", elem));
                }
            }
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
         //Казурова Анна 3В
            int Vibor, index;
            int itemCount = Convert.ToInt32(tbN.Text);
            
            List<int> myAL = new List<int>();
            List<int> myAL1 = new List<int>();

            abs.Gen_int(myAL, itemCount);

            Window1 z = new Window1();
            Window1 q = new Window1();
            z.Label1.Content = "Введите номер задания (7-9)";


            z.ShowDialog();

            do
            {
                if ((Convert.ToInt32(z.num.Text) < 7) || (Convert.ToInt32(z.num.Text) > 9))
                {
                    MessageBox.Show("Выберете задание 7, 8, 9!");
                    q.Label1.Content = "Введите номер задания (7-9)";
                    q.ShowDialog();
                                      
                }
            } while ((Convert.ToInt32(z.num.Text) < 7) || (Convert.ToInt32(z.num.Text) > 9));

            Vibor = Convert.ToInt32(z.num.Text);

            if (Vibor == 7)
            {
                lbMain.Items.Clear();
                lbMain.Items.Add("Исходный массив:");
                for (index = 0; index < itemCount; index++)
                {

                    lbMain.Items.Add(myAL[index]);
                }

                valueList.Clear();
                for (int i = 0; i < itemCount; i++)
                {
                    valueList.Add(new KeyValuePair<string, int>("", myAL[i]));
                }

                abs.But_7(myAL, myAL1, itemCount);


                lbMain.Items.Add("Новый массив: ");

                for (int i = 0; i < itemCount; i++)
                {
                    lbMain.Items.Add(myAL[i]);
                }

                valueList1.Clear();
                for (int i = 0; i < itemCount; i++)
                {
                    valueList1.Add(new KeyValuePair<string, double>("", (double)myAL[i]));
                }

                lbMain.Items.Add("Дан массив из K чисел. \nНайдите среднее значение элементов \nмассива. Замените все элементы массива, \nотклонение от среднего значения которых \nбольше половины среднего отклонения \nвсех элементов, на среднее значение.");
            }

            abs.Gen_int(myAL, itemCount);

            if (Vibor == 8)
            {
                                
                lbMain.Items.Clear();
                lbMain.Items.Add("Исходный массив:");
                for (index = 0; index < itemCount; index++)
                {
                    lbMain.Items.Add(myAL[index]);
                }

                valueList.Clear();
                for (int i = 0; i < itemCount; i++)
                {
                    valueList.Add(new KeyValuePair<string, int>("", myAL[i]));
                }


                Window1 zz = new Window1();
                Window1 qq = new Window1();
                zz.Label1.Content = "Введите количество процентов L";


                zz.ShowDialog();

                do
                {
                    if ((Convert.ToInt32(zz.num.Text) < 0) || (Convert.ToInt32(zz.num.Text) > 100))
                    {
                        MessageBox.Show("Выберете процент от 1 до 100");
                        qq.Label1.Content = "Введите количество процентов L";
                        qq.ShowDialog();
                    }
                } while ((Convert.ToInt32(zz.num.Text) < 0) || (Convert.ToInt32(zz.num.Text) > 100));


                abs.But_8(myAL, myAL1, itemCount, Convert.ToInt32(zz.num.Text));


                lbMain.Items.Add("Новый массив: ");

                for (int i = 0; i < itemCount; i++)
                {
                    lbMain.Items.Add(myAL[i]);
                }

                valueList1.Clear();
                for (int i = 0; i < itemCount; i++)
                {
                    valueList1.Add(new KeyValuePair<string, double>("", (double)myAL[i]));
                }

                lbMain.Items.Add("Дан массив из K чисел. \nНайдите среднее значение элементов массива. \nЗамените все элементы массива, \nотклонение от среднего значения которых \nбольше L процентов от среднего отклонения \nвсех элементов, на среднее значение.");
            }

            abs.Gen_int(myAL, itemCount);

            if (Vibor == 9)
            {
                lbMain.Items.Clear();
                lbMain.Items.Add("Исходный массив:");
                for (index = 0; index < itemCount; index++)
                {
                    lbMain.Items.Add(myAL[index]);
                }

                valueList.Clear();
                for (int i = 0; i < itemCount; i++)
                {
                    valueList.Add(new KeyValuePair<string, int>("", myAL[i]));
                }


                Window1 zzz = new Window1();
                Window1 qqq = new Window1();
                zzz.Label1.Content = "Введите количество процентов L";


                zzz.ShowDialog();

                do
                {
                    if ((Convert.ToInt32(zzz.num.Text) < 0) || (Convert.ToInt32(zzz.num.Text) > 100))
                    {
                        MessageBox.Show("Выберете процент от 1 до 100");
                        qqq.Label1.Content = "Введите количество процентов L";
                        qqq.ShowDialog();
                    }
                } while ((Convert.ToInt32(zzz.num.Text) < 0) || (Convert.ToInt32(zzz.num.Text) > 100));

                Window2 zzzz = new Window2();
                zzzz.Label2.Content = "Введите";
                zzzz.Label3.Content = "коэффициент Z";
                zzzz.ShowDialog();

                abs.But_9(myAL, myAL1, itemCount, Convert.ToInt32(zzz.num.Text), Convert.ToInt32(zzzz.number.Text));


                lbMain.Items.Add("Новый массив: ");

                for (int i = 0; i < itemCount; i++)
                {
                    lbMain.Items.Add(myAL[i]);
                }

                valueList1.Clear();
                for (int i = 0; i < itemCount; i++)
                {
                    valueList1.Add(new KeyValuePair<string, double>("", (double)myAL[i]));
                }

                lbMain.Items.Add("Дан массив из K чисел. \nНайдите среднее значение элементов \nмассива. Измените все элементы массива, \nотклонение от среднего значения которых \nбольше L процентов от среднего отклонения \nвсех элементов, на коэфициент Z.");

            }



        }
        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            //Казурова Анна 3В
            int itemCount = Convert.ToInt32(tbN.Text);
            int index;

            List<int> myAL = new List<int>();
            List<int> myAL1 = new List<int>();

            abs.Gen_int(myAL, itemCount);

            Window1 z = new Window1();
            Window1 q = new Window1();
            z.Label1.Content = "Введите количество элементов на отрезке массива";

            z.ShowDialog();

            do
            {
                if ((Convert.ToInt32(z.num.Text) < 1) || (Convert.ToInt32(z.num.Text) > itemCount))
                {
                    MessageBox.Show("Выберете задание 7, 8, 9!");
                    q.Label1.Content = "Введите номер задания (7-9)";
                    q.ShowDialog();

                }
            } while ((Convert.ToInt32(z.num.Text) < 1) || (Convert.ToInt32(z.num.Text) > itemCount));

            Window1 zzz = new Window1();
            Window1 qqq = new Window1();
            zzz.Label1.Content = "Введите количество процентов L";


            zzz.ShowDialog();

            do
            {
                if ((Convert.ToInt32(zzz.num.Text) < 0) || (Convert.ToInt32(zzz.num.Text) > 100))
                {
                    MessageBox.Show("Выберете процент от 1 до 100");
                    qqq.Label1.Content = "Введите количество процентов L";
                    qqq.ShowDialog();
                }
            } while ((Convert.ToInt32(zzz.num.Text) < 0) || (Convert.ToInt32(zzz.num.Text) > 100));

            Window2 zzzz = new Window2();
            zzzz.Label2.Content = "Введите";
            zzzz.Label3.Content = "коэффициент Z";
            zzzz.ShowDialog();


            abs.But_norm(myAL, myAL1, itemCount, Convert.ToInt32(z.num.Text), Convert.ToInt32(zzz.num.Text), Convert.ToInt32(zzzz.number.Text));

            lbMain.Items.Clear();
            lbMain.Items.Add("Исходный массив:");
            for (index = 0; index < itemCount; index++)
            {
                lbMain.Items.Add(myAL[index]);
            }

            valueList.Clear();
            for (int i = 0; i < itemCount; i++)
            {
                valueList.Add(new KeyValuePair<string, int>("", myAL[i]));
            }

           
            lbMain.Items.Add("Новый массив:");
            for (index = 0; index < itemCount; index++)
            {
                lbMain.Items.Add(myAL1[index]);
            }

            valueList1.Clear();
            for (int i = 0; i < itemCount; i++)
            {
                valueList1.Add(new KeyValuePair<string, double>("", (double)myAL1[i]));
            }

        }


    }
}

