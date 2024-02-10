using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Discipline
    {
        public int Id { get; set; }
        public int IdChair { get; set; }
        public int IdCurriculum { get; set; }
        public string NameDiscipline { get; set; }
        public int Course { get; set; }
        public int Semester { get; set; }
        public int Lecture { get; set; }
        public int Laboratory { get; set; }
        public int Practical { get; set; }
        public bool Examen { get; set; }
        public bool SetOff { get; set; }


        public Discipline() { }
        public Discipline(int id, int idChair, int IdCurriculum, string NameDiscipline, int Course, int Semester, int Lecture, int Laboratory, int Practical, bool Examen, bool SetOff)
        {
            this.Id = id;
            this.IdChair = idChair;
            this.IdCurriculum = IdCurriculum;
            this.NameDiscipline = NameDiscipline;
            this.Course = Course;
            this.Semester = Semester;   
            this.Lecture = Lecture;
            this.Laboratory = Laboratory;
            this.Practical = Practical;
            this.Examen = Examen;
            this.SetOff = SetOff;
        }
        public Discipline ShallowCopy()
        {
            return (Discipline)this.MemberwiseClone();
        }
        public Discipline CopyFromDisciplineDPO(DisciplineDPO a)
        {
            CurriculumViewModel vmCurriculum = new CurriculumViewModel();
            int curriculumId = 0;
            foreach (var b in vmCurriculum.ListCurriculum)
            {
                if (b.NameCurriculum == a.Curriculum)
                {
                    curriculumId = b.Id;
                    break;
                }
            }

            ChairViewModel vmChair = new ChairViewModel();
            int chairId = 0;
            foreach (var agr in vmChair.ListChair)
            {
                if (agr.ShortNameChair == a.Chair)
                {
                    chairId = agr.Id;
                    break;

                }
            }
            if (curriculumId != 0 & chairId != 0)
            {
                this.Id = a.Id;
                this.IdChair = curriculumId;
                this.IdCurriculum = chairId;
                this.NameDiscipline = a.NameDiscipline;
                this.Course = a.Course;
                this.Lecture = a.Lecture;
                this.Laboratory = a.Laboratory;
                this.Practical = a.Practical;
                this.Semester = a.Semester;
                this.SetOff = a.SetOff;
                this.Examen = a.Examen;
                }
                return this;
            }

        }

    }