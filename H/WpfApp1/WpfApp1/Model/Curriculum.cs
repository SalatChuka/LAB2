    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Curriculum
    {
        public int Id { get; set; }
        public int AcademicYear { get; set; }
        public string NameCurriculum { get; set; }
        public string Qualification { get; set; }
        public string FormEducation { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }
        public Curriculum() { }
        public Curriculum(int id, int AcademicYear, string NameCurriculum, string Qualification, string FormEducation, string Speciality, int Course )
        {
            this.Id = id;
            this.AcademicYear = AcademicYear;
            this.NameCurriculum = NameCurriculum;
            this.Qualification = Qualification;
            this.FormEducation = FormEducation;
            this.Speciality = Speciality;
            this.Course = Course;
        }
        public Curriculum ShallowCopy()
        {
            return (Curriculum)this.MemberwiseClone();
        }

    }
}
