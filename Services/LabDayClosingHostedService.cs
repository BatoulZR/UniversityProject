using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NCrontab;
using SeniorProject.Data;
using SeniorProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeniorProject.Services
{
    public class LabDayClosingHostedService : BackgroundService
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        private readonly IServiceProvider _serviceProvider;

        //private string Schedule => "*/20 * * * * *"; //Runs every 10 seconds
        private string Schedule => "* * */23 * * *";// Runs every day at 23:00

        public LabDayClosingHostedService(IServiceProvider serviceProvider)
        {
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                var nextrun = _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private void Process()
        {
            Console.WriteLine("hello world" + DateTime.Now.ToString("F"));

            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                var today = DateTime.Now.Date;

                var lab = _context.LabDay.FirstOrDefault(l => l.date.Date.Equals(today));

                if (lab != null)
                {
                    var closingTime = _context.Attendance
                        .Include(a => a.LabDay)
                        .Where(a => a.LabDayId == lab.ID)
                        .Max(a => a.LeavingTime);

                    if (closingTime != null)
                    {
                        lab.closingTime = closingTime;
                        _context.Entry(lab).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }

            }
        }

    }
}
