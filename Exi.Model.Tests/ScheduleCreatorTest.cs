using System;
using System.Collections.Generic;
using Exi.Model.Core;
using Exi.Model.Planning;
using NUnit.Framework;

namespace Exi.Model.Tests
{
    [TestFixture]
    public class ScheduleCreatorTest
    {
        private ScheduleCreator _creator;

        [Test]
        public void CreateBruteForceTest()
        {
            this._creator = new ScheduleCreator();

            List<DayOfWeek> freedays = new List<DayOfWeek>();
            freedays.Add(DayOfWeek.Thursday);
            freedays.Add(DayOfWeek.Sunday);

            List<IDivisible> tests = new List<IDivisible>();
            tests.Add(new Chapter("Kapitel 1", 7));
            tests.Add(new Chapter("Kapitel 2", 7));
            
            List<WeekSchedule> schedule = this._creator.CreateScheduleList(DateTime.Today, DateTime.Now.AddDays(12.0), freedays, tests);

            tests.Add(new Chapter("Kapitel 3", 12));
            schedule = this._creator.CreateScheduleList(DateTime.Today, DateTime.Now.AddDays(12.0), freedays, tests);
        }
    }
}
