using Microsoft.AspNetCore.Mvc;
using TimeTableGenerator.Models;

namespace TimeTableGenerator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var timeTable = new TimeTable();
            return View(timeTable);
        }

        [HttpPost]
        public IActionResult Generate(int workingDays, int subjectsPerDay, int totalSubjects)
        {
            var timeTable = new TimeTable
            {
                WorkingDays = workingDays,
                SubjectsPerDay = subjectsPerDay,
                Subjects = new List<Subject>()
            };
            var hours = Convert.ToDecimal(totalSubjects);
            var hours1 = Convert.ToDecimal(subjectsPerDay);
            var subjectHours = Convert.ToInt32(Convert.ToDecimal(subjectsPerDay) / Convert.ToDecimal(totalSubjects) * workingDays);
            decimal hoursPerWeek = workingDays * subjectsPerDay;
            int hoursPerSubject = 0;
            if (subjectsPerDay % totalSubjects == 0)
                hoursPerSubject = (subjectsPerDay / totalSubjects) * workingDays;
            else
                hoursPerSubject = subjectHours;

            var additionalHours = 0;
            if (hoursPerSubject * totalSubjects < hoursPerWeek || hoursPerSubject * totalSubjects > hoursPerWeek)
                additionalHours = Convert.ToInt32(hoursPerWeek - hoursPerSubject * totalSubjects);

            for (int i = 0; i < totalSubjects; i++)
            {
                if (additionalHours > 0)
                {
                    timeTable.Subjects.Add(new Subject { SubjectName = $"Subject {i + 1}", Hours = hoursPerSubject + 1 });
                    additionalHours -= 1;
                }
                else if (additionalHours < 0)
                {
                    timeTable.Subjects.Add(new Subject { SubjectName = $"Subject {i + 1}", Hours = hoursPerSubject - 1 });
                    additionalHours += 1;
                }
                else
                    timeTable.Subjects.Add(new Subject { SubjectName = $"Subject {i + 1}", Hours = hoursPerSubject });
            }

            return View("Generate", timeTable);
        }
    }
}