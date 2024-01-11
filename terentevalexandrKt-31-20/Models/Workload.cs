namespace terentevalexandrKt_31_20.Models
{
    public class Workload
    {
        public int Id { get; set; }

        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public int EducationalSubjectId { get; set; }

        public EducationalSubject EducationalSubject { get; set; }

        public int NumberOfHours { get; set; }
    }
}
