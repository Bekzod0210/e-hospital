using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using e_Hospital.Application.Abstractions;
using e_Hospital.Application.Exceptions;
using e_Hospital.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class CreateProfessionCommand : ICommand<Unit>
    {
        public string Name { get; set; }
    }

    public class CreateProfessionCommandHandler : ICommandHandler<CreateProfessionCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public CreateProfessionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateProfessionCommand request, CancellationToken cancellationToken)
        {
            if(await _context.Professions.AnyAsync(x => x.Name == request.Name, cancellationToken))
            {
                throw new ProfessionExistException();
            }

            var profession = new Profession()
            {
                Name = request.Name
            };

            await _context.Professions.AddAsync(profession, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
