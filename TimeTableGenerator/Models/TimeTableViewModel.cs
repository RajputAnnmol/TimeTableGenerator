namespace TimeTableGenerator.Models
{
    public class TimeTableViewModel
    {
        public int WorkingDays { get; set; }
        public int SubjectsPerDay { get; set; }
        public int TotalSubjects { get; set; }
        public int TotalHours => WorkingDays * SubjectsPerDay;
        public List<Subject> Subjects { get; set; }
    }

}
