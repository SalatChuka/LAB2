using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp1.View;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowBank.xaml
    /// </summary>
    public partial class WindowCurriculum : Window
    {
        public WindowCurriculum()
        {
            InitializeComponent();
            CurriculumViewModel vmCurriculum = new CurriculumViewModel();
            lvCurriculum.ItemsSource = null;
            lvCurriculum.ItemsSource = vmCurriculum.ListCurriculum;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CurriculumViewModel vmCurriculum = new CurriculumViewModel();
            WindowNewCurriculum wnCurriculum = new WindowNewCurriculum
            {
                Title = "Данные о новом банке",
                Owner = this
            };
            // формирование кода нового банка
            int maxIdBank = vmCurriculum.MaxId() + 1;
            Curriculum curriculum = new Curriculum
            {
                Id = maxIdBank
            };
            wnCurriculum.DataContext = curriculum;
            if (wnCurriculum.ShowDialog() == true)
            {
                vmCurriculum.ListCurriculum.Add(curriculum);
                lvCurriculum.ItemsSource = null;
                lvCurriculum.ItemsSource = vmCurriculum.ListCurriculum;
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            CurriculumViewModel vmCurriculum = new CurriculumViewModel();
            WindowNewCurriculum wnCurriculum = new WindowNewCurriculum
            {
                Title = "Редактирование учебного плана",
                Owner = this
            };
            Curriculum curriculum = lvCurriculum.SelectedItem as Curriculum;
            if (curriculum != null)
            {
                Curriculum tempCurriculum = curriculum.ShallowCopy();
                wnCurriculum.DataContext = tempCurriculum;
            if (wnCurriculum.ShowDialog() == true)
                {
                    // сохранение данных
                    curriculum.AcademicYear = tempCurriculum.AcademicYear;
                    curriculum.NameCurriculum = tempCurriculum.NameCurriculum;
                    curriculum.FormEducation = tempCurriculum.FormEducation;
                    curriculum.Qualification = tempCurriculum.Qualification;
                    curriculum.Course = tempCurriculum.Course;
                    curriculum.Speciality = tempCurriculum.Speciality;
                    lvCurriculum.ItemsSource = null;
                    lvCurriculum.ItemsSource = vmCurriculum.ListCurriculum;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать учебный план для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CurriculumViewModel vmCurriculum = new CurriculumViewModel();
            Curriculum curriculum = (Curriculum)lvCurriculum.SelectedItem;
            if (curriculum != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по учебному плану: " +
                curriculum.NameCurriculum, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmCurriculum.ListCurriculum.Remove(curriculum);
                    lvCurriculum.ItemsSource = null;
                    lvCurriculum.ItemsSource = vmCurriculum.ListCurriculum;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать банк для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
