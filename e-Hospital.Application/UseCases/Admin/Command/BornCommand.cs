using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Enums;
using MediatR;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class BornCommand : ICommand<Unit>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Gender Gender { get; set; }
        public int UserId { get; set; }
        public int HospitalId { get; set; }
    }
    public class BornCommandHandler : ICommandHandler<BornCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public BornCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(BornCommand request, CancellationToken cancellationToken)
        {
            await _context.Bornes.AddAsync(new Domain.Entities.Born()
            {
                Name = request.Name,
                Date = request.Date,
                Gender = request.Gender,
                UserId = request.UserId,
                HospitalId = request.HospitalId
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
