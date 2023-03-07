using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace e_Hospital.Application.Services
{
    public class DeleteExpiredMedicinesBackGroundService : BackgroundService
    {
        private readonly IServiceProvider _provider;

        public DeleteExpiredMedicinesBackGroundService(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var period = new PeriodicTimer(TimeSpan.FromDays(1));

            using var scope = _provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IWithdrawService>();

            while(await period.WaitForNextTickAsync(stoppingToken))
            {
                await service.WithdrawExpired(new Medicine());
            }

        }
    }
}
