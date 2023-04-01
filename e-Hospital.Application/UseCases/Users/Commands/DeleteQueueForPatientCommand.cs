using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Users.Commands
{
    public class DeleteQueueForPatientCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteQueueForPatientCommandHandler : ICommandHandler<DeleteQueueForPatientCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public DeleteQueueForPatientCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _context = applicationDbContext;
            _currentUserService = currentUserService;
        }
        public async Task<Unit> Handle(DeleteQueueForPatientCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Queues.FirstOrDefaultAsync(x => x.PatientId == _currentUserService.UserId,cancellationToken);
            if (user == null)
            {
                throw new Exception("You can't delete other's queue");
            }
            var queue = await _context.Queues.FirstOrDefaultAsync(x => x.Id == command.Id,cancellationToken);
            if (queue == null)
            {
                throw new Exception(nameof(EntityNotFoundException));
            }

            _context.Queues.Remove(queue);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
