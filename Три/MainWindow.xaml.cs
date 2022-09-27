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
using Microsoft.Win32;
using LibMas;
using Lib_14;
using Пример_таблицы_WPF;

namespace Два
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[,] matr;
        private void btn_Создать_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int colsNumber = Convert.ToInt32(cols.Text);
                int rowsNumber = Convert.ToInt32(rows.Text);
                matr = new int[rowsNumber, colsNumber];
                Class2.ClearArr(ref matr);

                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                btn_Count.IsEnabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Заполнить_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int min = Convert.ToInt32(minzn.Text);
                int max = Convert.ToInt32(maxzn.Text);

                Class2.FillArr(ref matr, min, max);
                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] result = Class1.MatrixColSum(matr);
                dataGrid2.ItemsSource = VisualArray.ToDataTable(result).DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дунаева М.И.\n\nПрактическая работа №3\n\n" +
                "Дана матрица размера M × N. В каждом ее столбце найти количество элементов, больших среднего арифметического всех элементов этого столбца.");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class2.SaveArr(matr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class2.OpenArr(ref matr);
                dataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                btn_Count.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int indexColumn = e.Column.DisplayIndex;
                int indexRow = e.Row.GetIndex();
                matr[indexRow, indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
