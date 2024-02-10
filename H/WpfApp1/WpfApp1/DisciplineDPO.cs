using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    class DisciplineDPO
    {
        public int Id { get; set; }
        public string Curriculum { get; set; }
        public string Chair { get; set; }
        public string NameDiscipline {  get; set; }
        public int Course { get; set; }
        public int Semester { get; set; }
        public int Lecture { get; set; }
        public int Laboratory { get; set; }
        public int Practical { get; set; }
        public bool Examen { get; set; }
        public bool SetOff { get; set; }
        public DisciplineDPO() { }
        public DisciplineDPO(int id, string Chair, string Curriculum, string NameDiscipline, int Course, int Semester, int Lecture, int Laboratory, int Practical, bool Examen, bool SetOff)
        {
            this.Id = id;
            this.Chair = Chair;
            this.Curriculum = Curriculum;
            this.NameDiscipline = NameDiscipline;
            this.Course = Course;
            this.Semester = Semester;
            this.Lecture = Lecture;
            this.Laboratory = Laboratory;
            this.Practical = Practical;
            this.Examen = Examen;
            this.SetOff = SetOff;
        }
        public DisciplineDPO ShallowCopy()
        {
            return (DisciplineDPO)this.MemberwiseClone();
        }
        public DisciplineDPO CopyFromDiscipline(Discipline discipline)
        {
            DisciplineDPO disDPO = new DisciplineDPO();

            CurriculumViewModel vmCurriculum = new CurriculumViewModel();
            string curriculum = string.Empty;
            foreach (var b in vmCurriculum.ListCurriculum)
            {
                if (b.Id == discipline.IdChair)
                {
                    curriculum = b.NameCurriculum;
                    break;
                }
            }

            ChairViewModel vmChair = new ChairViewModel();
            string chair = string.Empty;
            foreach (var agr in vmChair.ListChair)
            {
                if (agr.Id == discipline.IdCurriculum)
                {
                    chair = agr.ShortNameChair;
                    break;
                }
            }

            if (curriculum != string.Empty & chair != string.Empty)
            {
                disDPO.Id = discipline.Id;
                disDPO.Curriculum = curriculum;
                disDPO.NameDiscipline = discipline.NameDiscipline;
                disDPO.Chair = chair;
                disDPO.Course = discipline.Course;
                disDPO.Semester = discipline.Semester;
                disDPO.Lecture = discipline.Lecture;
                disDPO.Laboratory = discipline.Laboratory;
                disDPO.Practical = discipline.Practical;
                discipline.Examen = discipline.Examen;
                discipline.SetOff = discipline.SetOff;
            }
            return disDPO;
        }

    }

}
