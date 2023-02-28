using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Entities;
using e_Hospital.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UserCases.Users.Commands
{
    public class PatientRegisterCommand : ICommand<Unit>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
    }

    public class PatientRegisterCommandHandler : ICommandHandler<PatientRegisterCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHashService _hashService;

        public PatientRegisterCommandHandler(IApplicationDbContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }

        public async Task<Unit> Handle(PatientRegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Patients.AnyAsync(c => c.UserName == request.UserName, cancellationToken))
            {
                throw new RegisterException();
            }

            var patient = new Patient()
            {
                UserName = request.UserName,
                Name = request.UserName,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = _hashService.GetHash(request.Password),
            };

            await _context.Patients.AddAsync(patient, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
