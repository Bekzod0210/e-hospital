using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class UpdateHospitalCommand : ICommand<Unit>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }

    public class UpdateHospitalCommandHadler : ICommandHandler<UpdateHospitalCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateHospitalCommandHadler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (hospital == null)
            {
                throw new HospitalNotFoundException();
            }

            hospital.Name = request.Name ?? hospital.Name;
            hospital.PhoneNumber = request.PhoneNumber ?? hospital.PhoneNumber;
            hospital.Address = request.Address ?? hospital.Address;

            _context.Hospitals.Update(hospital);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
