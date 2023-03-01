using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class DeleteProfessionCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteProfessionCommandHandler : ICommandHandler<DeleteProfessionCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProfessionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProfessionCommand request, CancellationToken cancellationToken)
        {
            var profession = await _context.Professions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (profession == null)
            {
                throw new ProfessionNotFoundException();
            }

            _context.Professions.Remove(profession);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
