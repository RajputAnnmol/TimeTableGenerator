﻿namespace TimeTableGenerator.Models
{
    public class TimeTable
    {
        public int WorkingDays { get; set; }
        public int SubjectsPerDay { get; set; }
        public List<Subject> Subjects { get; set; }
    }

}
