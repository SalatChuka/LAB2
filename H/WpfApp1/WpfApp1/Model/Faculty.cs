using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Faculty
    {
        public int Id { get; set; }
        public string NameFaculty { get; set; }
        public string ShortNameFaculty { get; set; }
        public Faculty() { }
        public Faculty(int id, string NameFaculty, string shortNameFaculty)
        {
            this.Id = id;
            this.NameFaculty = NameFaculty;
            ShortNameFaculty = shortNameFaculty;
        }
        public Faculty ShallowCopy()
        {
            return (Faculty)this.MemberwiseClone();
        }
    }
}
