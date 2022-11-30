using LFF.Core.Repositories;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFF.BackgroundServices.AutoSubmit
{
    public class AutoSubmitService : BackgroundService
    {
        private IStudentTestRepository studentTestRepository;

        public AutoSubmitService(IStudentTestRepository studentTestRepository)
        {
            this.studentTestRepository = studentTestRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int counter = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await studentTestRepository.AutoChangeStateSubmission();
                    Console.WriteLine("OK... {0}", ++counter);
                }
                catch (Exception)
                {

                }
                await Task.Delay(250);
            }
        }
    }
}
