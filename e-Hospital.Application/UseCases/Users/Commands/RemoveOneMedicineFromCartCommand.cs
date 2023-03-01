using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace e_Hospital.Application.UseCases.Users.Commands
{
    public class RemoveOneMedicineFromCartCommand : ICommand<Unit>
    {
        public int PharmacyMedicineId { get; set; }
    }

    public class RemoveOneMedicineFromCartCommandHandler : ICommandHandler<RemoveOneMedicineFromCartCommand, Unit>
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICurrentUserService _currentUser;

        public RemoveOneMedicineFromCartCommandHandler(IDistributedCache distributedCache, ICurrentUserService currentUser)
        {
            _distributedCache = distributedCache;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(RemoveOneMedicineFromCartCommand request, CancellationToken cancellationToken)
        {
            List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();

            var cartJson = await _distributedCache.GetStringAsync(_currentUser.UserId.ToString(), cancellationToken);

            if (!string.IsNullOrEmpty(cartJson))
            {
                orderDetails = JsonSerializer.Deserialize<List<OrderDetailModel>>(cartJson);
                var orderDetail = orderDetails.FirstOrDefault(x => x.PharmacyMedicineId == request.PharmacyMedicineId);

                if (orderDetail == null)
                {
                    throw new OrderDetailsNotFoundException();
                }
                else
                {
                    orderDetails.Remove(orderDetail);
                }
            }

            var json = JsonSerializer.Serialize(orderDetails);

            await _distributedCache.SetStringAsync(_currentUser.UserId.ToString(), json, cancellationToken);

            return Unit.Value;
        }
    }
}
