using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Principal;
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
    /// Логика взаимодействия для WindowAgreement.xaml
    /// </summary>
    public partial class WindowChair : Window
    {
        ChairViewModel vmChair = new ChairViewModel();
        FacultyViewModel vmFaculty = new FacultyViewModel();
        private ObservableCollection<ChairDPO> chairsDPO;
        private List<Faculty> faculties;
        public WindowChair()
        {
            InitializeComponent();
            vmChair = new ChairViewModel();
            vmFaculty = new FacultyViewModel();
            lvChair.ItemsSource = vmChair.ListChair;
            faculties = vmFaculty.ListFaculty.ToList();
            foreach (var chair in vmChair.ListChair)
            {
                ChairDPO d = new ChairDPO();
                d = d.CopyFromChair(chair);
                chairsDPO.Add(d);
            }
            lvChair.ItemsSource = chairsDPO;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ChairViewModel vmChair = new ChairViewModel();
            WindowNewChair wnChair = new WindowNewChair
            {
                Title = "Редактирование данных о кафедрах",
                Owner = this
            };
            ChairDPO chairDPO = (ChairDPO)lvChair.SelectedValue;
            ChairDPO tempchairDPO;
            if (chairDPO != null)
            {
                tempchairDPO = chairDPO.ShallowCopy();
                wnChair.DataContext = tempchairDPO;
                wnChair.CbFaculty.ItemsSource = faculties;
                wnChair.CbFaculty.Text = tempchairDPO.Faculty;
                if (wnChair.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных 
                    Faculty f = (Faculty)wnChair.CbFaculty.SelectedValue;
                    chairDPO.Faculty = f.ShortNameFaculty;
                    chairDPO.NameChair = tempchairDPO.NameChair;
                    chairDPO.ShortNameChair = tempchairDPO.ShortNameChair;

                    lvChair.ItemsSource = null;
                    lvChair.ItemsSource = chairsDPO;

                    // перенос данных из класса отображения данных в класс Person
                    FindChair finder = new FindChair(chairDPO.Id);
                    List<Chair> listDiscipline = vmChair.ListChair.ToList();
                    Chair a = listDiscipline.Find(new Predicate<Chair>(finder.ChairPredicate));
                    a = a.CopyFromChairDPO(chairDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать кафедру для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewChair wnAccount = new WindowNewChair
            {
                Title = "Новая кафедра",
                Owner = this
            };
            // формирование кода нового счёта
            int maxIdDChair = vmChair.MaxId() + 1;
            ChairDPO dis = new ChairDPO
            {
                Id = maxIdDChair,
            };
            wnAccount.DataContext = dis;
            wnAccount.CbFaculty.ItemsSource = faculties;
            if (wnAccount.ShowDialog() == true)
            {
                Faculty agr = (Faculty)wnAccount.CbFaculty.SelectedValue;
                dis.Faculty = agr.ShortNameFaculty;
                chairsDPO.Add(dis);

                // добавление нового сотрудника в коллекцию ListPerson<Person> 
                Chair a = new Chair();
                a = a.CopyFromChairDPO(dis);
                vmChair.ListChair.Add(a);
                lvChair.ItemsSource = null;
                lvChair.ItemsSource = chairsDPO;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ChairDPO chairDPO = (ChairDPO)lvChair.SelectedItem;
            ChairViewModel vmDiscipline = new ChairViewModel();
            Chair chair = new Chair();
            chair.CopyFromChairDPO((ChairDPO)lvChair.SelectedItem);
            if (chair != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по кафедре: " +
                chair.ShortNameChair, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmDiscipline.ListChair.Remove(chair);
                    chairsDPO.Remove(chairDPO);
                    lvChair.ItemsSource = null;
                    lvChair.ItemsSource = chairsDPO;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать кафедру для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}