using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindFaculty
    {
        int id;
        public FindFaculty(int id)
        {
            this.id = id;
        }
        public bool FacultyPredicate(Faculty faculty)
        {
            return faculty.Id == id;
        }
    }
}
