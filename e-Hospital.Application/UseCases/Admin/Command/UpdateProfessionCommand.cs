using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class UpdateProfessionCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateProfessionCommandHandler : ICommandHandler<UpdateProfessionCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProfessionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProfessionCommand request, CancellationToken cancellationToken)
        {
            var profession = await _context.Professions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (profession == null)
            {
                throw new ProfessionNotFoundException();
            }

            profession.Name = request.Name ?? profession.Name;

            _context.Professions.Update(profession);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
