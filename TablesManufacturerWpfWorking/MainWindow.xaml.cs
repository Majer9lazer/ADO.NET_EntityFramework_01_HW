using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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
using TablesManufacturerWpfWorking.Model;

namespace TablesManufacturerWpfWorking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MCS db = new MCS();
        public MainWindow()
        {
            InitializeComponent();
            GetDataToDEleteList();
            ManufacturesToaddList.ItemsSource = db.TablesManufacturers.ToList();
            ManufacturesToChangeList.ItemsSource = db.TablesManufacturers.ToList();
        }

        private void GetDataToDEleteList()
        {

            if (ManufacturesToDeleteList.ItemsSource==null)
            {
                ManufacturesToDeleteList.ItemsSource = db.TablesManufacturers.ToList();

            }
            else
            {
                ManufacturesToDeleteList.ItemsSource = null;
                ManufacturesToDeleteList.ItemsSource = db.TablesManufacturers.ToList();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            ErrorOrSuccesTextBlockDelete.Text = null;
            var a = (TablesManufacturer)ManufacturesToDeleteList.SelectedItem;
            db.TablesManufacturers.Remove(a);
            try
            {
                db.SaveChanges();
                MessageBox.Show("Елемент под названием - " + a.strName + " был удален успешно!");
            }
            catch (Exception ex)
            {

                if (ex.InnerException?.InnerException != null)
                {
                    ErrorOrSuccesTextBlockDelete.Text = ex.InnerException.InnerException.Message+"\n";
                    ErrorOrSuccesTextBlockDelete.Text +=
                        "Во первых если не удаляется , не пытайтесь , так как таблица параллельно с другой связана\n" +
                        "Во вторых чтобы проверить работоспособность просто создайте что нибудь другое и можете удалить то что создали!";
                }
            }
        
            GetDataToDEleteList();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            ErrorOrSuccesTextBlockAdd.Text = null;
         
            TablesManufacturer a = new TablesManufacturer()
            {
                strName = StrNameTextBox.Text,
                strManufacturerChecklistId = StrManufacturerChecklistIdTextBox.Text
            };
            try
            {
                db.TablesManufacturers.Add(a);
                db.SaveChanges();
                ErrorOrSuccesTextBlockAdd.Text = "Был добавлен елемент под именем - "+a.strName;
                ManufacturesToaddList.ItemsSource = null;
                ManufacturesToaddList.ItemsSource = db.TablesManufacturers.ToList();
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlockAdd.Text = ex.Message;
            }
        }

        private void AcceptChangesButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                TablesManufacturer a = (TablesManufacturer)ManufacturesToChangeList.SelectedItem;
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                ErrorOrSuccesTextBlockChange.Text = null;
                ErrorOrSuccesTextBlockChange.Text = "Запись была успешно изменена под именем : "+a.strName+"!";
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlockChange.Text = ex.Message;
            }
           
        }
    }
}
