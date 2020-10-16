using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NCrontab;
using SeniorProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeniorProject.Services
{
    public class EquipmentHostedService : BackgroundService
    {

        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        private readonly IServiceProvider _serviceProvider;

       // private string Schedule => "*/20 * * * * *"; //Runs every 10 seconds
        private string Schedule => "* * */3 * * *";// Runs every day at 3:00

        public EquipmentHostedService(IServiceProvider serviceProvider)
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
                    ProcessExpiryDate();
                    ProcessQuantity();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private void ProcessExpiryDate()
        {
            Console.WriteLine("hello world" + DateTime.Now.ToString("F"));

            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                var today = DateTime.Now.Date;

                //list of expired equipments
                var equipments = _context.Equipment
                    .Where(a => DateTime.Compare((DateTime)a.expiryDate, today.AddMonths(1)) <= 0)
                    .ToList();

                foreach (var item in equipments)
                {
                    item.expired = true;
                    _context.Entry(item).State = EntityState.Modified;

                }
                _context.SaveChanges();


            }
        }

            private void ProcessQuantity()
            {
                Console.WriteLine("hello world" + DateTime.Now.ToString("F"));

                using (var scope = _serviceProvider.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                    var today = DateTime.Now.Date;

                //list of expired equipments
                var equipments = _context.Equipment
                    .Where(a => a.quantity <= a.quantity * 0.2)
                        .ToList();

                    foreach (var item in equipments)
                    {
                        item.remainingQuantity = true;
                        _context.Entry(item).State = EntityState.Modified;

                    }
                    _context.SaveChanges();


                }

            }

        }
        }

    

