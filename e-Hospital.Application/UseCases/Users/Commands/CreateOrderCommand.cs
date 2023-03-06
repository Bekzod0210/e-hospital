using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace e_Hospital.Application.UseCases.Users.Commands
{
    public class CreateOrderCommand : ICommand<Unit>
    {
    }

    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Unit>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDistributedCache _cache;
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(ICurrentUserService currentUserService, IDistributedCache cache, IApplicationDbContext context)
        {
            _currentUserService = currentUserService;
            _cache = cache;
            _context = context;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var orderDetailsJson = await _cache.GetStringAsync($"{_currentUserService.UserId}", cancellationToken);

            if (string.IsNullOrEmpty(orderDetailsJson))
            {
                throw new OrderDetailsNotFoundException();
            }

            var orderDetails = JsonSerializer.Deserialize<List<OrderDetail>>(orderDetailsJson);

            if (orderDetails.Count == 0)
            {
                throw new OrderDetailsNotFoundException();
            }

            var order = new Order
            {
                PatientId = _currentUserService.UserId,
                Date = DateTime.UtcNow
            };

            double totalSum = 0;

            foreach (var orderDetailView in orderDetails)
            {
                var quantity = orderDetailView.Quantity;

                var pharmacyMedicine = await _context.PharmacyMedicines.FirstOrDefaultAsync(x => x.Id == orderDetailView.PharmacyMedicineId, cancellationToken);

                if (pharmacyMedicine == null)
                {
                    throw new MedicineNotFoundException();
                }

                var price = pharmacyMedicine.Price;
                totalSum = totalSum + quantity * price;
            }

            order.TotalSum = totalSum;
            order.OrderDetails = orderDetails;

            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.OrdersDetails.AddRangeAsync(orderDetails, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await _cache.RemoveAsync($"{_currentUserService.UserId}", cancellationToken);

            return Unit.Value;
        }
    }
}
