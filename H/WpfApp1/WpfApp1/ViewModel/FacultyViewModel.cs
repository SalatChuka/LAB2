using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class FacultyViewModel
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var b in this.ListFaculty)
            {
                if (max < b.Id)
                {
                    max = b.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Faculty> ListFaculty { get; set; } = new ObservableCollection<Faculty>();
        public FacultyViewModel()
        {
          
         }
    }
}