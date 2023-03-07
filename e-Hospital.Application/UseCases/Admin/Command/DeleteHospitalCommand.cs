using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class DeleteHospitalCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteHospitalCommandHandler : ICommandHandler<DeleteHospitalCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteHospitalCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (hospital == null)
            {
                throw new HospitalNotFoundException();
            }

            _context.Hospitals.Remove(hospital);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
