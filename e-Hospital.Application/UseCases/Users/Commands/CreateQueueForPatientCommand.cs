﻿using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Commands
{
    public class CreateQueueForPatientCommand : ICommand<Unit>
    {
        public int ProfessionId { get; set; }
        public int HospitalId { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class CreateQueueForPatientCommandHandler : ICommandHandler<CreateQueueForPatientCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public CreateQueueForPatientCommandHandler(IApplicationDbContext applicationDbContext,ICurrentUserService currentUserService)
        {
            _context = applicationDbContext;
            _currentUser = currentUserService;
        }

        public async Task<Unit> Handle(CreateQueueForPatientCommand command, CancellationToken cancellationToken)
        {
/*            var hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == command.HospitalId, cancellationToken);

            if (hospital == null)
            {
                throw new Exception(nameof(EntityNotFoundException));
            }

            var profession = await _context.Professions.FirstOrDefaultAsync(x => x.Id == command.ProfessionId, cancellationToken);
            
            if (profession == null)
            {
                throw new Exception(nameof(EntityNotFoundException));
            }*/
            if (command.DateTime < DateTime.UtcNow)
            {
                throw new Exception("Please choose valid  time for MedicalExamination");
            }
            var data = await _context.Queues.AnyAsync(x => x.HospitalId == command.HospitalId && (x.Date.Minute+10 <= command.DateTime.Minute) && x.ProfessionId == command.ProfessionId);
            if (data is false)
            {
                throw new Exception("Please choose another time for MedicalExamination");
            }

            await _context.Queues.AddAsync(new Queue()
            {
                Date = command.DateTime,
                PatientId = _currentUser.UserId,
                HospitalId = command.HospitalId,
                ProfessionId = command.ProfessionId,
            },cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}