﻿using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Entities;
using e_Hospital.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Commands
{
    public class UpdateQueueForPatientCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public int ProfessionId { get; set; }
        public int HospitalId { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class UpdateQueueForPatientCommandHandler : ICommandHandler<UpdateQueueForPatientCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public UpdateQueueForPatientCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _context = applicationDbContext;
            _currentUser = currentUserService;
        }

        public async Task<Unit> Handle(UpdateQueueForPatientCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Queues.FirstOrDefaultAsync(x => x.PatientId == _currentUser.UserId);
            
            if (user == null) 
            {
                throw new Exception("You can change only your Queues");
            }

            var hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.Id == command.HospitalId, cancellationToken);

            if (hospital == null)
            {
                throw new Exception(nameof(EntityNotFoundException));
            }

            var profession = await _context.Professions.FirstOrDefaultAsync(x => x.Id == command.ProfessionId, cancellationToken);

            if (profession == null)
            {
                throw new Exception(nameof(EntityNotFoundException));
            }
            var data = await _context.Queues.FirstOrDefaultAsync(x => x.Date == command.DateTime, cancellationToken);
            if (data != null)
            {
                throw new Exception("Please choose another time for MedicalExamination");
            }

            _context.Queues.Update(new Queue()
            {
                Date = command.DateTime,
                PatientId = _currentUser.UserId,
                HospitalId = command.HospitalId,
                ProfessionId = command.ProfessionId,
            });

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

