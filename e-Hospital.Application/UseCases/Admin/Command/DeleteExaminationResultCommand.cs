using e_Hospital.Application.Abstractions;
using e_Hospital.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace e_Hospital.Application.UseCases.Admin.Command
{
    public class DeleteExaminationResultCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteExaminationResultCommandHandler : ICommandHandler<DeleteExaminationResultCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExaminationResultCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteExaminationResultCommand command, CancellationToken cancellationToken)
        {
            var medicalExaminationResult = await _context.MedicalExaminationResults.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (medicalExaminationResult == null)
            {
                throw new EntityNotFoundException(nameof(medicalExaminationResult));
            }
           _context.MedicalExaminationResults.Remove(medicalExaminationResult);
           await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
