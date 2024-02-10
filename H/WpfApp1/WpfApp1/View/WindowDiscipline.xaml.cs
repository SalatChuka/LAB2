using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using WpfApp1.Helper;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAccount.xaml
    /// </summary>
    public partial class WindowDiscipline : Window
    {
        private DisciplineViewModel vmDiscipline = MainWindow.vmAccount;
        private CurriculumViewModel vmCirillicum;
        private ChairViewModel vmChair;
        private ObservableCollection<DisciplineDPO> disciplinesDPO;
        private List<Curriculum> curriculums;
        private List<Chair> chairs;
        public WindowDiscipline()
        {
            InitializeComponent();
            vmDiscipline = new DisciplineViewModel();
            vmCirillicum = new CurriculumViewModel();
            vmChair = new ChairViewModel();
            curriculums = vmCirillicum.ListCurriculum.ToList();
            chairs = vmChair.ListChair.ToList();
                
            disciplinesDPO = new ObservableCollection<DisciplineDPO>();
            foreach (var discipline in vmDiscipline.ListDiscipline)
            {
                DisciplineDPO d = new DisciplineDPO();
                d = d.CopyFromDiscipline(discipline);
                disciplinesDPO.Add(d);
            }
            lvDiscipline.ItemsSource = disciplinesDPO;
        }


        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

            private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewDiscipline wnAccount = new WindowNewDiscipline
            {
                Title = "Редактирование данных о дисциплинах",
                Owner = this
            };

            DisciplineDPO disDPO = (DisciplineDPO)lvDiscipline.SelectedValue;
            DisciplineDPO tempDisDPO;
            if (disDPO != null)
            {
                tempDisDPO = disDPO.ShallowCopy();
                wnAccount.DataContext = tempDisDPO;
                wnAccount.CbChair.ItemsSource = chairs;
                wnAccount.CbChair.Text = tempDisDPO.Chair;
                wnAccount.CbCurriculum.ItemsSource = curriculums;
                wnAccount.CbCurriculum.Text = tempDisDPO.Curriculum;
                if (wnAccount.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных 
                    Curriculum b = (Curriculum)wnAccount.CbCurriculum.SelectedValue;
                    Chair agr = (Chair)wnAccount.CbChair.SelectedValue;
                    disDPO.Curriculum = b.NameCurriculum;
                    disDPO.Chair = agr.ShortNameChair;
                    disDPO.NameDiscipline = tempDisDPO.NameDiscipline;
                    disDPO.Course = tempDisDPO.Course;
                    disDPO.Lecture = tempDisDPO.Lecture;
                    disDPO.Laboratory = tempDisDPO.Laboratory;
                    disDPO.Practical = tempDisDPO.Practical;
                    disDPO.Semester = tempDisDPO.Semester;
                    disDPO.Examen = tempDisDPO.Examen;
                    disDPO.SetOff = tempDisDPO.SetOff;


                    lvDiscipline.ItemsSource = null;
                    lvDiscipline.ItemsSource = disciplinesDPO;

                    // перенос данных из класса отображения данных в класс Person
                    FindDiscipline finder = new FindDiscipline(disDPO.Id);
                    List<Discipline> listDiscipline = vmDiscipline.ListDiscipline.ToList();
                    Discipline a = listDiscipline.Find(new Predicate<Discipline>(finder.DisciplinePredicate));
                    a = a.CopyFromDisciplineDPO(disDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать дисциплину для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
            private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewDiscipline wnAccount = new WindowNewDiscipline
            {
                Title = "Новая дисциплина",
                Owner = this
            };
            // формирование кода нового счёта
            int maxIdDiscipline = vmDiscipline.MaxId() + 1;
            DisciplineDPO dis = new DisciplineDPO
            {
                Id = maxIdDiscipline,
            };
            wnAccount.DataContext = dis;
            wnAccount.CbCurriculum.ItemsSource = curriculums;
            wnAccount.CbChair.ItemsSource = chairs;

            if (wnAccount.ShowDialog() == true)
            {
                Curriculum b = (Curriculum)wnAccount.CbCurriculum.SelectedValue;
                Chair agr = (Chair)wnAccount.CbChair.SelectedValue;
                dis.Curriculum = b.NameCurriculum;
                dis.Chair = agr.ShortNameChair;
                disciplinesDPO.Add(dis);

                // добавление нового сотрудника в коллекцию ListPerson<Person> 
                Discipline a = new Discipline();
                a = a.CopyFromDisciplineDPO(dis);
                vmDiscipline.ListDiscipline.Add(a);
                lvDiscipline.ItemsSource = null;
                lvDiscipline.ItemsSource = disciplinesDPO;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DisciplineDPO disDPO = (DisciplineDPO)lvDiscipline.SelectedItem;
            DisciplineViewModel vmDiscipline = new DisciplineViewModel();
            Discipline discipline = new Discipline();
            discipline.CopyFromDisciplineDPO((DisciplineDPO)lvDiscipline.SelectedItem);
            if (discipline != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по дисциплине: " +
                discipline.NameDiscipline, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmDiscipline.ListDiscipline.Remove(discipline);
                    disciplinesDPO.Remove(disDPO);
                    lvDiscipline.ItemsSource = null;
                    lvDiscipline.ItemsSource = disciplinesDPO;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать счёт для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
