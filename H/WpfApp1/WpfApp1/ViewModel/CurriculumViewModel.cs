using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class CurriculumViewModel
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var b in this.ListCurriculum)
            {
                if (max < b.Id)
                {
                    max = b.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Curriculum> ListCurriculum { get; set; } = new ObservableCollection<Curriculum>();
        public CurriculumViewModel()
        {
        }
    }
}