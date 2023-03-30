using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class CreateHospitalCommand : ICommand<int>
    {
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }

    public class CreateHospitalCommandHandler : ICommandHandler<CreateHospitalCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateHospitalCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Hospitals.AnyAsync(x => x.Name == request.Name && x.PhoneNumber == request.PhoneNumber && x.Address == request.Address, cancellationToken))
            {
                throw new HospitalExistsException();
            }

            var hospital = new Hospital
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            await _context.Hospitals.AddAsync(hospital);

            await _context.SaveChangesAsync(cancellationToken);

            return hospital.Id;

        }
    }
}
