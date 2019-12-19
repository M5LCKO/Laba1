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
                    valueList.Clear();
                    valueList1.Clear();
                    for (index = 0; index < itemCount; index++)
                    {
                        int num = (int)myAL[index];
                        valueList.Add(new KeyValuePair<string, int>("", num));
                    }
                }
                else { MessageBox.Show("Вы забыли указать число или вы указали 0, либо число меньше нуля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch (FormatException) { MessageBox.Show("Вы забыли указать число или вы указали 0, либо число меньше нуля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); tbN.Text = ""; }
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
            Gen(myAL);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
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
                    valueList1.Add(new KeyValuePair<string, double>("", num));
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
            valueList.Clear();
            valueList1.Clear();
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
            valueList.Clear();
            valueList1.Clear();
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
            valueList.Clear();
            valueList1.Clear();
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
                if (buf == 0)
                { lbMain.Items.Add(String.Format("Чисел больше {0} нет", k.k)); }
            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {//Стулов Денис 3В 120871
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            Gen(myAL);
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
            Gen(myAL);
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
            Gen(myAL);
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
            Gen(myAL);
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
            Gen(myAL);
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
            Gen(myAL);
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
            Gen(myAL);
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

        private void Button_Click_14(object sender, RoutedEventArgs e)

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            Gen(myAL);
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
                l.ShowDialog();
                Window1 j = new Window1();
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
        }

        //метод для слияния массивов
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }


        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            valueList.Clear();
            valueList1.Clear();
            Gen(myAL);
            Window1 g = new Window1();
            g.ShowDialog();
            Window1 l = new Window1();
            l.ShowDialog();
            Window1 j = new Window1();
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
}
