using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class DeletePharmacyCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeletePharmacyCommandHandler : ICommandHandler<DeletePharmacyCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeletePharmacyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePharmacyCommand request, CancellationToken cancellationToken)
        {
            var pharmacy = await _context.Pharmacies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (pharmacy == null)
            {
                throw new PharmacyNotFoundExeption();
            }

            _context.Pharmacies.Remove(pharmacy);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
