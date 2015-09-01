using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Globalization.DateTimeFormatting;
using Exi.Model.Core;
using Exi.Model.Planning;
using NUnit.Framework;

namespace Exi.Model.Tests
{
    [TestFixture]
    public class ScheduleCreatorTest
    {
        private ScheduleCreator creator;

        [Test]
        public void CreateDefaultScheduleListTest()
        {
            this.creator = new ScheduleCreator();

            List<DayOfWeek> freedays = new List<DayOfWeek>();
            freedays.Add(DayOfWeek.Thursday);
            freedays.Add(DayOfWeek.Sunday);

            List<IDivisible> tests = new List<IDivisible>();

            int Chapter1Amount = 70;
            int Chapter2Amount = 90;
            int Chapter3Amount = 140;

            tests.Add(new Chapter("Kapitel 1", Chapter1Amount));
            tests.Add(new Chapter("Kapitel 2", Chapter2Amount));

            // Create list with 2 chapters.
            List<ScheduleDay> schedule = this.creator.CreateDefaultScheduleList(DateTime.Today, DateTime.Now.AddDays(12.0), freedays, tests);

            Assert.AreEqual(13, schedule.Count);
            Assert.AreEqual(DateTime.Today.AddDays(12.0), schedule[12].Date);
            Assert.AreEqual(Chapter1Amount,
                schedule.Sum(x => x.Pensum.Where(y => y.SubjectName.Equals("Kapitel 1")).Sum(z => z.Amount)));
            Assert.AreEqual(Chapter2Amount,
                schedule.Sum(x => x.Pensum.Where(y => y.SubjectName.Equals("Kapitel 2")).Sum(z => z.Amount)));
            
            tests.Add(new Chapter("Kapitel 3", Chapter3Amount));
            // Create list with 3 chapters.
            schedule = this.creator.CreateDefaultScheduleList(DateTime.Today, DateTime.Now.AddDays(12.0), freedays, tests);

            Assert.AreEqual(13, schedule.Count);
            Assert.AreEqual(DateTime.Today.AddDays(12.0), schedule[12].Date);
            Assert.AreEqual(Chapter1Amount,
                schedule.Sum(x => x.Pensum.Where(y => y.SubjectName.Equals("Kapitel 1")).Sum(z => z.Amount)));
            Assert.AreEqual(Chapter2Amount,
                schedule.Sum(x => x.Pensum.Where(y => y.SubjectName.Equals("Kapitel 2")).Sum(z => z.Amount)));
            Assert.AreEqual(Chapter3Amount,
                schedule.Sum(x => x.Pensum.Where(y => y.SubjectName.Equals("Kapitel 3")).Sum(z => z.Amount)));
        }
    }
}
