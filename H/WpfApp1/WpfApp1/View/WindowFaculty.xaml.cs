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
using System.Windows.Shapes;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowTypeAccount.xaml
    /// </summary>
    public partial class WindowFaculty : Window
    {
        FacultyViewModel vmFaculty = new FacultyViewModel();
        public WindowFaculty()
        {
            InitializeComponent();
            vmFaculty = new FacultyViewModel();
            lvFaculty.ItemsSource = vmFaculty.ListFaculty;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewFaculty wnFaculty = new WindowNewFaculty
            {
                Title = "Редактирование данных о факультете",
                Owner = this
            };
            Faculty faculty = lvFaculty.SelectedItem as Faculty;
            if (faculty != null)
            {
                Faculty tempFaculty = faculty.ShallowCopy();
                wnFaculty.DataContext = tempFaculty;
                if (wnFaculty.ShowDialog() == true)
                {
                    // сохранение данных
                    faculty.NameFaculty = tempFaculty.NameFaculty;
                    faculty.ShortNameFaculty = tempFaculty.ShortNameFaculty;
                    lvFaculty.ItemsSource = null;
                    lvFaculty.ItemsSource = vmFaculty.ListFaculty;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать факультет для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            FacultyViewModel vmFaculty = new FacultyViewModel();
            Faculty falulty = (Faculty)lvFaculty.SelectedItem;
            if (falulty != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить факультет: " +
                falulty.ShortNameFaculty, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmFaculty.ListFaculty.Remove(falulty);
                    lvFaculty.ItemsSource = null;
                    lvFaculty.ItemsSource = vmFaculty.ListFaculty;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать факультет для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewFaculty wnFaculty = new WindowNewFaculty
            {
                Title = "Новый факультет",
                Owner = this
            };
            // формирование кода новой должности
            int maxIdFaculty = vmFaculty.MaxId() + 1;
            Faculty faculty = new Faculty
            {
                Id = maxIdFaculty
            };
            wnFaculty.DataContext = faculty;
            if (wnFaculty.ShowDialog() == true)
            {
                vmFaculty.ListFaculty.Add(faculty);
                lvFaculty.ItemsSource = null;
                lvFaculty.ItemsSource = vmFaculty.ListFaculty;            }
        }
    }

}
