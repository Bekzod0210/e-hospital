using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class UpdatePharmacyCommand : ICommand<Unit>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }

    public class UpdatePharmacyCommandHadler : ICommandHandler<UpdatePharmacyCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePharmacyCommandHadler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePharmacyCommand request, CancellationToken cancellationToken)
        {
            var pharmacy = await _context.Pharmacies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (pharmacy == null)
            {
                throw new PharmacyNotFoundExeption();
            }

            pharmacy.Name = request.Name ?? pharmacy.Name;
            pharmacy.PhoneNumber = request.PhoneNumber ?? pharmacy.PhoneNumber;
            pharmacy.Address = request.Address ?? pharmacy.Address;

            _context.Pharmacies.Update(pharmacy);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
