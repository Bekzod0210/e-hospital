using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class CreatePharmacyCommand : ICommand<int>
    {
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }

    public class CreatePharmacyCommandHandler : ICommandHandler<CreatePharmacyCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePharmacyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePharmacyCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Pharmacies.AnyAsync(x => x.Name == request.Name && x.PhoneNumber == request.PhoneNumber && x.Address == request.Address, cancellationToken))
            {
                throw new PharmacyExistsException();
            }

            var pharmacy = new Pharmacy
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            await _context.Pharmacies.AddAsync(pharmacy);

            await _context.SaveChangesAsync(cancellationToken);

            return pharmacy.Id;

        }
    }
}
