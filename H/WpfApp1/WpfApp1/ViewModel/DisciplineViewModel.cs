using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class DisciplineViewModel
    {
        public ObservableCollection<Discipline> ListDiscipline { get; set; } = new ObservableCollection<Discipline>();
        public DisciplineViewModel()
        {
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var a in this.ListDiscipline)
            {
                if (max < a.Id)
                {
                    max = a.Id;
                };
            }
            return max;
        }
    }
}