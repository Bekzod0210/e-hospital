using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.DTOs;
using e_Hospital.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace e_Hospital.Application.UseCases.Users.Commands
{
    public class AddMedicineToCartCommand : ICommand<Unit>
    {
        public int PharmacyMedicineId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddMedicineToCartCommandHandler : ICommandHandler<AddMedicineToCartCommand, Unit>
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICurrentUserService _currentUser;

        public AddMedicineToCartCommandHandler(IDistributedCache distributedCache, ICurrentUserService currentUser)
        {
            _distributedCache = distributedCache;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(AddMedicineToCartCommand request, CancellationToken cancellationToken)
        {
            List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();

            var cartJson = await _distributedCache.GetStringAsync(_currentUser.UserId.ToString(), cancellationToken);

            if (string.IsNullOrEmpty(cartJson))
            {
                orderDetails.Add(new OrderDetailModel()
                {
                    PharmacyMedicineId = request.PharmacyMedicineId,
                    Quantity = request.Quantity
                });
            }
            else
            {
                orderDetails = JsonSerializer.Deserialize<List<OrderDetailModel>>(cartJson);
                var orderDetail = orderDetails.FirstOrDefault(x => x.PharmacyMedicineId == request.PharmacyMedicineId);

                if (orderDetail != null)
                {
                    orderDetail.Quantity = request.Quantity;
                }
                else
                {
                    orderDetails.Add(new OrderDetailModel()
                    {
                        PharmacyMedicineId = request.PharmacyMedicineId,
                        Quantity = request.Quantity
                    });
                }
            }

            var json = JsonSerializer.Serialize(orderDetails);

            await _distributedCache.SetStringAsync(_currentUser.UserId.ToString(), json, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
            }, cancellationToken);

            return Unit.Value;

        }
    }
}
